namespace FreebitcoinClaimer.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            header = new Label();
            autoclaimButton = new Button();
            currentBalanceLabel = new Label();
            currentBalanceValueLabel = new Label();
            notifyIcon = new NotifyIcon(components);
            trayContextMenuStrip = new ContextMenuStrip(components);
            appNameMenuItem = new ToolStripMenuItem();
            actionMenuItem = new ToolStripMenuItem();
            quitMenuItem = new ToolStripMenuItem();
            claimButton = new Button();
            menuStrip = new MenuStrip();
            claimerToolStripMenuItem = new ToolStripMenuItem();
            actionToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            quitToolStripMenuItem = new ToolStripMenuItem();
            basicToolTip = new ToolTip(components);
            button1 = new Button();
            claimControlsGroupBox = new GroupBox();
            infoGroupBox = new GroupBox();
            resultGridView = new DataGridView();
            Time = new DataGridViewTextBoxColumn();
            Roll = new DataGridViewTextBoxColumn();
            Profit = new DataGridViewTextBoxColumn();
            Link = new DataGridViewTextBoxColumn();
            Verify = new DataGridViewButtonColumn();
            trayContextMenuStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            claimControlsGroupBox.SuspendLayout();
            infoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resultGridView).BeginInit();
            SuspendLayout();
            // 
            // header
            // 
            header.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            header.Location = new Point(24, 24);
            header.Name = "header";
            header.Size = new Size(388, 21);
            header.TabIndex = 0;
            header.Text = "Freebitcoin Auto Claimer";
            header.TextAlign = ContentAlignment.TopCenter;
            // 
            // autoclaimButton
            // 
            autoclaimButton.Location = new Point(6, 19);
            autoclaimButton.Name = "autoclaimButton";
            autoclaimButton.Size = new Size(127, 23);
            autoclaimButton.TabIndex = 1;
            autoclaimButton.Text = "Start Auto Claim";
            basicToolTip.SetToolTip(autoclaimButton, "Auto Claim");
            autoclaimButton.UseVisualStyleBackColor = true;
            autoclaimButton.Click += AutoClaimButton_Click;
            // 
            // currentBalanceLabel
            // 
            currentBalanceLabel.Location = new Point(6, 19);
            currentBalanceLabel.Name = "currentBalanceLabel";
            currentBalanceLabel.Size = new Size(127, 23);
            currentBalanceLabel.TabIndex = 2;
            currentBalanceLabel.Text = "Current Balance";
            currentBalanceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // currentBalanceValueLabel
            // 
            currentBalanceValueLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            currentBalanceValueLabel.ForeColor = Color.Black;
            currentBalanceValueLabel.Location = new Point(6, 42);
            currentBalanceValueLabel.Name = "currentBalanceValueLabel";
            currentBalanceValueLabel.Size = new Size(127, 23);
            currentBalanceValueLabel.TabIndex = 3;
            currentBalanceValueLabel.Text = "0.00000000";
            currentBalanceValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            basicToolTip.SetToolTip(currentBalanceValueLabel, "Current Balance\r\n");
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipText = "FreeBitcoin Claimer";
            notifyIcon.BalloonTipTitle = "FreeBitcoin Claimer";
            notifyIcon.ContextMenuStrip = trayContextMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "FreeBitcoin Claimer";
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipClicked += NotifyIcon_Click;
            notifyIcon.Click += NotifyIcon_Click;
            // 
            // trayContextMenuStrip
            // 
            trayContextMenuStrip.Items.AddRange(new ToolStripItem[] { appNameMenuItem, actionMenuItem, quitMenuItem });
            trayContextMenuStrip.Name = "contextMenuStrip";
            trayContextMenuStrip.Size = new Size(178, 70);
            // 
            // appNameMenuItem
            // 
            appNameMenuItem.Enabled = false;
            appNameMenuItem.Name = "appNameMenuItem";
            appNameMenuItem.Size = new Size(177, 22);
            appNameMenuItem.Text = "FreeBitcoin Claimer";
            // 
            // actionMenuItem
            // 
            actionMenuItem.Name = "actionMenuItem";
            actionMenuItem.Size = new Size(177, 22);
            actionMenuItem.Text = "Start";
            actionMenuItem.Click += AutoClaimButton_Click;
            // 
            // quitMenuItem
            // 
            quitMenuItem.Name = "quitMenuItem";
            quitMenuItem.Size = new Size(177, 22);
            quitMenuItem.Text = "Quit";
            quitMenuItem.Click += QuitMenuItem_Click;
            // 
            // claimButton
            // 
            claimButton.Location = new Point(6, 43);
            claimButton.Name = "claimButton";
            claimButton.Size = new Size(127, 23);
            claimButton.TabIndex = 4;
            claimButton.Text = "Manual Claim";
            basicToolTip.SetToolTip(claimButton, "Claim");
            claimButton.UseVisualStyleBackColor = true;
            claimButton.Click += ClaimButton_Click;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { claimerToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(442, 24);
            menuStrip.TabIndex = 5;
            menuStrip.Text = "Menu";
            // 
            // claimerToolStripMenuItem
            // 
            claimerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { actionToolStripMenuItem, toolStripSeparator1, settingsToolStripMenuItem, toolStripSeparator2, quitToolStripMenuItem });
            claimerToolStripMenuItem.Name = "claimerToolStripMenuItem";
            claimerToolStripMenuItem.Size = new Size(60, 20);
            claimerToolStripMenuItem.Text = "Claimer";
            // 
            // actionToolStripMenuItem
            // 
            actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            actionToolStripMenuItem.Size = new Size(180, 22);
            actionToolStripMenuItem.Text = "Start";
            actionToolStripMenuItem.Click += AutoClaimButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(180, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += SettingsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(180, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += QuitMenuItem_Click;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(140, 31);
            button1.Name = "button1";
            button1.Size = new Size(127, 23);
            button1.TabIndex = 5;
            button1.Text = "Multiply Bitcoin";
            basicToolTip.SetToolTip(button1, "Multiply Bitcoin");
            button1.UseVisualStyleBackColor = true;
            // 
            // claimControlsGroupBox
            // 
            claimControlsGroupBox.Controls.Add(button1);
            claimControlsGroupBox.Controls.Add(autoclaimButton);
            claimControlsGroupBox.Controls.Add(claimButton);
            claimControlsGroupBox.Location = new Point(157, 48);
            claimControlsGroupBox.Name = "claimControlsGroupBox";
            claimControlsGroupBox.Size = new Size(273, 72);
            claimControlsGroupBox.TabIndex = 6;
            claimControlsGroupBox.TabStop = false;
            claimControlsGroupBox.Text = "Controls";
            // 
            // infoGroupBox
            // 
            infoGroupBox.Controls.Add(currentBalanceLabel);
            infoGroupBox.Controls.Add(currentBalanceValueLabel);
            infoGroupBox.Location = new Point(12, 48);
            infoGroupBox.Name = "infoGroupBox";
            infoGroupBox.Size = new Size(139, 72);
            infoGroupBox.TabIndex = 7;
            infoGroupBox.TabStop = false;
            infoGroupBox.Text = "Information";
            // 
            // resultGridView
            // 
            resultGridView.AllowUserToAddRows = false;
            resultGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            resultGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            resultGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultGridView.Columns.AddRange(new DataGridViewColumn[] { Time, Roll, Profit, Link, Verify });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            resultGridView.DefaultCellStyle = dataGridViewCellStyle6;
            resultGridView.Location = new Point(12, 126);
            resultGridView.Name = "resultGridView";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            resultGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            resultGridView.RowHeadersVisible = false;
            resultGridView.RowTemplate.Height = 25;
            resultGridView.RowTemplate.Resizable = DataGridViewTriState.False;
            resultGridView.Size = new Size(418, 181);
            resultGridView.TabIndex = 8;
            resultGridView.CellContentClick += ResultGridView_CellContentClick;
            // 
            // Time
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Time.DefaultCellStyle = dataGridViewCellStyle2;
            Time.HeaderText = "Time";
            Time.Name = "Time";
            Time.ReadOnly = true;
            Time.Resizable = DataGridViewTriState.False;
            Time.SortMode = DataGridViewColumnSortMode.NotSortable;
            Time.Width = 120;
            // 
            // Roll
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Roll.DefaultCellStyle = dataGridViewCellStyle3;
            Roll.HeaderText = "Roll";
            Roll.Name = "Roll";
            Roll.ReadOnly = true;
            Roll.Resizable = DataGridViewTriState.False;
            Roll.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Profit
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Profit.DefaultCellStyle = dataGridViewCellStyle4;
            Profit.HeaderText = "Profit";
            Profit.Name = "Profit";
            Profit.ReadOnly = true;
            Profit.Resizable = DataGridViewTriState.False;
            Profit.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Link
            // 
            Link.HeaderText = "Link";
            Link.Name = "Link";
            Link.ReadOnly = true;
            Link.Visible = false;
            // 
            // Verify
            // 
            Verify.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "Click";
            Verify.DefaultCellStyle = dataGridViewCellStyle5;
            Verify.HeaderText = "Verify";
            Verify.Name = "Verify";
            Verify.ReadOnly = true;
            Verify.Resizable = DataGridViewTriState.False;
            Verify.Text = "";
            Verify.ToolTipText = "Verify";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 319);
            Controls.Add(resultGridView);
            Controls.Add(infoGroupBox);
            Controls.Add(claimControlsGroupBox);
            Controls.Add(menuStrip);
            Controls.Add(header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Resources.icon;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FreeBitcoin Claimer";
            FormClosing += MainForm_FormClosing;
            Resize += MainForm_Resize;
            trayContextMenuStrip.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            claimControlsGroupBox.ResumeLayout(false);
            infoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)resultGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label header;
        private Button autoclaimButton;
        private Label currentBalanceLabel;
        private Label currentBalanceValueLabel;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip trayContextMenuStrip;
        private ToolStripMenuItem appNameMenuItem;
        private ToolStripMenuItem actionMenuItem;
        private ToolStripMenuItem quitMenuItem;
        private Button claimButton;
        private MenuStrip menuStrip;
        private ToolStripMenuItem claimerToolStripMenuItem;
        private ToolStripMenuItem actionToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolTip basicToolTip;
        private GroupBox claimControlsGroupBox;
        private GroupBox infoGroupBox;
        private Button button1;
        private DataGridView resultGridView;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Roll;
        private DataGridViewTextBoxColumn Profit;
        private DataGridViewTextBoxColumn Link;
        private DataGridViewButtonColumn Verify;
    }
}