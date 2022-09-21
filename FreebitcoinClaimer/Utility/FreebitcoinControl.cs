using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V102.CSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreebitcoinClaimer.Utility
{
    public static class FreebitcoinControl
    {
        private static string FreebitcoinHomePage = "https://freebitco.in/";
        private static double ClaimInterval = 60;

        private static IWebDriver Driver;
        private static IJavaScriptExecutor JavaScriptExecutor;

        private static System.Timers.Timer Timer;

        private static ChromeOptions GetDefaultOptions(bool headless = false)
        {
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };

            options.AddArgument("user-data-dir=" + Folders.ChromeProfile);
            options.AddArgument("--start-maximized");
            options.AddArgument("--window-size=1920,1080");

            if (headless)
                options.AddArgument("headless");


            return options;
        }

        public static bool TestLogin()
        {
            if (Driver is null)
                SetUpDriver();


            Driver!.Navigate().GoToUrl(FreebitcoinHomePage);
            if (Driver.FindElements(By.CssSelector("#balance_small")).Count > 0)
                return true;

            return false;


        }

        private static void SetUpDriver()
        {
            var chromeService = ChromeDriverService.CreateDefaultService();
            chromeService.HideCommandPromptWindow = true;
            chromeService.SuppressInitialDiagnosticInformation = true;

            Driver = new ChromeDriver(chromeService, GetDefaultOptions(true));
            JavaScriptExecutor = (IJavaScriptExecutor)Driver;
        }

        public static bool Login(string username, string password, string fa, out string errorMessage)
        {
            if (Driver is null)
                SetUpDriver();

            errorMessage = string.Empty;

            if (!Driver!.Url.Contains("signup"))
                Driver!.Navigate().GoToUrl(FreebitcoinHomePage);

            IWebElement usernameInput = Driver.FindElement(By.CssSelector("#login_form_btc_address"));
            IWebElement passwordInput = Driver.FindElement(By.CssSelector("#login_form_password"));
            IWebElement faInput = Driver.FindElement(By.CssSelector("#login_form_2fa"));

            if (!usernameInput.Displayed)
                Driver.FindElement(By.CssSelector("li.login_menu_button > a")).Click();

            usernameInput.Clear();
            usernameInput.SendKeys(username);

            passwordInput.Clear();
            passwordInput.SendKeys(password);

            faInput.Clear();
            faInput.SendKeys(fa);

            if (Driver.FindElements(By.CssSelector(".pushpad_deny_button")).Count > 0
                && Driver.FindElement(By.CssSelector(".pushpad_deny_button")).Displayed)
                Driver.FindElement(By.CssSelector(".pushpad_deny_button")).Click();

            Driver.FindElement(By.CssSelector("#login_button")).Click();

            Thread.Sleep(2000);

            if (Driver.FindElements(By.CssSelector("#reward_point_redeem_result_container_div")).Count > 0)
            {
                errorMessage = Driver.FindElement(By.CssSelector("#reward_point_redeem_result_container_div span.reward_point_redeem_result")).Text;
                return false;
            }

            return true;

        }

        private static void Claim(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (Driver is null)
                SetUpDriver();

            var currentUrl = Driver.Url;

            //balance_small
        }

        public static void StartClaimer()
        {
            Timer = new System.Timers.Timer(TimeSpan.FromMinutes(ClaimInterval).TotalMilliseconds);
            Timer.Elapsed += Claim;
            Timer.Start();
        }

        public static void StopClaimer()
        {
            Timer.Stop();
        }

        public static void Quit()
        {
            if (Driver is not null)
            {
                Driver.Quit();
            }
        }
    }
}
