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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            header = new Label();
            autoclaimButton = new Button();
            currentBalanceLabel = new Label();
            currentBalanceValueLabel = new Label();
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            appNameMenuItem = new ToolStripMenuItem();
            actionMenuItem = new ToolStripMenuItem();
            quitMenuItem = new ToolStripMenuItem();
            resultGridView = new DataGridView();
            Time = new DataGridViewTextBoxColumn();
            Roll = new DataGridViewTextBoxColumn();
            Profit = new DataGridViewTextBoxColumn();
            Verify = new DataGridViewTextBoxColumn();
            claimButton = new Button();
            contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resultGridView).BeginInit();
            SuspendLayout();
            // 
            // header
            // 
            header.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            header.Location = new Point(12, 9);
            header.Name = "header";
            header.Size = new Size(324, 21);
            header.TabIndex = 0;
            header.Text = "Freebitcoin Auto Claimer";
            header.TextAlign = ContentAlignment.TopCenter;
            // 
            // autoclaimButton
            // 
            autoclaimButton.Location = new Point(177, 33);
            autoclaimButton.Name = "autoclaimButton";
            autoclaimButton.Size = new Size(159, 23);
            autoclaimButton.TabIndex = 1;
            autoclaimButton.Text = "Start";
            autoclaimButton.UseVisualStyleBackColor = true;
            autoclaimButton.Click += AutoClaimButton_Click;
            // 
            // currentBalanceLabel
            // 
            currentBalanceLabel.Location = new Point(12, 33);
            currentBalanceLabel.Name = "currentBalanceLabel";
            currentBalanceLabel.Size = new Size(159, 23);
            currentBalanceLabel.TabIndex = 2;
            currentBalanceLabel.Text = "Current Balance";
            currentBalanceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // currentBalanceValueLabel
            // 
            currentBalanceValueLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            currentBalanceValueLabel.ForeColor = Color.Black;
            currentBalanceValueLabel.Location = new Point(12, 56);
            currentBalanceValueLabel.Name = "currentBalanceValueLabel";
            currentBalanceValueLabel.Size = new Size(159, 23);
            currentBalanceValueLabel.TabIndex = 3;
            currentBalanceValueLabel.Text = "0.00000000";
            currentBalanceValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipTitle = "FreeBitcoin Claimer";
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipClicked += NotifyIcon_Click;
            notifyIcon.Click += NotifyIcon_Click;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { appNameMenuItem, actionMenuItem, quitMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(178, 70);
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
            // resultGridView
            // 
            resultGridView.AccessibleRole = AccessibleRole.None;
            resultGridView.AllowUserToAddRows = false;
            resultGridView.AllowUserToDeleteRows = false;
            resultGridView.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            resultGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            resultGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultGridView.Columns.AddRange(new DataGridViewColumn[] { Time, Roll, Profit, Verify });
            resultGridView.ImeMode = ImeMode.Off;
            resultGridView.Location = new Point(12, 91);
            resultGridView.MultiSelect = false;
            resultGridView.Name = "resultGridView";
            resultGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            resultGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resultGridView.RowHeadersVisible = false;
            resultGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            resultGridView.RowTemplate.Height = 25;
            resultGridView.ScrollBars = ScrollBars.Vertical;
            resultGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            resultGridView.Size = new Size(324, 167);
            resultGridView.TabIndex = 0;
            // 
            // Time
            // 
            Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Time.HeaderText = "Time";
            Time.Name = "Time";
            Time.ReadOnly = true;
            Time.Resizable = DataGridViewTriState.True;
            // 
            // Roll
            // 
            Roll.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Roll.HeaderText = "Roll";
            Roll.Name = "Roll";
            Roll.ReadOnly = true;
            Roll.Width = 52;
            // 
            // Profit
            // 
            Profit.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Profit.HeaderText = "Profit";
            Profit.Name = "Profit";
            Profit.ReadOnly = true;
            Profit.Width = 61;
            // 
            // Verify
            // 
            Verify.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Verify.HeaderText = "Verify";
            Verify.Name = "Verify";
            Verify.ReadOnly = true;
            // 
            // claimButton
            // 
            claimButton.Location = new Point(177, 62);
            claimButton.Name = "claimButton";
            claimButton.Size = new Size(159, 23);
            claimButton.TabIndex = 4;
            claimButton.Text = "Claim";
            claimButton.UseVisualStyleBackColor = true;
            claimButton.Click += ClaimButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 270);
            Controls.Add(claimButton);
            Controls.Add(resultGridView);
            Controls.Add(currentBalanceValueLabel);
            Controls.Add(currentBalanceLabel);
            Controls.Add(autoclaimButton);
            Controls.Add(header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Resources.icon;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FreeBitcoin Claimer";
            FormClosing += MainForm_FormClosing;
            Resize += MainForm_Resize;
            contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)resultGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label header;
        private Button autoclaimButton;
        private Label currentBalanceLabel;
        private Label currentBalanceValueLabel;
        private NotifyIcon notifyIcon;
        private DataGridView resultGridView;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem appNameMenuItem;
        private ToolStripMenuItem actionMenuItem;
        private ToolStripMenuItem quitMenuItem;
        private Button claimButton;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Roll;
        private DataGridViewTextBoxColumn Profit;
        private DataGridViewTextBoxColumn Verify;
    }
}