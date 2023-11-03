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
            emailAddressTextBox = new TextBox();
            header = new Label();
            emailAddressLabel = new Label();
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            faLabel = new Label();
            faTextBox = new TextBox();
            loginButton = new Button();
            clockLabel = new Label();
            SuspendLayout();
            // 
            // emailAddressTextBox
            // 
            emailAddressTextBox.Location = new Point(12, 63);
            emailAddressTextBox.Name = "emailAddressTextBox";
            emailAddressTextBox.Size = new Size(253, 23);
            emailAddressTextBox.TabIndex = 1;
            // 
            // header
            // 
            header.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            header.Location = new Point(12, 9);
            header.Name = "header";
            header.Size = new Size(253, 21);
            header.TabIndex = 1;
            header.Text = "Login";
            header.TextAlign = ContentAlignment.TopCenter;
            // 
            // emailAddressLabel
            // 
            emailAddressLabel.AutoSize = true;
            emailAddressLabel.Location = new Point(12, 45);
            emailAddressLabel.Name = "emailAddressLabel";
            emailAddressLabel.Size = new Size(173, 15);
            emailAddressLabel.TabIndex = 2;
            emailAddressLabel.Text = "Bitcoin Address/E-mail Address";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(12, 89);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(12, 107);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(253, 23);
            passwordTextBox.TabIndex = 2;
            // 
            // faLabel
            // 
            faLabel.AutoSize = true;
            faLabel.Location = new Point(12, 133);
            faLabel.Name = "faLabel";
            faLabel.Size = new Size(112, 15);
            faLabel.TabIndex = 6;
            faLabel.Text = "2FA Code (optional)";
            // 
            // faTextBox
            // 
            faTextBox.Location = new Point(12, 151);
            faTextBox.Name = "faTextBox";
            faTextBox.Size = new Size(253, 23);
            faTextBox.TabIndex = 3;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(12, 190);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(253, 23);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += LoginButton_Click;
            // 
            // clockLabel
            // 
            clockLabel.AutoSize = true;
            clockLabel.Location = new Point(12, 15);
            clockLabel.Name = "clockLabel";
            clockLabel.Size = new Size(34, 15);
            clockLabel.TabIndex = 0;
            clockLabel.Text = "00:00";
            clockLabel.Visible = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 227);
            Controls.Add(clockLabel);
            Controls.Add(loginButton);
            Controls.Add(faLabel);
            Controls.Add(faTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(emailAddressLabel);
            Controls.Add(header);
            Controls.Add(emailAddressTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Resources.icon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Freebitco.in Claimer Login";
            FormClosing += LoginForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
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