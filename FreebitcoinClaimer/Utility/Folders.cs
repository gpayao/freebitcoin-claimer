namespace FreebitcoinClaimer.Utility
{
    internal static class Folders
    {
        internal static readonly string Data = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FreeBitcoin Claimer");
        internal static readonly string Configuration = Path.Combine(Data, "Config");
        internal static readonly string Logs = Path.Combine(Data, "Logs");

        internal static readonly string Chrome = Path.Combine(Data, "Chrome");
        internal static readonly string ChromeProfile = Path.Combine(Chrome, "Profile");
        internal static readonly string ChromeDriver = Path.Combine(Chrome, "Driver");
    }
}
