using FreebitcoinClaimer.Services.Types;
using FreebitcoinClaimer.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace FreebitcoinClaimer.Services
{
    public static class FreebitcoinManager
    {
        private static JToken _rootInformation = new JObject();
        private static readonly string _userInformationFilePath = Path.Combine(Folders.Configuration, "LoginInformation.json");

        private static readonly string _freebitcoinBaseUrl = "https://freebitco.in/";

        private static HttpClient _httpClient = new HttpClient();

        public static string CsrfToken { get; private set; } = string.Empty;

        public static void Setup()
        {
            _httpClient = new HttpClient();
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
                    _rootInformation = Util.ReadJson<JToken>(_userInformationFilePath);
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
        }

        public static async Task Login(string btcAddress, string password, string? tfaCode = default)
        {
            var dict = new Dictionary<string, string>
            {
                { "btc_address", btcAddress },
                { "csrf_token", CsrfToken },
                { "password", password },
                { "op", "login_new" },
                { "tfa_code", tfaCode! }
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _freebitcoinBaseUrl)
            {
                Content = new FormUrlEncodedContent(dict)
            };

            var response = await _httpClient.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            //e:Incorrect 2FA code
            //e:Incorrect login details
            //e:Too many tries. Please wait 2 minutes before trying again

            //0:btc_address
            //1:password
            //2:fbtc_userid/userid
            //3:??


            if (responseBody.StartsWith('s'))
            {
                var split = responseBody.Split(':');

                _rootInformation["btc_address"] = split[1];
                _rootInformation["password"] = split[2];
                _rootInformation["userid"] = split[3];
            }
            else
            {
                var endUserResponse = responseBody.Substring(2);

                if (responseBody.ToUpper().Contains("TOO"))
                    throw new TooManyAttemptsException(endUserResponse);

                throw new Exception(endUserResponse);
            }
        }

        //e:Someone has already played from this IP in the last hour. You need to wait for 14 minutes before playing the FREE BTC game again:801:e1





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


    }
}
