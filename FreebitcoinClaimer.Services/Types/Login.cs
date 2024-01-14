namespace FreebitcoinClaimer.Services.Types
{
    public class Login
    {
        public Login()
        { }

        public Login(
            string btcAddress,
            string password,
            string fbtcUserId,
            string fbtcSession)
        {
            BtcAddress = btcAddress;
            Password = password;
            FbtcUserId = fbtcUserId;
            FbtcSession = fbtcSession;
        }

        public string BtcAddress { get; set; }

        public string Password { get; set; }

        public string FbtcUserId { get; set; }

        public string FbtcSession { get; set; }
    }
}
