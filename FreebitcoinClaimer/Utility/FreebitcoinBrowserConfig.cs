using WebDriverManager.DriverConfigs.Impl;

namespace FreebitcoinClaimer.Utility
{
    public class FreebitcoinClaimerBrowserConfig : ChromeConfig
    {
        public override string GetName()
        {
            return Path.Combine(Folders.ChromeDriver);
        }
    }
}