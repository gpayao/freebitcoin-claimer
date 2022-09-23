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
            this.header = new System.Windows.Forms.Label();
            this.actionButton = new System.Windows.Forms.Button();
            this.currentBalanceLabel = new System.Windows.Forms.Label();
            this.currentBalanceValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.header.Location = new System.Drawing.Point(12, 9);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(192, 21);
            this.header.TabIndex = 0;
            this.header.Text = "Freebitcoin Auto Claimer";
            // 
            // actionButton
            // 
            this.actionButton.Location = new System.Drawing.Point(12, 37);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(192, 23);
            this.actionButton.TabIndex = 1;
            this.actionButton.Text = "Start";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // currentBalanceLabel
            // 
            this.currentBalanceLabel.Location = new System.Drawing.Point(12, 72);
            this.currentBalanceLabel.Name = "currentBalanceLabel";
            this.currentBalanceLabel.Size = new System.Drawing.Size(192, 23);
            this.currentBalanceLabel.TabIndex = 2;
            this.currentBalanceLabel.Text = "Current Balance";
            this.currentBalanceLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // currentBalanceValueLabel
            // 
            this.currentBalanceValueLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentBalanceValueLabel.ForeColor = System.Drawing.Color.Green;
            this.currentBalanceValueLabel.Location = new System.Drawing.Point(12, 95);
            this.currentBalanceValueLabel.Name = "currentBalanceValueLabel";
            this.currentBalanceValueLabel.Size = new System.Drawing.Size(192, 23);
            this.currentBalanceValueLabel.TabIndex = 3;
            this.currentBalanceValueLabel.Text = "0.00000000";
            this.currentBalanceValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 126);
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
            this.ResumeLayout(false);

        }

        #endregion

        private Label header;
        private Button actionButton;
        private Label currentBalanceLabel;
        private Label currentBalanceValueLabel;
    }
}