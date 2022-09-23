using FreebitcoinClaimer.Utility;

namespace FreebitcoinClaimer.UI
{
    public partial class MainForm : Form
    {
        private NotifyIcon notifyIcon;
        private System.Timers.Timer UpdateBalanceTimer = new System.Timers.Timer(1000);

        private bool Running = false;

        public MainForm()
        {
            InitializeComponent();

            notifyIcon = new NotifyIcon
            {
                Text = "Freebitcoin Claimer",
                Icon = FreebitcoinClaimer.Resources.icon,
                Visible = true,
                ContextMenuStrip = new ContextMenuStrip()
            };

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

            UpdateBalanceTimer.Elapsed += UpdateBalanceTimer_Elapsed;
            UpdateBalanceTimer.Start();
        }

        delegate void UpdateBalanceTimerCallback();
        private void UpdateBalanceTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e) =>
            this.Invoke(new UpdateBalanceTimerCallback(UpdateBalance));

        private void UpdateBalance() =>
            currentBalanceValueLabel.Text = FreebitcoinControl.GetBalance();

        /**
         * Shows a simple notification with the specified text for 5 seconds.
         */
        public void ShowNotification(string text)
        {
            notifyIcon.BalloonTipTitle = "Claimer";
            notifyIcon.BalloonTipText = text;
            notifyIcon.ShowBalloonTip(5000);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowNotification("Freebitcoin Claimer will run in the background.");
                this.Hide();
            }
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                var dialogResult = MessageBox.Show("Claimer is still running.\nWould you like to stop claiming?", "Freebitcoin Claimer", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                    return;
            }

            if (Running)
                FreebitcoinControl.StopClaimer();
            else
                FreebitcoinControl.StartClaimer();

            actionButton.Text = Running ? "Start" : "Stop";
            Running = !Running;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
            FreebitcoinControl.Quit();
        }
    }
}
