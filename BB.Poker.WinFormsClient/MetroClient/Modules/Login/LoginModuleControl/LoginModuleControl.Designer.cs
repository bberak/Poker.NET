namespace BB.Poker.WinFormsClient
{
    partial class LoginModuleControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new BB.Common.WinForms.MetroLabel();
            this.PasswordTextBox = new BB.Common.WinForms.MetroTextBox();
            this.UsernameTextBox = new BB.Common.WinForms.MetroTextBox();
            this.StatusLabel = new BB.Common.WinForms.MetroLabel();
            this.SignInButton = new BB.Common.WinForms.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroLabel1.ForeColor = System.Drawing.Color.White;
            this.metroLabel1.Location = new System.Drawing.Point(262, 145);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(243, 23);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Sign in to Poker Reloaded";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.PasswordTextBox.BorderColor = System.Drawing.Color.White;
            this.PasswordTextBox.LeftIndent = 6;
            this.PasswordTextBox.Location = new System.Drawing.Point(267, 248);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '\0';
            this.PasswordTextBox.Size = new System.Drawing.Size(312, 39);
            this.PasswordTextBox.TabIndex = 5;
            this.PasswordTextBox.Text = "Password";
            this.PasswordTextBox.TopIndent = 5;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.UsernameTextBox.BorderColor = System.Drawing.Color.White;
            this.UsernameTextBox.LeftIndent = 6;
            this.UsernameTextBox.Location = new System.Drawing.Point(267, 183);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.PasswordChar = '\0';
            this.UsernameTextBox.Size = new System.Drawing.Size(312, 39);
            this.UsernameTextBox.TabIndex = 4;
            this.UsernameTextBox.Text = "Username";
            this.UsernameTextBox.TopIndent = 5;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(378, 311);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 23);
            this.StatusLabel.TabIndex = 1;
            // 
            // SignInButton
            // 
            this.SignInButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SignInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.SignInButton.BorderColor = System.Drawing.Color.White;
            this.SignInButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignInButton.ForeColor = System.Drawing.Color.White;
            this.SignInButton.Location = new System.Drawing.Point(267, 304);
            this.SignInButton.Margin = new System.Windows.Forms.Padding(0);
            this.SignInButton.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.SignInButton.MouseOverBackColor = System.Drawing.Color.Coral;
            this.SignInButton.MouseOverBorderColor = System.Drawing.Color.White;
            this.SignInButton.MouseOverForeColor = System.Drawing.Color.White;
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(105, 37);
            this.SignInButton.TabIndex = 3;
            this.SignInButton.TabStop = false;
            this.SignInButton.Text = "Sign in";
            this.SignInButton.UseVisualStyleBackColor = false;
            // 
            // LoginModuleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.SignInButton);
            this.Name = "LoginModuleControl";
            this.Size = new System.Drawing.Size(850, 566);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BB.Common.WinForms.MetroLabel StatusLabel;
        private BB.Common.WinForms.MetroButton SignInButton;
        private BB.Common.WinForms.MetroTextBox UsernameTextBox;
        private BB.Common.WinForms.MetroTextBox PasswordTextBox;
        private BB.Common.WinForms.MetroLabel metroLabel1;
    }
}
