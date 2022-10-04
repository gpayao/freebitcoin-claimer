using FreebitcoinClaimer.Utility;
using WebDriverManager.DriverConfigs.Impl;

namespace FreebitcoinClaimer.Types
{
    public class FreebitcoinClaimerBrowserConfig : ChromeConfig
    {
        public override string GetName()
        {
            return Path.Combine(Folders.ChromeDriver);
        }
    }
}