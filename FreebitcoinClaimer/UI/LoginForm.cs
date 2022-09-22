using FreebitcoinClaimer.Utility;
using System.Text.RegularExpressions;

namespace FreebitcoinClaimer.UI
{
    public partial class LoginForm : Form
    {
        private readonly System.Timers.Timer AttemptTimer;
        private readonly System.Timers.Timer ClockTimer;
        private readonly double ClockTimerInterval = 1000;
        private double CurrentClock = 0;

        private bool SuccessfulLogin = false;

        public LoginForm()
        {
            InitializeComponent();
            AttemptTimer = new System.Timers.Timer();
            AttemptTimer.Elapsed += AttemptTimer_Elapsed;

            ClockTimer = new System.Timers.Timer(ClockTimerInterval);
            ClockTimer.Elapsed += ClockTimer_Elapsed;
        }

        delegate void ClockTimerCallback();
        private void ClockTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e) =>
            this.Invoke(new ClockTimerCallback(UpdateOnScreenClock));

        private void UpdateOnScreenClock()
        {
            CurrentClock -= ClockTimerInterval;
            clockLabel.Text = TimeSpan.FromMilliseconds(CurrentClock).ToString(@"mm\:ss");
        }

        delegate void ActivateLoginButtonCallback();
        private void ActivateLoginButton() => 
            SetControlState(true);

        private void AttemptTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            StopTimers();

            this.Invoke(new ActivateLoginButtonCallback(ActivateLoginButton));
        }

        private void LoginButton_Click(object sender, EventArgs e) => LoginFreebitcoin();

        private void LoginFreebitcoin()
        {
            this.loginButton.Enabled = false;

            var username = this.emailAddressTextBox.Text;
            var password = this.passwordTextBox.Text;
            var fa = this.faTextBox.Text;

            SuccessfulLogin = FreebitcoinControl.Login(username, password, fa, out string errorMessage);

            if (!SuccessfulLogin)
            {
                if (errorMessage.Contains("Too many tries"))
                {
                    var interval = int.Parse(Regex.Match(errorMessage, @"\d+").Value);

                    double waitNumber = 0;

                    if (errorMessage.Contains("minutes"))
                        waitNumber = TimeSpan.FromMinutes(interval).TotalMilliseconds;

                    if (errorMessage.Contains("seconds"))
                        waitNumber = TimeSpan.FromSeconds(interval).TotalMilliseconds;

                    StartTimers(waitNumber);
                    UpdateOnScreenClock();
                    SetControlState(false);
                }
                else
                    this.loginButton.Enabled = true;

                MessageBox.Show($"{errorMessage}", "Freebitcoin Claimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            this.Close();
        }

        private void StartTimers(double interval)
        {
            CurrentClock = interval;
            AttemptTimer.Interval = interval;
            AttemptTimer.Start();
            ClockTimer.Start();
        }

        private void StopTimers()
        {
            AttemptTimer.Stop();
            ClockTimer.Stop();
        }

        private void SetControlState(bool state)
        {
            this.loginButton.Enabled = state;
            this.clockLabel.Visible = !state;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!SuccessfulLogin)
                Program.ForceShutdown();
        }
    }
}
