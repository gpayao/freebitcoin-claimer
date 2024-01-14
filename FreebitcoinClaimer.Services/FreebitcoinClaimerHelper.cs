using System.Globalization;

namespace FreebitcoinClaimer.Services
{
    public static class FreebitcoinClaimerHelper
    {
        public static string ToFreeBitcoinNumber(this string value) => (double.Parse(value) / 100000000).ToString("0.00000000", CultureInfo.InvariantCulture);

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
