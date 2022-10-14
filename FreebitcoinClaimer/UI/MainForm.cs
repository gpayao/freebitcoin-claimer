using FreebitcoinClaimer.Utility;
using System.Globalization;
using System.Text;

namespace FreebitcoinClaimer.UI
{
    public partial class MainForm : Form
    {
        private readonly System.Windows.Forms.Timer ClaimTimer = new();

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

            UpdateView();
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
                InitialBalance = FreebitcoinControl.GetBalance();

                SetClaimTimerInterval();

                ClaimTimer.Start();
            }

            UpdateView();

            ShowNotification("Auto Claimer: " + (ClaimTimer.Enabled ? "Started" : "Stopped"));
        }

        private void Claim_Tick(object? sender, EventArgs e)
        {
            bool tryAgain = true;
            int attempt = 0;
            while (tryAgain)
            {
                try
                {
                    FreebitcoinControl.PlayFreeRoll();
                    tryAgain = false;
                }
                catch (Exception ex)
                {
                    attempt++;

                    if (attempt == 3)
                    {
                        ClaimTimer.Stop();
                        MessageBox.Show(ex.Message, "Freebitcoin Claimer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            CurrentBalance = FreebitcoinControl.GetBalance();
            int digits = FreebitcoinControl.GetFreeRollDigits();
            string result = FreebitcoinControl.GetFreeRollResult();
            double profit = FreebitcoinControl.GetFreeRollWinnings();

            resultGridView.Rows.Add(DateTime.Now.ToShortTimeString(), digits.ToString("D5"), profit.ToString("0.00000000", CultureInfo.InvariantCulture));

            UpdateView();

            var sb = new StringBuilder();
            sb.AppendLine($"Rolled {digits.ToString("D5")}");
            sb.AppendLine(result);

            ShowNotification(sb.ToString());

            SetClaimTimerInterval();
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

        private void UpdateView()
        {
            actionButton.Text = ClaimTimer.Enabled ? "Stop" : "Start";
            actionMenuItem.Text = ClaimTimer.Enabled ? "Stop" : "Start";

            this.initialBalanceValueLabel.Text = InitialBalance.ToString(CultureInfo.InvariantCulture);
            this.currentBalanceValueLabel.Text = CurrentBalance.ToString(CultureInfo.InvariantCulture);

            if (InitialBalance >= CurrentBalance)
                currentBalanceValueLabel.ForeColor = Color.Black;
            else
                currentBalanceValueLabel.ForeColor = Color.DarkGreen;
        }

        #region Form Default Behavior
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
        #endregion
    }
}
