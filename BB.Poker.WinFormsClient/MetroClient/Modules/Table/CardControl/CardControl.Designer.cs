namespace BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl
{
    partial class CardControl
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
            this.InnerPanel = new BB.Common.WinForms.MetroPanel();
            this.RankLabel = new BB.Common.WinForms.MetroLabel();
            this.SuitLabel = new BB.Common.WinForms.MetroLabel();
            this.InnerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InnerPanel
            // 
            this.InnerPanel.BorderColor = System.Drawing.Color.White;
            this.InnerPanel.Controls.Add(this.RankLabel);
            this.InnerPanel.Controls.Add(this.SuitLabel);
            this.InnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InnerPanel.Location = new System.Drawing.Point(0, 0);
            this.InnerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.InnerPanel.Name = "InnerPanel";
            this.InnerPanel.Padding = new System.Windows.Forms.Padding(2);
            this.InnerPanel.Size = new System.Drawing.Size(200, 250);
            this.InnerPanel.TabIndex = 0;
            // 
            // RankLabel
            // 
            this.RankLabel.BackColor = System.Drawing.Color.Transparent;
            this.RankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RankLabel.ForeColor = System.Drawing.Color.White;
            this.RankLabel.Location = new System.Drawing.Point(112, 159);
            this.RankLabel.Name = "RankLabel";
            this.RankLabel.ScaleFont = true;
            this.RankLabel.Size = new System.Drawing.Size(83, 89);
            this.RankLabel.TabIndex = 1;
            this.RankLabel.Text = "10";
            this.RankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RankLabel.UseCompatibleTextRendering = true;
            // 
            // SuitLabel
            // 
            this.SuitLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SuitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 86F);
            this.SuitLabel.ForeColor = System.Drawing.Color.White;
            this.SuitLabel.Location = new System.Drawing.Point(2, 2);
            this.SuitLabel.Name = "SuitLabel";
            this.SuitLabel.ScaleFont = true;
            this.SuitLabel.Size = new System.Drawing.Size(192, 242);
            this.SuitLabel.TabIndex = 0;
            this.SuitLabel.Text = "D";
            this.SuitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SuitLabel.UseCompatibleTextRendering = true;
            // 
            // CardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.InnerPanel);
            this.Name = "CardControl";
            this.Size = new System.Drawing.Size(200, 250);
            this.InnerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BB.Common.WinForms.MetroPanel InnerPanel;
        private BB.Common.WinForms.MetroLabel SuitLabel;
        private BB.Common.WinForms.MetroLabel RankLabel;
    }
}
