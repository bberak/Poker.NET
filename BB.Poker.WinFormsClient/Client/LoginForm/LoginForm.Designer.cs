namespace BB.Poker.WinFormsClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.m_txtPassword = new System.Windows.Forms.TextBox();
            this.m_btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // m_txtName
            // 
            this.m_txtName.Location = new System.Drawing.Point(79, 12);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(155, 20);
            this.m_txtName.TabIndex = 2;
            // 
            // m_txtPassword
            // 
            this.m_txtPassword.Location = new System.Drawing.Point(79, 38);
            this.m_txtPassword.Name = "m_txtPassword";
            this.m_txtPassword.Size = new System.Drawing.Size(155, 20);
            this.m_txtPassword.TabIndex = 3;
            this.m_txtPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // m_btnLogin
            // 
            this.m_btnLogin.Location = new System.Drawing.Point(159, 64);
            this.m_btnLogin.Name = "m_btnLogin";
            this.m_btnLogin.Size = new System.Drawing.Size(75, 23);
            this.m_btnLogin.TabIndex = 4;
            this.m_btnLogin.Text = "Login";
            this.m_btnLogin.UseVisualStyleBackColor = true;
            this.m_btnLogin.Click += new System.EventHandler(this.m_btnLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 95);
            this.Controls.Add(this.m_btnLogin);
            this.Controls.Add(this.m_txtPassword);
            this.Controls.Add(this.m_txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "Pizarro Poker Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtName;
        private System.Windows.Forms.TextBox m_txtPassword;
        private System.Windows.Forms.Button m_btnLogin;
    }
}