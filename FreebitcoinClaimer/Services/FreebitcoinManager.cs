using FreebitcoinClaimer.Services.Types;
using FreebitcoinClaimer.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Net;

namespace FreebitcoinClaimer.Services
{
    public static class FreebitcoinManager
    {
        private static JObject _rootInformation = new JObject();
        private static readonly string _userInformationFilePath = Path.Combine(Folders.Configuration, "SiteInformation.json");

        private static readonly Uri _freebitcoinBaseUrl = new Uri("https://freebitco.in/");

        private static HttpClient _httpClient = new HttpClient();
        private static HttpClientHandler _httpClientHandler = new HttpClientHandler();
        private static CookieContainer _cookieContainer = new CookieContainer();

        public static string CsrfToken { get; private set; } = string.Empty;
        public const string Fingerprint = "8435762738ca8dc683c406da5b3bb508";

        public static void Setup()
        {
            _cookieContainer = new CookieContainer();
            _httpClientHandler = new HttpClientHandler() { CookieContainer = _cookieContainer };
            _httpClient = new HttpClient(_httpClientHandler);
            CsrfToken = GenerateCSRFToken();
            LoadExistingInformation();
        }

        private static void LoadExistingInformation()
        {
            // Make sure the directory exists
            if (!Directory.Exists(Folders.Configuration))
                Directory.CreateDirectory(Folders.Configuration);

            if (File.Exists(_userInformationFilePath))
            {
                try
                {
                    Log.Information("Loading Freebitcoin user information from {_userInformationFilePath}", _userInformationFilePath);

                    // Load user information from JSON
                    _rootInformation = Util.ReadJson<JObject>(_userInformationFilePath);
                }
                catch (JsonSerializationException)
                {
                    Log.Error("Syntax error occured while reading user information JSON");
                }
                catch (Exception)
                {
                    Log.Error("Failed to read user information JSON");
                }
            }
            else
            {
                Log.Information("Freebitcoin user information file does not exist");
            }

            if (HasLogin())
                AddCookies();
        }

        private static void SaveInformation()
        {
            Log.Information($"Saving freebitcoin information to \"{_userInformationFilePath}\"");

            try
            {
                Util.WriteJson(_userInformationFilePath, _rootInformation);
            }
            catch (Exception ex)
            {
                Log.Error("Failed to write settings JSON", ex);
            }
        }

        public static bool HasLogin()
        {
            if (_rootInformation["btc_address"] is not null
                && _rootInformation["password"] is not null
                && _rootInformation["fbtc_userid"] is not null
                && _rootInformation["fbtc_session"] is not null)
            {
                return true;
            }

            return false;
        }

        private static void AddCookies()
        {
            foreach (var item in _rootInformation)
            {
                if (!_cookieContainer.GetAllCookies().Any(c => c.Name == item.Key))
                {
                    _cookieContainer.Add(_freebitcoinBaseUrl, new Cookie(item.Key, item.Value!.ToString()));
                }
            }
        }

        public static async Task Login(string btcAddress, string password, string tfaCode = "", bool saveInformation = false)
        {
            var dict = new Dictionary<string, string>
            {
                { "btc_address", btcAddress },
                { "csrf_token", CsrfToken },
                { "password", password },
                { "op", "login_new" },
                { "tfa_code", tfaCode! }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, _freebitcoinBaseUrl)
            {
                Content = new FormUrlEncodedContent(dict)
            };

            var response = await _httpClient.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            var split = responseBody.Split(':');

            if (responseBody.StartsWith('s'))
            {
                _rootInformation["btc_address"] = split[1];
                _rootInformation["password"] = split[2];
                _rootInformation["fbtc_userid"] = split[3];
                _rootInformation["fbtc_session"] = split[4];

                if (saveInformation)
                {
                    SaveInformation();
                }
            }
            else
            {
                if (split[1].ToUpper().Contains("TOO"))
                    throw new TooManyAttemptsException(split[1]);

                throw new Exception(split[1]);

                //e:Incorrect 2FA code
                //e:Incorrect login details
                //e:Too many tries. Please wait 2 minutes before trying again
            }

            AddCookies();
            await RecordFingerprint();
        }

