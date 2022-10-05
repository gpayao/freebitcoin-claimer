using FreebitcoinClaimer.Utility;

namespace FreebitcoinClaimer.UI
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer UpdateBalanceTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer ClaimTimer = new System.Windows.Forms.Timer();

        private readonly int DefaultClaimInterval = 3600000;

        private readonly double InitialBalance = 0;
        private double CurrentBalance = 0;

        public MainForm()
        {
            InitializeComponent();

            notifyIcon.Text = "Freebitcoin Claimer";
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();

            var menuItemName = new ToolStripMenuItem(Program.APP_Name + " " + Program.VERSION) { Enabled = false };
            var menuItemQuit = new ToolStripMenuItem("Quit", null, (a, b) => this.Close());

            notifyIcon.ContextMenuStrip.Items.Add(menuItemName);
            notifyIcon.ContextMenuStrip.Items.Add(menuItemQuit);

            notifyIcon.Click += (a, b) =>
            {
                if (b is MouseEventArgs args && args.Button == MouseButtons.Left)
                    ShowForm();
            };

            notifyIcon.BalloonTipClicked += (a, b) => { ShowForm(); };

            UpdateBalanceTimer.Tick += UpdateBalance_Tick;
            UpdateBalanceTimer.Interval = 1000;
            UpdateBalanceTimer.Start();

            ClaimTimer.Tick += Claim_Tick;
            ClaimTimer.Interval = DefaultClaimInterval;

            var initialBalance = FreebitcoinControl.GetBalance();

            InitialBalance = initialBalance;
            CurrentBalance = initialBalance;
            this.initialBalanceValueLabel.Text = InitialBalance.ToString();
            this.currentBalanceValueLabel.Text = CurrentBalance.ToString();
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
                SetClaimTimerInterval();
                ClaimTimer.Start();
            }

            actionButton.Text = ClaimTimer.Enabled ? "Start" : "Stop";
            ShowNotification(ClaimTimer.Enabled ? "Started" : "Stopped");
        }

        private void UpdateBalance_Tick(object? sender, EventArgs e)
        {
            CurrentBalance = FreebitcoinControl.GetBalance();

            currentBalanceValueLabel.Text = CurrentBalance.ToString("");

            if (InitialBalance == CurrentBalance)
                currentBalanceValueLabel.ForeColor = Color.Black;
            else if (InitialBalance > CurrentBalance)
                currentBalanceValueLabel.ForeColor = Color.Red;
            else
                currentBalanceLabel.ForeColor = Color.DarkGreen;
        }

        private void Claim_Tick(object? sender, EventArgs e)
        {
            FreebitcoinControl.Claim();

            SetClaimTimerInterval();

            ShowNotification("Claimed");
        }

        private void SetClaimTimerInterval()
        {
            int countdown = (FreebitcoinControl.GetCountdownMinutes() + 1) * 60000;
            ClaimTimer.Interval = countdown;
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        public void ShowNotification(string text)
        {
            notifyIcon.BalloonTipTitle = "Claimer";
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
            notifyIcon.Visible = false;
            //FreebitcoinControl.Quit();
        }
    }
}
