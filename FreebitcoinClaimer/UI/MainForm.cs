using FreebitcoinClaimer.Utility;
using System.Globalization;
using System.Text;

namespace FreebitcoinClaimer.UI
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer ClaimTimer = new System.Windows.Forms.Timer();

        private readonly int DefaultClaimInterval = 3600000;

        private double InitialBalance = 0;
        private double CurrentBalance = 0;

        public MainForm()
        {
            InitializeComponent();

            appNameMenuItem.Text = Program.APP_Name + " " + Program.VERSION;

            ClaimTimer.Tick += Claim_Tick;
            ClaimTimer.Interval = DefaultClaimInterval;

            var initialBalance = FreebitcoinControl.GetBalance();

            InitialBalance = initialBalance;
            CurrentBalance = initialBalance;
            this.initialBalanceValueLabel.Text = InitialBalance.ToString(CultureInfo.InvariantCulture);
            this.currentBalanceValueLabel.Text = CurrentBalance.ToString(CultureInfo.InvariantCulture);
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if (ClaimTimer.Enabled)
            {
                var dialogResult = MessageBox.Show("Claimer is still running.\nWould you like to stop claiming?", "Freebitcoin Claimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                    return;

                ClaimTimer.Stop();
            }
            else
            {
                var initialBalance = FreebitcoinControl.GetBalance();
                InitialBalance = initialBalance;
                this.initialBalanceValueLabel.Text = InitialBalance.ToString(CultureInfo.InvariantCulture);

                SetClaimTimerInterval();
                ClaimTimer.Start();
            }

            actionButton.Text = ClaimTimer.Enabled ? "Stop" : "Start";
            actionMenuItem.Text = ClaimTimer.Enabled ? "Stop" : "Start";

            ShowNotification("Auto Claimer: " + (ClaimTimer.Enabled ? "Started" : "Stopped"));
        }

        private void Claim_Tick(object? sender, EventArgs e)
        {
            FreebitcoinControl.Claim();

            SetClaimTimerInterval();

            CurrentBalance = FreebitcoinControl.GetBalance();

            int digits = FreebitcoinControl.GetFreePlayDigits();
            string result = FreebitcoinControl.GetResult();
            string profit = result.Substring(9, 10);

            resultGridView.Rows.Add(DateTime.Now.ToShortTimeString(), digits.ToString("D5"), profit);

            currentBalanceValueLabel.Text = CurrentBalance.ToString(CultureInfo.InvariantCulture);

            if (InitialBalance == CurrentBalance)
                currentBalanceValueLabel.ForeColor = Color.Black;
            else if (InitialBalance > CurrentBalance)
                currentBalanceValueLabel.ForeColor = Color.Red;
            else
                currentBalanceValueLabel.ForeColor = Color.DarkGreen;

            var sb = new StringBuilder();
            sb.AppendLine($"Rolled {digits.ToString("D5")}");
            sb.AppendLine(result);

            ShowNotification(sb.ToString());
        }

        private void SetClaimTimerInterval()
        {
            TimeSpan countdown;

            try
            {
                countdown = FreebitcoinControl.GetCountdown();
            }
            catch (Exception)
            {
                countdown = TimeSpan.FromMilliseconds(DefaultClaimInterval);
            }

            int configurationDelay = Config.GetIntegerValue("Claim.Delay", 0);
            ClaimTimer.Interval = Convert.ToInt32(countdown.TotalMilliseconds) + configurationDelay;
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        public void ShowNotification(string text)
        {
            notifyIcon.BalloonTipText = text;
            notifyIcon.ShowBalloonTip(5000);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // windows keep the icon visible until it's hovered
            notifyIcon.Visible = false;
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs args && args.Button == MouseButtons.Left)
                ShowForm();
        }
    }
}
