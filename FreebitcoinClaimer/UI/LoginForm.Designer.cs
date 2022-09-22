namespace FreebitcoinClaimer.UI
{
    partial class LoginForm
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
            this.emailAddressTextBox = new System.Windows.Forms.TextBox();
            this.header = new System.Windows.Forms.Label();
            this.emailAddressLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.faLabel = new System.Windows.Forms.Label();
            this.faTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.clockLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // emailAddressTextBox
            // 
            this.emailAddressTextBox.Location = new System.Drawing.Point(12, 63);
            this.emailAddressTextBox.Name = "emailAddressTextBox";
            this.emailAddressTextBox.Size = new System.Drawing.Size(253, 23);
            this.emailAddressTextBox.TabIndex = 1;
            // 
            // header
            // 
            this.header.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.header.Location = new System.Drawing.Point(12, 9);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(253, 21);
            this.header.TabIndex = 1;
            this.header.Text = "Login";
            this.header.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // emailAddressLabel
            // 
            this.emailAddressLabel.AutoSize = true;
            this.emailAddressLabel.Location = new System.Drawing.Point(12, 45);
            this.emailAddressLabel.Name = "emailAddressLabel";
            this.emailAddressLabel.Size = new System.Drawing.Size(173, 15);
            this.emailAddressLabel.TabIndex = 2;
            this.emailAddressLabel.Text = "Bitcoin Address/E-mail Address";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 89);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(57, 15);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(12, 107);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(253, 23);
            this.passwordTextBox.TabIndex = 2;
            // 
            // faLabel
            // 
            this.faLabel.AutoSize = true;
            this.faLabel.Location = new System.Drawing.Point(12, 133);
            this.faLabel.Name = "faLabel";
            this.faLabel.Size = new System.Drawing.Size(112, 15);
            this.faLabel.TabIndex = 6;
            this.faLabel.Text = "2FA Code (optional)";
            // 
            // faTextBox
            // 
            this.faTextBox.Location = new System.Drawing.Point(12, 151);
            this.faTextBox.Name = "faTextBox";
            this.faTextBox.Size = new System.Drawing.Size(253, 23);
            this.faTextBox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(12, 190);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(253, 23);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // clockLabel
            // 
            this.clockLabel.AutoSize = true;
            this.clockLabel.Location = new System.Drawing.Point(12, 15);
            this.clockLabel.Name = "clockLabel";
            this.clockLabel.Size = new System.Drawing.Size(34, 15);
            this.clockLabel.TabIndex = 0;
            this.clockLabel.Text = "00:00";
            this.clockLabel.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 227);
            this.Controls.Add(this.clockLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.faLabel);
            this.Controls.Add(this.faTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailAddressLabel);
            this.Controls.Add(this.header);
            this.Controls.Add(this.emailAddressTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::FreebitcoinClaimer.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Freebitcoin Claimer Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox emailAddressTextBox;
        private Label header;
        private Label emailAddressLabel;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Label faLabel;
        private TextBox faTextBox;
        private Button loginButton;
        private Label clockLabel;
    }
}