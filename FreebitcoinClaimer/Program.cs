using FreebitcoinClaimer.Utility;

namespace FreebitcoinClaimer
{
    internal static class Program
    {
        public static string APP_Name = "FreeBitcoin Claimer";
        public static string VERSION = "1.0.0";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}