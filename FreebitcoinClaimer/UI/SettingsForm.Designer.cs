namespace FreebitcoinClaimer.UI
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            header = new Label();
            basicSettingsGroupBox = new GroupBox();
            claimDelayNumericUpDown = new NumericUpDown();
            claimDelayLabel = new Label();
            checkForUpdatesComboBox = new ComboBox();
            checkForUpdatesLabel = new Label();
            showAdvancedSettingsCheckBox = new CheckBox();
            saveSettingsButton = new Button();
            advancedSettingsGroupBox = new GroupBox();
            logLevelComboBox = new ComboBox();
            logLevelLabel = new Label();
            logToFileComboBox = new ComboBox();
            logToFileLabel = new Label();
            claimDelayToolTip = new ToolTip(components);
            basicToolTip = new ToolTip(components);
            basicSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)claimDelayNumericUpDown).BeginInit();
            advancedSettingsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // header
            // 
            header.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            header.Location = new Point(12, 9);
            header.Name = "header";
            header.Size = new Size(241, 21);
            header.TabIndex = 1;
            header.Text = "Settings";
            header.TextAlign = ContentAlignment.TopCenter;
            // 
            // basicSettingsGroupBox
            // 
            basicSettingsGroupBox.Controls.Add(claimDelayNumericUpDown);
            basicSettingsGroupBox.Controls.Add(claimDelayLabel);
            basicSettingsGroupBox.Controls.Add(checkForUpdatesComboBox);
            basicSettingsGroupBox.Controls.Add(checkForUpdatesLabel);
            basicSettingsGroupBox.Location = new Point(12, 33);
            basicSettingsGroupBox.Name = "basicSettingsGroupBox";
            basicSettingsGroupBox.Size = new Size(240, 77);
            basicSettingsGroupBox.TabIndex = 100;
            basicSettingsGroupBox.TabStop = false;
            // 
            // claimDelayNumericUpDown
            // 
            claimDelayNumericUpDown.Location = new Point(114, 46);
            claimDelayNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            claimDelayNumericUpDown.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            claimDelayNumericUpDown.Name = "claimDelayNumericUpDown";
            claimDelayNumericUpDown.Size = new Size(120, 23);
            claimDelayNumericUpDown.TabIndex = 200;
            claimDelayToolTip.SetToolTip(claimDelayNumericUpDown, "Defined in milliseconds");
            claimDelayNumericUpDown.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // claimDelayLabel
            // 
            claimDelayLabel.AutoSize = true;
            claimDelayLabel.Location = new Point(6, 48);
            claimDelayLabel.Name = "claimDelayLabel";
            claimDelayLabel.Size = new Size(70, 15);
            claimDelayLabel.TabIndex = 0;
            claimDelayLabel.Text = "Claim Delay";
            claimDelayToolTip.SetToolTip(claimDelayLabel, "Defined in milliseconds");
            // 
            // checkForUpdatesComboBox
            // 
            checkForUpdatesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            checkForUpdatesComboBox.FormattingEnabled = true;
            checkForUpdatesComboBox.Items.AddRange(new object[] { "True", "False" });
            checkForUpdatesComboBox.Location = new Point(114, 16);
            checkForUpdatesComboBox.Name = "checkForUpdatesComboBox";
            checkForUpdatesComboBox.Size = new Size(120, 23);
            checkForUpdatesComboBox.TabIndex = 100;
            basicToolTip.SetToolTip(checkForUpdatesComboBox, "Check For Updates");
            // 
            // checkForUpdatesLabel
            // 
            checkForUpdatesLabel.AutoSize = true;
            checkForUpdatesLabel.Location = new Point(6, 19);
            checkForUpdatesLabel.Name = "checkForUpdatesLabel";
            checkForUpdatesLabel.Size = new Size(106, 15);
            checkForUpdatesLabel.TabIndex = 0;
            checkForUpdatesLabel.Text = "Check For Updates";
            // 
            // showAdvancedSettingsCheckBox
            // 
            showAdvancedSettingsCheckBox.AutoSize = true;
            showAdvancedSettingsCheckBox.Location = new Point(12, 120);
            showAdvancedSettingsCheckBox.Name = "showAdvancedSettingsCheckBox";
            showAdvancedSettingsCheckBox.Size = new Size(111, 19);
            showAdvancedSettingsCheckBox.TabIndex = 300;
            showAdvancedSettingsCheckBox.Text = "Show Advanced";
            showAdvancedSettingsCheckBox.UseVisualStyleBackColor = true;
            showAdvancedSettingsCheckBox.CheckedChanged += ShowAdvancedSettingsCheckBox_CheckedChanged;
            // 
            // saveSettingsButton
            // 
            saveSettingsButton.Location = new Point(126, 116);
            saveSettingsButton.Name = "saveSettingsButton";
            saveSettingsButton.Size = new Size(126, 23);
            saveSettingsButton.TabIndex = 400;
            saveSettingsButton.Text = "Save";
            basicToolTip.SetToolTip(saveSettingsButton, "Save");
            saveSettingsButton.UseVisualStyleBackColor = true;
            saveSettingsButton.Click += SaveSettingsButton_Click;
            // 
            // advancedSettingsGroupBox
            // 
            advancedSettingsGroupBox.Controls.Add(logLevelComboBox);
            advancedSettingsGroupBox.Controls.Add(logLevelLabel);
            advancedSettingsGroupBox.Controls.Add(logToFileComboBox);
            advancedSettingsGroupBox.Controls.Add(logToFileLabel);
            advancedSettingsGroupBox.Enabled = false;
            advancedSettingsGroupBox.Location = new Point(12, 145);
            advancedSettingsGroupBox.Name = "advancedSettingsGroupBox";
            advancedSettingsGroupBox.Size = new Size(240, 79);
            advancedSettingsGroupBox.TabIndex = 1000;
            advancedSettingsGroupBox.TabStop = false;
            // 
            // logLevelComboBox
            // 
            logLevelComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            logLevelComboBox.FormattingEnabled = true;
            logLevelComboBox.Items.AddRange(new object[] { "Debug", "Error", "Fatal", "Information", "Warning" });
            logLevelComboBox.Location = new Point(114, 46);
            logLevelComboBox.Name = "logLevelComboBox";
            logLevelComboBox.Size = new Size(120, 23);
            logLevelComboBox.TabIndex = 200;
            basicToolTip.SetToolTip(logLevelComboBox, "Log Level");
            // 
            // logLevelLabel
            // 
            logLevelLabel.AutoSize = true;
            logLevelLabel.Location = new Point(6, 49);
            logLevelLabel.Name = "logLevelLabel";
            logLevelLabel.Size = new Size(57, 15);
            logLevelLabel.TabIndex = 0;
            logLevelLabel.Text = "Log Level";
            // 
            // logToFileComboBox
            // 
            logToFileComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            logToFileComboBox.FormattingEnabled = true;
            logToFileComboBox.Items.AddRange(new object[] { "True", "False" });
            logToFileComboBox.Location = new Point(114, 17);
            logToFileComboBox.Name = "logToFileComboBox";
            logToFileComboBox.Size = new Size(120, 23);
            logToFileComboBox.TabIndex = 100;
            basicToolTip.SetToolTip(logToFileComboBox, "Log To File");
            // 
            // logToFileLabel
            // 
            logToFileLabel.AutoSize = true;
            logToFileLabel.Location = new Point(6, 20);
            logToFileLabel.Name = "logToFileLabel";
            logToFileLabel.Size = new Size(63, 15);
            logToFileLabel.TabIndex = 0;
            logToFileLabel.Text = "Log To File";
            // 
            // claimDelayToolTip
            // 
            claimDelayToolTip.ToolTipTitle = "Claim Delay";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 236);
            Controls.Add(advancedSettingsGroupBox);
            Controls.Add(saveSettingsButton);
            Controls.Add(showAdvancedSettingsCheckBox);
            Controls.Add(basicSettingsGroupBox);
            Controls.Add(header);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = Resources.icon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FreeBitcoin Claimer";
            basicSettingsGroupBox.ResumeLayout(false);
            basicSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)claimDelayNumericUpDown).EndInit();
            advancedSettingsGroupBox.ResumeLayout(false);
            advancedSettingsGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label header;
        private GroupBox basicSettingsGroupBox;
        private Label checkForUpdatesLabel;
        private ComboBox checkForUpdatesComboBox;
        private Label claimDelayLabel;
        private CheckBox showAdvancedSettingsCheckBox;
        private Button saveSettingsButton;
        private GroupBox advancedSettingsGroupBox;
        private ComboBox logLevelComboBox;
        private Label logLevelLabel;
        private ComboBox logToFileComboBox;
        private Label logToFileLabel;
        private NumericUpDown claimDelayNumericUpDown;
        private ToolTip claimDelayToolTip;
        private ToolTip basicToolTip;
    }
}