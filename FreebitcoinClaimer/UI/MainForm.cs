using FreebitcoinClaimer.Services;
using FreebitcoinClaimer.Services.Types;
using FreebitcoinClaimer.Utility;
using System.Diagnostics;
using System.Text;

namespace FreebitcoinClaimer.UI
{
    public partial class MainForm : Form
    {
        private readonly System.Windows.Forms.Timer ClaimTimer;

        private readonly System.Windows.Forms.Timer UpdateInfoTimer;

        private readonly int UpdateInfoDelay;

        private readonly int ClaimDelay;

        public MainForm()
        {
            InitializeComponent();

            ClaimDelay = Config.GetIntegerValue("ClaimDelay", (int)TimeSpan.FromSeconds(1).TotalMilliseconds);
            UpdateInfoDelay = (int)TimeSpan.FromSeconds(15).TotalMilliseconds;

            ClaimTimer = new System.Windows.Forms.Timer();
            ClaimTimer.Tick += Claim_Tick;

            UpdateInfoTimer = new System.Windows.Forms.Timer();
            UpdateInfoTimer.Tick += UpdateInfoTimer_Tick;
            UpdateInfoTimer.Interval = UpdateInfoDelay;
            UpdateInfoTimer.Start();

            appNameMenuItem.Text = Program.APP_Name + " " + Program.Version;

            UpdateBalance();
        }

        private void ClaimButton_Click(object sender, EventArgs e)
        {
            FreeRoll();
        }

        private void AutoClaimButton_Click(object sender, EventArgs e)
        {
            if (ClaimTimer.Enabled)
            {
                var dialogResult = MessageBox.Show("Are you sure you want to stop auto claiming?", Program.APP_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                    return;

                ClaimTimer.Stop();
            }
            else
            {
                ClaimTimer.Interval = ClaimDelay;
                ClaimTimer.Start();
            }

            autoclaimButton.Text = ClaimTimer.Enabled ? "Stop Auto Claim" : "Start Auto Claim";
            actionMenuItem.Text = ClaimTimer.Enabled ? "Stop Auto Claim" : "Start Auto Claim";
            actionToolStripMenuItem.Text = ClaimTimer.Enabled ? "Stop Auto Claim" : "Start Auto Claim";

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
                ClaimTimer.Interval = (int)TimeSpan.FromSeconds(double.Parse(split[1])).TotalMilliseconds + ClaimDelay;
                return;
            }

            currentBalanceValueLabel.Text = result.Balance.ToString().ToFreeBitcoinNumber();

            resultGridView.Rows.Add(
                $"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()}",
                result.RollNumber.ToString("00000"),
                result.Winnings.ToString().ToFreeBitcoinNumber(),
                result.VerificationLink
                );

            var sb = new StringBuilder();
            sb.AppendLine($"Rolled: {result.RollNumber.ToString("00000")}");
            sb.AppendLine($"Profit: {result.Winnings.ToString().ToFreeBitcoinNumber()}");

            ShowNotification(sb.ToString());
        }

        private void Claim_Tick(object? sender, EventArgs e)
        {
            FreeRoll();
            ClaimTimer.Interval = 3600000 + ClaimDelay;
        }

        private void UpdateInfoTimer_Tick(object? sender, EventArgs e)
        {
            UpdateBalance();
        }

        private async void UpdateBalance()
        {
            var userStats = await FreebitcoinManager.GetUserStats();
            currentBalanceValueLabel.Text = userStats.User!.Balance!.ToFreeBitcoinNumber();
        }

        #region Form Default Behavior
        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            UpdateInfoTimer.Start();
        }

        public void ShowNotification(string text)
        {
            notifyIcon.BalloonTipText = text;
            notifyIcon.ShowBalloonTip(5000);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                UpdateInfoTimer.Stop();
            }
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

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs args && args.Button == MouseButtons.Left)
                ShowForm();
        }
        #endregion

        private void ResultGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var url = resultGridView.Rows[e.RowIndex].Cells[3].Value.ToString()!;
                var ps = new ProcessStartInfo(url)
                {
                    UseShellExecute = true,
                    Verb = "open"
                };

                Process.Start(ps);
            }
        }
    }
}
