using FreebitcoinClaimer.Services.Exceptions;
using FreebitcoinClaimer.Services.Extensions;
using FreebitcoinClaimer.Services.Requests;
using FreebitcoinClaimer.Services.Requests.Abstractions;
using System.Net;

namespace FreebitcoinClaimer.Services
{
    public class FreebitcoinClaimerClient : IFreebitcoinClaimerClient
    {
        readonly FreebitcoinClaimerClientOptions _options;

        readonly HttpClient _httpClient;

        readonly CookieContainer _cookieContainer;

        readonly HttpClientHandler _httpClientHandler;

        public IExceptionParser ExceptionsParser { get; set; } = new DefaultExceptionParser();

        public bool LocalFreebitcoinServer => _options.LocalFreebitcoinServerServer;

        public TimeSpan Timeout
        {
            get => _httpClient.Timeout;
            set => _httpClient.Timeout = value;
        }

        public FreebitcoinClaimerClient(
            FreebitcoinClaimerClientOptions options,
            HttpClient? httpClient = default)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _cookieContainer = new CookieContainer();
            _httpClientHandler = new HttpClientHandler() { CookieContainer = _cookieContainer };
            _httpClient = httpClient ?? new HttpClient(_httpClientHandler);
        }

        public FreebitcoinClaimerClient(
            string btcAddress,
            string password,
            HttpClient? httpClient = default) :
            this(new FreebitcoinClaimerClientOptions(btcAddress, password), httpClient)
        { }

        public virtual async Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken = default)
        {
            if (request == null) { throw new ArgumentNullException(nameof(request)); }

            var url = $"{_options.BaseRequestUrl}/{request.MethodName}";

            var httpRequest = new HttpRequestMessage(method: request.Method, requestUri: url)
            {
                Content = request.ToHttpContent()
            };

            using var httpResponse = await SendRequestAsync(
                httpClient: _httpClient,
                httpRequest: httpRequest,
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                var failedApiResponse = await httpResponse
                    .DeserializeContentAsync<ApiResponse>(
                    guard: response =>
                        response is null
                    )
                    .ConfigureAwait(false);

                throw ExceptionsParser.Parse(failedApiResponse);
            }

            var apiResponse = await httpResponse
                .DeserializeContentAsync<TResponse>(
                    guard: response =>
                        response is null
                )
                .ConfigureAwait(false);

            return apiResponse;
        }

        static async Task<HttpResponseMessage> SendRequestAsync(
            HttpClient httpClient,
            HttpRequestMessage httpRequest,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage? httpResponse;
            try
            {
                httpResponse = await httpClient
                    .SendAsync(request: httpRequest, cancellationToken: cancellationToken)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (TaskCanceledException exception)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }

                throw new RequestException(message: "Request timed out", innerException: exception);
            }
            catch (Exception exception)
            {
                throw new RequestException(
                    message: "Exception during making request",
                    innerException: exception
                );
            }

            return httpResponse;
        }

        public async Task LoginAsync(
            string btcAddress,
            string password,
            string? tfaCode = default,
            CancellationToken cancellationToken = default
        )
        {
            var login = await MakeRequestAsync(
                    request: new LoginRequest(
                        btcAddress,
                        password,
                        tfaCode
                    ),
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

            _cookieContainer.Add(new Uri(_options.BaseRequestUrl), new Cookie("btc_address", login.BtcAddress));
            _cookieContainer.Add(new Uri(_options.BaseRequestUrl), new Cookie("password", login.Password));
            _cookieContainer.Add(new Uri(_options.BaseRequestUrl), new Cookie("fbtc_userid", login.FbtcUserId));
            _cookieContainer.Add(new Uri(_options.BaseRequestUrl), new Cookie("fbtc_session", login.FbtcSession));
        }

        #region Testing purposes

        internal string BaseRequestUrl => _options.BaseRequestUrl;

        #endregion
    }
}
