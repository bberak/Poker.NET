namespace BB.Poker.WinFormsClient
{
    partial class MetroClientForm
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
            this.TitleLabel = new BB.Common.WinForms.MetroLabel();
            this.MyMenu = new BB.Common.WinForms.MetroFlowMenu();
            this.SignOutLabel = new BB.Common.WinForms.MetroLinkLabel();
            this.Canvas.SuspendLayout();
            this.TitleBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.DefaultToolTip.SetToolTip(this.ExitButton, "Close");
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.DefaultToolTip.SetToolTip(this.MinimizeButton, "Minimize");
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Canvas.Controls.Add(this.MyMenu);
            this.Canvas.Size = new System.Drawing.Size(926, 636);
            this.Canvas.Controls.SetChildIndex(this.TitleBarPanel, 0);
            this.Canvas.Controls.SetChildIndex(this.StatusBarPanel, 0);
            this.Canvas.Controls.SetChildIndex(this.MyMenu, 0);
            // 
            // StatusBarPanel
            // 
            this.StatusBarPanel.Location = new System.Drawing.Point(0, 610);
            this.StatusBarPanel.Size = new System.Drawing.Size(926, 26);
            // 
            // TitleBarPanel
            // 
            this.TitleBarPanel.Controls.Add(this.TitleLabel);
            this.TitleBarPanel.Controls.Add(this.SignOutLabel);
            this.TitleBarPanel.Size = new System.Drawing.Size(926, 42);
            this.TitleBarPanel.Controls.SetChildIndex(this.SignOutLabel, 0);
            this.TitleBarPanel.Controls.SetChildIndex(this.TitleLabel, 0);
            // 
            // ToggleFullscreenButton
            // 
            this.DefaultToolTip.SetToolTip(this.ToggleFullscreenButton, "Toggle Fullscreen");
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(13, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(223, 28);
            this.TitleLabel.TabIndex = 5;
            this.TitleLabel.Text = "Poker Game";
            // 
            // MyMenu
            // 
            this.MyMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.MyMenu.Location = new System.Drawing.Point(37, 69);
            this.MyMenu.Margin = new System.Windows.Forms.Padding(0);
            this.MyMenu.Name = "MyMenu";
            this.MyMenu.Size = new System.Drawing.Size(850, 566);
            this.MyMenu.TabIndex = 5;
            // 
            // SignOutLabel
            // 
            this.SignOutLabel.ActiveLinkColor = System.Drawing.Color.Coral;
            this.SignOutLabel.AutoSize = true;
            this.SignOutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.SignOutLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.SignOutLabel.LinkColor = System.Drawing.Color.White;
            this.SignOutLabel.Location = new System.Drawing.Point(13, 9);
            this.SignOutLabel.MinimumSize = new System.Drawing.Size(223, 28);
            this.SignOutLabel.Name = "SignOutLabel";
            this.SignOutLabel.Size = new System.Drawing.Size(223, 28);
            this.SignOutLabel.TabIndex = 6;
            this.SignOutLabel.TabStop = true;
            this.SignOutLabel.Text = "Sign out: Username";
            this.SignOutLabel.VisitedLinkColor = System.Drawing.Color.White;
            this.SignOutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SignOutLabel_LinkClicked);
            // 
            // MetroClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 640);
            this.Name = "MetroClientForm";
            this.Text = "MetroClientForm";
            this.Canvas.ResumeLayout(false);
            this.TitleBarPanel.ResumeLayout(false);
            this.TitleBarPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BB.Common.WinForms.MetroLabel TitleLabel;
        private BB.Common.WinForms.MetroFlowMenu MyMenu;
        private BB.Common.WinForms.MetroLinkLabel SignOutLabel;
    }
}