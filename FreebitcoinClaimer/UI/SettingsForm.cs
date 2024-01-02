using FreebitcoinClaimer.Utility;

namespace FreebitcoinClaimer.UI
{
    public partial class SettingsForm : Form
    {
        private Dictionary<string, Size> SettingsAvailableWindowSize = new Dictionary<string, Size>
        {
            { "Basic", new Size(280,185) },
            { "Advanced", new Size(280, 275) }
        };

        public SettingsForm()
        {
            InitializeComponent();

            this.Size = SettingsAvailableWindowSize["Basic"];

            var checkUpdatesIndex = checkForUpdatesComboBox.Items.IndexOf(Config.GetBooleanValue("CheckForUpdates", true).ToString());
            checkForUpdatesComboBox.SelectedIndex = checkUpdatesIndex;

            claimDelayNumericUpDown.Value = Config.GetIntegerValue("ClaimDelay", 1000);

            var logToFileIndex = logToFileComboBox.Items.IndexOf(Config.GetBooleanValue("LogToFile", true).ToString());
            logToFileComboBox.SelectedIndex = logToFileIndex;

            var logLevelIndex = logLevelComboBox.Items.IndexOf(Config.GetStringValue("LogLevel", ""));
            logLevelComboBox.SelectedIndex = logLevelIndex;
        }

        private void ShowAdvancedSettingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showAdvancedSettingsCheckBox.Checked)
            {
                this.Size = SettingsAvailableWindowSize["Advanced"];
                advancedSettingsGroupBox.Enabled = true;
            }
            else
            {
                this.Size = SettingsAvailableWindowSize["Basic"];
                advancedSettingsGroupBox.Enabled = false;
            }
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            var checkForUpdates = bool.Parse(checkForUpdatesComboBox.SelectedItem.ToString()!);
            var claimDelay = (int)claimDelayNumericUpDown.Value;
            var logToFile = bool.Parse(logToFileComboBox.SelectedItem.ToString()!);
            var logLevel = logLevelComboBox.SelectedItem.ToString()!;

            Config.SetValue("CheckForUpdates", checkForUpdates);
            Config.SetValue("ClaimDelay", claimDelay);
            Config.SetValue("LogToFile", logToFile);
            Config.SetValue("LogLevel", logLevel);

            MessageBox.Show("Please restart the application for these changes to take effect.", Program.APP_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
