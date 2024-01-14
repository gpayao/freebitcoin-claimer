namespace FreebitcoinClaimer.Services
{
    public class FreebitcoinClaimerClientOptions
    {
        const string BaseFreebitcoinUrl = "https://freebitco.in/";

        public string? BaseUrl { get; }

        public bool LocalFreebitcoinServerServer { get; }

        public string BaseRequestUrl { get; }

        public string BtcAddress { get; }

        public string Password { get; }

        public string TfaCode { get; }

        public FreebitcoinClaimerClientOptions(string btcAddress, string password, string? tfaCode = default, string? baseUrl = default)
        {
            BtcAddress = btcAddress ?? throw new ArgumentNullException(nameof(btcAddress));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            TfaCode = tfaCode ?? throw new ArgumentNullException(nameof(tfaCode));

            BaseUrl = baseUrl;

            LocalFreebitcoinServerServer = baseUrl is not null;

            var effectiveBaseUrl = LocalFreebitcoinServerServer
                ? ExtractBaseUrl(baseUrl) 
                : BaseFreebitcoinUrl;

            BaseRequestUrl = effectiveBaseUrl;
        }

        static string ExtractBaseUrl(string? baseUrl)
        {
            if (baseUrl is null) { throw new ArgumentNullException(paramName: nameof(baseUrl)); }

            if (!Uri.TryCreate(uriString: baseUrl, uriKind: UriKind.Absolute, out var baseUri)
                || string.IsNullOrEmpty(value: baseUri.Scheme)
                || string.IsNullOrEmpty(value: baseUri.Authority))
            {
                throw new ArgumentException(
                    message: """Invalid format. A valid base URL should look like "http://localhost:8081" """,
                    paramName: nameof(baseUrl)
                );
            }

            return $"{baseUri.Scheme}://{baseUri.Authority}";
        }
    }
}
