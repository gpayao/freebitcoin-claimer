using FreebitcoinClaimer.Services.Types;

namespace FreebitcoinClaimer.Services.Requests
{
    public class LoginRequest : RequestBase<Login>
    {
        public string BtcAddress { get; set; }

        public string Password { get; set; }

        public string? Tfa { get; set; }

        public string Operation = "login_new";

        public LoginRequest(
            string btcAddress,
            string password,
            string? tfa)
            : base("", HttpMethod.Post)
        {
            BtcAddress = btcAddress;
            Password = password;
            Tfa = tfa;
        }

        public override HttpContent? ToHttpContent()
        {
            var content = new Dictionary<string, string>()
            {
                { "btc_address", BtcAddress },
                { "password", Password },
                { "tfa_code", Tfa },
                { "op", Operation },
            };

            return new FormUrlEncodedContent(content);
        }
    }
}
