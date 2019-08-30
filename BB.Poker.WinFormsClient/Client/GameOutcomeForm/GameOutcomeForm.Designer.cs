namespace BB.Poker.WinFormsClient
{
    partial class GameOutcomeForm
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
            this.m_btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblWinners = new System.Windows.Forms.Label();
            this.m_lblLosers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_btnClose
            // 
            this.m_btnClose.Location = new System.Drawing.Point(501, 333);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Size = new System.Drawing.Size(75, 23);
            this.m_btnClose.TabIndex = 2;
            this.m_btnClose.Text = "Cool";
            this.m_btnClose.UseVisualStyleBackColor = true;
            this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Winners:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Losers";
            // 
            // m_lblWinners
            // 
            this.m_lblWinners.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblWinners.Location = new System.Drawing.Point(16, 30);
            this.m_lblWinners.Name = "m_lblWinners";
            this.m_lblWinners.Size = new System.Drawing.Size(560, 100);
            this.m_lblWinners.TabIndex = 5;
            this.m_lblWinners.Text = "label3";
            // 
            // m_lblLosers
            // 
            this.m_lblLosers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblLosers.Location = new System.Drawing.Point(16, 212);
            this.m_lblLosers.Name = "m_lblLosers";
            this.m_lblLosers.Size = new System.Drawing.Size(560, 100);
            this.m_lblLosers.TabIndex = 6;
            this.m_lblLosers.Text = "label3";
            // 
            // GameOutcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 368);
            this.Controls.Add(this.m_lblLosers);
            this.Controls.Add(this.m_lblWinners);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnClose);
            this.Name = "GameOutcomeForm";
            this.Text = "GameOutcomeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_lblWinners;
        private System.Windows.Forms.Label m_lblLosers;
    }
}