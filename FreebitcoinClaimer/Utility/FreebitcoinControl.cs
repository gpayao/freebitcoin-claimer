using FreebitcoinClaimer.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing.Printing;
using System.Globalization;

namespace FreebitcoinClaimer.Utility
{
    public class FreebitcoinControl
    {
        private static readonly string FreebitcoinHomePage = "https://freebitco.in/";

        private static IWebDriver? Driver;

        internal static void Setup()
        {
            Logger.Info("Starting Chrome Driver");

            var chromeService = ChromeDriverService.CreateDefaultService();
            chromeService.HideCommandPromptWindow = true;
            chromeService.SuppressInitialDiagnosticInformation = true;

            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };

            options.AddArguments(
                "user-data-dir=" + Folders.ChromeProfile,
                "--start-maximized",
                "--window-size=1920,1080",
                "--disable-notifications"
                );

            if (Logger.Level != LogLevel.Debug)
                options.AddArgument("headless");

            Driver = new ChromeDriver(chromeService, options);

            Driver.Navigate().GoToUrl(FreebitcoinHomePage);
        }

        public static bool NeedLogin()
        {
            try
            {
                Driver!.FindElement(By.CssSelector("#balance"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool Login(string username, string password, string fa, out string errorMessage)
        {
            Logger.Info("Logging in");

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

            Driver.FindElement(By.CssSelector("#login_button")).Click();

            Thread.Sleep(2000);

            try
            {
                Driver.FindElement(By.CssSelector("#balance"));
                return true;
            }
            catch (NoSuchElementException)
            {
                errorMessage = Driver.FindElement(By.CssSelector("#reward_point_redeem_result_container_div span.reward_point_redeem_result")).Text;
                return false;
            }
        }

        public static double GetBalance()
        {
            return double.Parse(Driver!.FindElement(By.CssSelector("#balance")).Text, CultureInfo.InvariantCulture);
        }

        public static string GetResult()
        {
            throw new NotImplementedException();
        }

        public static int GetCountdownMinutes()
        {
            string minutesRemainingText;

            try
            {
                IWebElement countdownElement = Driver!.FindElement(By.CssSelector("#time_remaining > span.countdown_row.countdown_show2 > span.countdown_section:first-child > span.countdown_amount"));
                minutesRemainingText = countdownElement.Text;
            }
            catch (NoSuchElementException)
            {
                minutesRemainingText = "";
            }

            if (!int.TryParse(minutesRemainingText, out int result))
                return 0;

            return result;
        }

        public static List<string> GetHistory()
        {
            var output = new List<string>();
            try
            {
                var rowsElements = Driver!.FindElements(By.CssSelector("#bet_history_table_rows .multiply_bet_history_table_row"));

                if (rowsElements.Count == 0)
                {
                    Driver.FindElement(By.CssSelector(".top-bar-section a.double_your_btc_link")).Click();
                    rowsElements = Driver!.FindElements(By.CssSelector("#bet_history_table_rows .multiply_bet_history_table_row"));
                }

                foreach (var row in rowsElements)
                {
                    var resultDiv = row.FindElement(By.CssSelector("div:first-child"));

                    var time = resultDiv.FindElement(By.CssSelector("div:nth-child(1)")).Text;
                    var roll = resultDiv.FindElement(By.CssSelector("div:nth-child(4)")).Text;
                    var profit = resultDiv.FindElement(By.CssSelector("div:nth-child(7) font")).Text;

                    output.Add($"{time}|{roll}|{profit}");
                }
            }
            catch (NoSuchElementException)
            {
                throw;
            }

            return output;
        }

        public static void Claim()
        {
            Driver!.Navigate().Refresh();

            IWebElement rollButton = Driver.FindElement(By.CssSelector("#free_play_form_button"));

            if (rollButton.Displayed)
                rollButton.SendKeys(" "); // TODO: Change this. Click does not interact with the element. STUPID!
        }

        public static void Quit()
        {
            if (Driver is not null)
                Driver.Quit();
        }
    }
}
