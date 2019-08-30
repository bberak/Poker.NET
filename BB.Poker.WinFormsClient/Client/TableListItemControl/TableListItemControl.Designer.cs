namespace BB.Poker.WinFormsClient
{
    partial class TableListItemControl
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
            this.PlayerLink = new System.Windows.Forms.LinkLabel();
            this.BlindsLabel = new System.Windows.Forms.Label();
            this.PlayerCountLabel = new System.Windows.Forms.Label();
            this.TableStateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayerLink
            // 
            this.PlayerLink.AutoSize = true;
            this.PlayerLink.Location = new System.Drawing.Point(5, 7);
            this.PlayerLink.Name = "PlayerLink";
            this.PlayerLink.Size = new System.Drawing.Size(53, 13);
            this.PlayerLink.TabIndex = 0;
            this.PlayerLink.TabStop = true;
            this.PlayerLink.Text = "Play Here";
            this.PlayerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PlayerLink_LinkClicked);
            // 
            // BlindsLabel
            // 
            this.BlindsLabel.AutoSize = true;
            this.BlindsLabel.Location = new System.Drawing.Point(82, 7);
            this.BlindsLabel.Name = "BlindsLabel";
            this.BlindsLabel.Size = new System.Drawing.Size(91, 13);
            this.BlindsLabel.TabIndex = 1;
            this.BlindsLabel.Text = "$150/$300 Blinds";
            // 
            // PlayerCountLabel
            // 
            this.PlayerCountLabel.AutoSize = true;
            this.PlayerCountLabel.Location = new System.Drawing.Point(209, 7);
            this.PlayerCountLabel.Name = "PlayerCountLabel";
            this.PlayerCountLabel.Size = new System.Drawing.Size(61, 13);
            this.PlayerCountLabel.TabIndex = 2;
            this.PlayerCountLabel.Text = "2/9 Players";
            // 
            // TableStateLabel
            // 
            this.TableStateLabel.AutoSize = true;
            this.TableStateLabel.Location = new System.Drawing.Point(300, 7);
            this.TableStateLabel.Name = "TableStateLabel";
            this.TableStateLabel.Size = new System.Drawing.Size(81, 13);
            this.TableStateLabel.TabIndex = 3;
            this.TableStateLabel.Text = "AwaitingPlayers";
            // 
            // TableListItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableStateLabel);
            this.Controls.Add(this.PlayerCountLabel);
            this.Controls.Add(this.BlindsLabel);
            this.Controls.Add(this.PlayerLink);
            this.Name = "TableListItemControl";
            this.Size = new System.Drawing.Size(430, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel PlayerLink;
        private System.Windows.Forms.Label BlindsLabel;
        private System.Windows.Forms.Label PlayerCountLabel;
        private System.Windows.Forms.Label TableStateLabel;
    }
}
