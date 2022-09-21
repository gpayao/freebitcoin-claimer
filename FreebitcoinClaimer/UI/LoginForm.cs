using FreebitcoinClaimer.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreebitcoinClaimer.UI
{
    public partial class LoginForm : Form
    {
        private System.Timers.Timer ButtonTimer;

        private bool SuccessfulLogin = false;

        public LoginForm()
        {
            InitializeComponent();
            ButtonTimer = new System.Timers.Timer();
            ButtonTimer.Elapsed += ButtonTimer_Elapsed;
        }

        delegate void ActivateLoginButtonCallback();
        private void ActivateLoginButton() => SetControlState(true);

        private void ButtonTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            ButtonTimer.Stop();

            if (this.loginButton.InvokeRequired)
                this.Invoke(new ActivateLoginButtonCallback(ActivateLoginButton));
            else
                SetControlState(true);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var username = this.emailAddressTextBox.Text;
            var password = this.passwordTextBox.Text;
            var fa = this.faTextBox.Text;

            SuccessfulLogin = FreebitcoinControl.Login(username, password, fa, out string errorMessage);

            if (!SuccessfulLogin)
            {
                MessageBox.Show($"Login Failed.\n{errorMessage}", "Freebitcoin Claimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (errorMessage.Contains("Too many tries"))
                {
                    var number = int.Parse(Regex.Match(errorMessage, @"\d+").Value);

                    double waitNumber = 0;

                    if (errorMessage.Contains("minutes"))
                        waitNumber = TimeSpan.FromMinutes(number).TotalMilliseconds;

                    if (errorMessage.Contains("seconds"))
                        waitNumber = TimeSpan.FromSeconds(number).TotalMilliseconds;

                    ButtonTimer.Interval = waitNumber;
                    ButtonTimer.Start();

                    SetControlState(false);
                }

                return;
            }

            this.Close();
        }

        private void SetControlState(bool state)
        {
            this.emailAddressTextBox.Enabled = state;
            this.passwordTextBox.Enabled = state;
            this.faTextBox.Enabled = state;
            this.loginButton.Enabled = state;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!SuccessfulLogin)
                Program.Shutdown();
        }
    }
}
