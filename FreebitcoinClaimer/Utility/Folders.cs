namespace FreebitcoinClaimer.Utility
{
    internal static class Folders
    {
        internal static readonly string Data = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FreeBitcoin Claimer");
        internal static readonly string Configuration = Path.Combine(Data, "Config");
        internal static readonly string Logs = Path.Combine(Data, "Logs");
    }
}
