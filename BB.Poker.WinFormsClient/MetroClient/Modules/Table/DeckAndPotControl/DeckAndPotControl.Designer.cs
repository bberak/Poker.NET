namespace BB.Poker.WinFormsClient
{
    partial class DeckAndPotControl
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
            this.TableFeedbackLabel = new BB.Common.WinForms.MetroLabel();
            this.PotValueLabel = new BB.Common.WinForms.MetroLabel();
            this.Card5 = new BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl();
            this.Card4 = new BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl();
            this.Card3 = new BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl();
            this.Card2 = new BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl();
            this.Card1 = new BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl();
            this.InnerPanel = new System.Windows.Forms.Panel();
            this.InnerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableFeedbackLabel
            // 
            this.TableFeedbackLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableFeedbackLabel.ForeColor = System.Drawing.Color.White;
            this.TableFeedbackLabel.Location = new System.Drawing.Point(0, 88);
            this.TableFeedbackLabel.Name = "TableFeedbackLabel";
            this.TableFeedbackLabel.Size = new System.Drawing.Size(491, 28);
            this.TableFeedbackLabel.TabIndex = 33;
            this.TableFeedbackLabel.Text = "Lord British wins with a Full House";
            this.TableFeedbackLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PotValueLabel
            // 
            this.PotValueLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PotValueLabel.ForeColor = System.Drawing.Color.White;
            this.PotValueLabel.Location = new System.Drawing.Point(326, 27);
            this.PotValueLabel.Name = "PotValueLabel";
            this.PotValueLabel.Size = new System.Drawing.Size(165, 28);
            this.PotValueLabel.TabIndex = 32;
            this.PotValueLabel.Text = "$2,200";
            this.PotValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Card5
            // 
            this.Card5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Card5.Location = new System.Drawing.Point(266, 0);
            this.Card5.Margin = new System.Windows.Forms.Padding(0);
            this.Card5.Name = "Card5";
            this.Card5.Size = new System.Drawing.Size(57, 78);
            this.Card5.TabIndex = 31;
            // 
            // Card4
            // 
            this.Card4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Card4.Location = new System.Drawing.Point(199, 0);
            this.Card4.Margin = new System.Windows.Forms.Padding(0);
            this.Card4.Name = "Card4";
            this.Card4.Size = new System.Drawing.Size(57, 78);
            this.Card4.TabIndex = 30;
            // 
            // Card3
            // 
            this.Card3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Card3.Location = new System.Drawing.Point(132, 0);
            this.Card3.Margin = new System.Windows.Forms.Padding(0);
            this.Card3.Name = "Card3";
            this.Card3.Size = new System.Drawing.Size(57, 78);
            this.Card3.TabIndex = 29;
            // 
            // Card2
            // 
            this.Card2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Card2.Location = new System.Drawing.Point(66, 0);
            this.Card2.Margin = new System.Windows.Forms.Padding(0);
            this.Card2.Name = "Card2";
            this.Card2.Size = new System.Drawing.Size(57, 78);
            this.Card2.TabIndex = 28;
            // 
            // Card1
            // 
            this.Card1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Card1.Location = new System.Drawing.Point(0, 0);
            this.Card1.Margin = new System.Windows.Forms.Padding(0);
            this.Card1.Name = "Card1";
            this.Card1.Size = new System.Drawing.Size(57, 78);
            this.Card1.TabIndex = 27;
            // 
            // InnerPanel
            // 
            this.InnerPanel.Controls.Add(this.Card1);
            this.InnerPanel.Controls.Add(this.TableFeedbackLabel);
            this.InnerPanel.Controls.Add(this.Card2);
            this.InnerPanel.Controls.Add(this.PotValueLabel);
            this.InnerPanel.Controls.Add(this.Card3);
            this.InnerPanel.Controls.Add(this.Card5);
            this.InnerPanel.Controls.Add(this.Card4);
            this.InnerPanel.Location = new System.Drawing.Point(0, 0);
            this.InnerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.InnerPanel.Name = "InnerPanel";
            this.InnerPanel.Size = new System.Drawing.Size(494, 120);
            this.InnerPanel.TabIndex = 34;
            // 
            // DeckAndPotControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.InnerPanel);
            this.MinimumSize = new System.Drawing.Size(494, 120);
            this.Name = "DeckAndPotControl";
            this.Size = new System.Drawing.Size(494, 120);
            this.InnerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BB.Common.WinForms.MetroLabel TableFeedbackLabel;
        private BB.Common.WinForms.MetroLabel PotValueLabel;
        private BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl Card5;
        private BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl Card4;
        private BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl Card3;
        private BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl Card2;
        private BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl Card1;
        private System.Windows.Forms.Panel InnerPanel;
    }
}
