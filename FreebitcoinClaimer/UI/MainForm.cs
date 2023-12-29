using FreebitcoinClaimer.Services;
using FreebitcoinClaimer.Services.Types;
using System.Globalization;
using System.Text;

namespace FreebitcoinClaimer.UI
{
    public partial class MainForm : Form
    {
        private readonly System.Windows.Forms.Timer ClaimTimer = new();

        private readonly int DefaultClaimInterval = 3600000;

        public MainForm()
        {
            InitializeComponent();

            appNameMenuItem.Text = Program.APP_Name + " " + Program.VERSION;

            ClaimTimer.Tick += Claim_Tick;
            ClaimTimer.Interval = 10;

            GetUserStats();
        }

        private void ClaimButton_Click(object sender, EventArgs e)
        {
            FreeRoll();
        }

        private void AutoClaimButton_Click(object sender, EventArgs e)
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
                ClaimTimer.Start();
            }

            autoclaimButton.Text = ClaimTimer.Enabled ? "Stop" : "Start";
            actionMenuItem.Text = ClaimTimer.Enabled ? "Stop" : "Start";

            ShowNotification("Auto Claimer: " + (ClaimTimer.Enabled ? "Started" : "Stopped"));
        }

        private async void FreeRoll()
        {
            FreeRollResult result;

            try
            {
                result = await FreebitcoinManager.FreeRoll();
            }
            catch (Exception ex)
            {
                var split = ex.Message.Split(':');
                MessageBox.Show(split[0], "Freebitcoin Claimer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClaimTimer.Interval = (int)TimeSpan.FromSeconds(double.Parse(split[1])).TotalMilliseconds;
                return;
            }

            currentBalanceValueLabel.Text = ToFreebitcoinNumber(result.Balance.ToString());

            resultGridView.Rows.Add($"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()}", result.RollNumber.ToString("00000"), ToFreebitcoinNumber(result.Winnings.ToString()), result.VerificationLink);

            var sb = new StringBuilder();
            sb.AppendLine($"Rolled {result.RollNumber.ToString("00000")}");
            sb.AppendLine(ToFreebitcoinNumber(result.Winnings.ToString()));

            ShowNotification(sb.ToString());
        }

        private void Claim_Tick(object? sender, EventArgs e)
        {
            FreeRoll();
            ClaimTimer.Interval = DefaultClaimInterval;

        }

        private async void GetUserStats()
        {
            var userStats = await FreebitcoinManager.GetUserStats();
            currentBalanceValueLabel.Text = ToFreebitcoinNumber(userStats.User!.Balance!);
        }

        public string ToFreebitcoinNumber(string value) => (double.Parse(value) / 100000000).ToString("0.00000000", CultureInfo.InvariantCulture);

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
