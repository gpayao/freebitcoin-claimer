using FreebitcoinClaimer.Services.Types;

namespace FreebitcoinClaimer.Services.Requests
{
    public class FreeRollRequest : RequestBase<FreeRoll>
    {
        public string ClientSeed { get; set; }

        public string CsrfToken { get; set; }

        public string Fingerprint { get; set; }

        public string Fingerprint2 { get; set; }

        public string Operation = "free_play";

        public int Pwc { get; set; } = 0;

        public FreeRollRequest(
            string clientSeed,
            string csrfToken,
            string fingerprint,
            string fingerprint2) 
            : base("", HttpMethod.Post)
        { 
            ClientSeed = clientSeed;
            CsrfToken = csrfToken;
            Fingerprint = fingerprint;
            Fingerprint2 = fingerprint2;
        }

        public override HttpContent? ToHttpContent()
        {
            var content = new Dictionary<string, string>()
            {
                { "client_seed", ClientSeed },
                { "csrf_token", CsrfToken },
                { "fingerprint", Fingerprint },
                { "fingerprint2", Fingerprint2 },
                { "op", Operation },
                { "pwc", Pwc.ToString() }
            };

            return new FormUrlEncodedContent(content);
        }
    }
}
