using FreebitcoinClaimer.Utility;

namespace FreebitcoinClaimer.UI
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer UpdateTimer = new System.Windows.Forms.Timer();

        private bool Running = false;

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

            UpdateTimer.Tick += UpdateBalanceTimer_Tick;
            UpdateTimer.Enabled = true;
            UpdateTimer.Interval = 1000;

            var initialBalance = FreebitcoinControl.GetBalance();

            InitialBalance = initialBalance;
            CurrentBalance = initialBalance;
            this.initialBalanceValueLabel.Text = InitialBalance.ToString();
            this.currentBalanceValueLabel.Text = CurrentBalance.ToString();
        }

        private void UpdateBalanceTimer_Tick(object? sender, EventArgs e) => UpdateMonitor();

        private void UpdateMonitor()
        {
            CurrentBalance = FreebitcoinControl.GetBalance();

            currentBalanceValueLabel.Text = CurrentBalance.ToString("");

            if (InitialBalance == CurrentBalance)
                currentBalanceValueLabel.ForeColor = Color.Black;
            else if (InitialBalance > CurrentBalance)
                currentBalanceValueLabel.ForeColor = Color.Red;
            else
                currentBalanceLabel.ForeColor = Color.DarkGreen;

            var result = FreebitcoinControl.GetResult();

            if (!string.IsNullOrEmpty(result))
                logListBox.Items.Add(result);
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

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                var dialogResult = MessageBox.Show("Claimer is still running.\nWould you like to stop claiming?", "Freebitcoin Claimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                    return;
            }

            if (Running)
                FreebitcoinControl.StopClaimer();
            else
                FreebitcoinControl.StartClaimer();

            actionButton.Text = Running ? "Start" : "Stop";
            Running = !Running;

            ShowNotification(Running ? "Started" : "Stopped");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
            FreebitcoinControl.Quit();
        }
    }
}
