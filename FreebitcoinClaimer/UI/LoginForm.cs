using FreebitcoinClaimer.Services;
using FreebitcoinClaimer.Services.Types;
using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;

namespace FreebitcoinClaimer.UI
{
    public partial class LoginForm : Form
    {
        private Timer Timer { get; set; }
        private double currentClock = 0;

        public LoginForm()
        {
            InitializeComponent();
            Timer = new Timer();
            DialogResult = DialogResult.Abort;
        }

        private void LoginButton_Click(object sender, EventArgs e) => LoginFreebitcoin();
        private void FormTextBox_Enter(object sender, EventArgs e) => LoginFreebitcoin();

        private async void LoginFreebitcoin()
        {
            this.loginButton.Enabled = false;

            var username = this.emailAddressTextBox.Text;
            var password = this.passwordTextBox.Text;
            var tfa = this.faTextBox.Text;
            var saveInformation = remeberMeCheckBox.Checked;

            try
            {
                await FreebitcoinManager.Login(username, password, tfa, saveInformation);
                this.DialogResult = DialogResult.OK;
            }
            catch (TooManyAttemptsException ex)
            {
                var timeout = int.Parse(Regex.Match(ex.Message, @"\d+").Value);

                currentClock = TimeSpan.FromMinutes(timeout).TotalSeconds;

                if (timeout > 5)
                    currentClock = TimeSpan.FromSeconds(timeout).TotalSeconds;

                Timer.Interval = 1000;
                Timer.Start();
                Timer.Tick += Timer_Tick;

                MessageBox.Show($"{ex.Message}", "Freebitcoin Claimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Freebitcoin Claimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.loginButton.Enabled = true;
                return;
            }

            this.Close();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            this.loginButton.Text = TimeSpan.FromSeconds(currentClock).ToString(@"mm\:ss");

            currentClock--;

            if (currentClock == 0)
            {
                Timer.Stop();
                this.loginButton.Text = "Login";
                this.loginButton.Enabled = true;
            }
        }
    }
}
