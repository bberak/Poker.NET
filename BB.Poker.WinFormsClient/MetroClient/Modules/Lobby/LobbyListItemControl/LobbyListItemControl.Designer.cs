namespace BB.Poker.WinFormsClient
{
    partial class LobbyListItemControl
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
            this.BottomBorder = new System.Windows.Forms.Label();
            this.PlayerCountLabel = new BB.Common.WinForms.MetroLabel();
            this.BlindsLabel = new BB.Common.WinForms.MetroLabel();
            this.DescriptionLabel = new BB.Common.WinForms.MetroLabel();
            this.SuspendLayout();
            // 
            // BottomBorder
            // 
            this.BottomBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomBorder.Location = new System.Drawing.Point(0, 32);
            this.BottomBorder.Name = "BottomBorder";
            this.BottomBorder.Size = new System.Drawing.Size(720, 1);
            this.BottomBorder.TabIndex = 0;
            this.BottomBorder.Text = "label1";
            // 
            // PlayerCountLabel
            // 
            this.PlayerCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PlayerCountLabel.Location = new System.Drawing.Point(575, 4);
            this.PlayerCountLabel.Name = "PlayerCountLabel";
            this.PlayerCountLabel.Size = new System.Drawing.Size(125, 24);
            this.PlayerCountLabel.TabIndex = 3;
            this.PlayerCountLabel.Text = "4/9 Players";
            // 
            // BlindsLabel
            // 
            this.BlindsLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BlindsLabel.Location = new System.Drawing.Point(434, 4);
            this.BlindsLabel.Name = "BlindsLabel";
            this.BlindsLabel.Size = new System.Drawing.Size(129, 24);
            this.BlindsLabel.TabIndex = 2;
            this.BlindsLabel.Text = "$300/$600";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLabel.Location = new System.Drawing.Point(3, 4);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(414, 24);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "Description goes here.";
            // 
            // LobbyListItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlayerCountLabel);
            this.Controls.Add(this.BlindsLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.BottomBorder);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LobbyListItemControl";
            this.Size = new System.Drawing.Size(720, 33);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label BottomBorder;
        private BB.Common.WinForms.MetroLabel DescriptionLabel;
        private BB.Common.WinForms.MetroLabel BlindsLabel;
        private BB.Common.WinForms.MetroLabel PlayerCountLabel;
    }
}
