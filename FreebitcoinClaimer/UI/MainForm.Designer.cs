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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.header = new System.Windows.Forms.Label();
            this.actionButton = new System.Windows.Forms.Button();
            this.currentBalanceLabel = new System.Windows.Forms.Label();
            this.currentBalanceValueLabel = new System.Windows.Forms.Label();
            this.initialBalanceLabel = new System.Windows.Forms.Label();
            this.initialBalanceValueLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.appNameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultGridView = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Roll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.header.Location = new System.Drawing.Point(12, 9);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(324, 21);
            this.header.TabIndex = 0;
            this.header.Text = "Freebitcoin Auto Claimer";
            this.header.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // actionButton
            // 
            this.actionButton.Location = new System.Drawing.Point(12, 106);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(324, 23);
            this.actionButton.TabIndex = 1;
            this.actionButton.Text = "Start";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // currentBalanceLabel
            // 
            this.currentBalanceLabel.Location = new System.Drawing.Point(177, 43);
            this.currentBalanceLabel.Name = "currentBalanceLabel";
            this.currentBalanceLabel.Size = new System.Drawing.Size(159, 23);
            this.currentBalanceLabel.TabIndex = 2;
            this.currentBalanceLabel.Text = "Current Balance";
            this.currentBalanceLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // currentBalanceValueLabel
            // 
            this.currentBalanceValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentBalanceValueLabel.ForeColor = System.Drawing.Color.Black;
            this.currentBalanceValueLabel.Location = new System.Drawing.Point(177, 66);
            this.currentBalanceValueLabel.Name = "currentBalanceValueLabel";
            this.currentBalanceValueLabel.Size = new System.Drawing.Size(159, 23);
            this.currentBalanceValueLabel.TabIndex = 3;
            this.currentBalanceValueLabel.Text = "0.00000000";
            this.currentBalanceValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // initialBalanceLabel
            // 
            this.initialBalanceLabel.Location = new System.Drawing.Point(12, 43);
            this.initialBalanceLabel.Name = "initialBalanceLabel";
            this.initialBalanceLabel.Size = new System.Drawing.Size(159, 23);
            this.initialBalanceLabel.TabIndex = 4;
            this.initialBalanceLabel.Text = "Initial Balance";
            this.initialBalanceLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // initialBalanceValueLabel
            // 
            this.initialBalanceValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.initialBalanceValueLabel.ForeColor = System.Drawing.Color.Black;
            this.initialBalanceValueLabel.Location = new System.Drawing.Point(12, 66);
            this.initialBalanceValueLabel.Name = "initialBalanceValueLabel";
            this.initialBalanceValueLabel.Size = new System.Drawing.Size(159, 23);
            this.initialBalanceValueLabel.TabIndex = 5;
            this.initialBalanceValueLabel.Text = "0.00000000";
            this.initialBalanceValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipTitle = "FreeBitcoin Claimer";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.NotifyIcon_Click);
            this.notifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appNameMenuItem,
            this.actionMenuItem,
            this.quitMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(178, 70);
            // 
            // appNameMenuItem
            // 
            this.appNameMenuItem.Enabled = false;
            this.appNameMenuItem.Name = "appNameMenuItem";
            this.appNameMenuItem.Size = new System.Drawing.Size(177, 22);
            this.appNameMenuItem.Text = "FreeBitcoin Claimer";
            // 
            // actionMenuItem
            // 
            this.actionMenuItem.Name = "actionMenuItem";
            this.actionMenuItem.Size = new System.Drawing.Size(177, 22);
            this.actionMenuItem.Text = "Start";
            this.actionMenuItem.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.Size = new System.Drawing.Size(177, 22);
            this.quitMenuItem.Text = "Quit";
            this.quitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // resultGridView
            // 
            this.resultGridView.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.resultGridView.AllowUserToAddRows = false;
            this.resultGridView.AllowUserToDeleteRows = false;
            this.resultGridView.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.resultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Roll,
            this.Profit});
            this.resultGridView.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.resultGridView.Location = new System.Drawing.Point(12, 135);
            this.resultGridView.MultiSelect = false;
            this.resultGridView.Name = "resultGridView";
            this.resultGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.resultGridView.RowHeadersVisible = false;
            this.resultGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.resultGridView.RowTemplate.Height = 25;
            this.resultGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultGridView.Size = new System.Drawing.Size(324, 183);
            this.resultGridView.TabIndex = 0;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 107;
            // 
            // Roll
            // 
            this.Roll.HeaderText = "Roll";
            this.Roll.Name = "Roll";
            this.Roll.ReadOnly = true;
            this.Roll.Width = 107;
            // 
            // Profit
            // 
            this.Profit.HeaderText = "Profit";
            this.Profit.Name = "Profit";
            this.Profit.ReadOnly = true;
            this.Profit.Width = 107;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 330);
            this.Controls.Add(this.resultGridView);
            this.Controls.Add(this.initialBalanceValueLabel);
            this.Controls.Add(this.initialBalanceLabel);
            this.Controls.Add(this.currentBalanceValueLabel);
            this.Controls.Add(this.currentBalanceLabel);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::FreebitcoinClaimer.Resources.icon;
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FreeBitcoin Claimer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label header;
        private Button actionButton;
        private Label currentBalanceLabel;
        private Label currentBalanceValueLabel;
        private Label initialBalanceLabel;
        private Label initialBalanceValueLabel;
        private NotifyIcon notifyIcon;
        private DataGridView resultGridView;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Roll;
        private DataGridViewTextBoxColumn Profit;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem appNameMenuItem;
        private ToolStripMenuItem quitMenuItem;
        private ToolStripMenuItem actionMenuItem;
    }
}