        public static async Task<UserStatsResult> GetUserStats()
        {
            if (_rootInformation["socket_password"] is null)
                await GetSocketPassword();

            var dict = new Dictionary<string, string>
            {
                { "u", _rootInformation["fbtc_userid"]!.ToString() },
                { "p", _rootInformation["socket_password"]!.ToString() },
                { "f", "user_stats" },
                { "csrf_token", CsrfToken }
            };

            var queryString = await new FormUrlEncodedContent(dict).ReadAsStringAsync();

            var request = new HttpRequestMessage(HttpMethod.Get, _freebitcoinBaseUrl + "/cf_stats_private/?" + queryString);

            var response = await _httpClient.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserStatsResult>(responseBody)!;
        }

        public static async Task<FreeRollResult> FreeRoll()
        {
            var dict = new Dictionary<string, string>
            {
                { "client_seed", GenerateCSRFToken() },
                { "csrf_token", CsrfToken },
                { "fingerprint", Fingerprint },
                { "fingerprint2", GenerateFingerprint2() },
                { "op", "free_play" },
                { "pwc", "0" }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, _freebitcoinBaseUrl)
            {
                Content = new FormUrlEncodedContent(dict)
            };

            var response = await _httpClient.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            var split = responseBody.Split(':');

            FreeRollResult freeRollResult;
            if (responseBody.StartsWith('s'))
            {
                freeRollResult = new FreeRollResult()
                {
                    RollNumber = int.Parse(split[1]),
                    Balance = double.Parse(split[2]),
                    Winnings = double.Parse(split[3]),
                    LastPlay = long.Parse(split[4]),
                    BalanceUSD = double.Parse(split[5]),
                    NextServerHash = split[6],
                    NextNonce = long.Parse(split[8]),
                    PreviousServerSeed = split[9],
                    PreviousServerSeedHash = split[10],
                    PreviousClientSeed = split[11],
                    PreviousNonce = long.Parse(split[12]),
                    RewardPoints = int.Parse(split[14]),
                    LottertTicketsWon = int.Parse(split[15]),
                    RewardPointsWon = int.Parse(split[16]),
                };
            }
            else
            {
                if (split.Length > 2)
                {
                    throw new Exception(split[1] + ':' + split[2]);
                }

                throw new Exception(split[1]);
                //e:Please logout and then log back in and try again
                //e:Someone has already played from this IP in the last hour. You need to wait for 19 minutes before playing the FREE BTC game again:1126:e1
            }

            return freeRollResult;
        }

        private static async Task GetSocketPassword()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _freebitcoinBaseUrl + "/?op=home");

            var response = await _httpClient.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            var search = "var socket_password = '";

            _rootInformation["socket_password"] = responseBody.Substring(responseBody.IndexOf(search) + search.Length, 64);
        }

        private static async Task RecordFingerprint()
        {
            var dict = new Dictionary<string, string>
            {
                { "op", "record_fingerprint" },
                { "fingerprint", Fingerprint },
                { "csrf_token", CsrfToken }
            };

            var queryString = await new FormUrlEncodedContent(dict).ReadAsStringAsync();

            var request = new HttpRequestMessage(HttpMethod.Get, _freebitcoinBaseUrl + "/cgi-bin/api.pl?" + queryString);

            var response = await _httpClient.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            if (responseBody != "1")
            {
                throw new Exception("Enable to record fingerprint");
            }
        }

        // This function is just a replica of the existing on Freebitcoin page script
        public static string GenerateCSRFToken()
        {
            string token = string.Empty;

            string charSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            for (int i = 0; i < 12; i++)
            {
                var randomPosition = new Random().Next(charSet.Length);
                token += charSet.Substring(randomPosition, 1);
            }

            return token;
        }

        public static string GenerateFingerprint2()
        {
            string fingerprint = string.Empty;

            var rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                var number = rnd.Next(0, 100);
                fingerprint += number.ToString("00");
            }

            return fingerprint;
        }
    }
}
