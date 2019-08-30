namespace BB.Poker.WinFormsClient
{
    partial class PlayerControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblChips = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lblStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblOtherInfo = new System.Windows.Forms.Label();
            this.m_lblSeatPosition = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lblYourCards = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // m_lblName
            // 
            this.m_lblName.AutoSize = true;
            this.m_lblName.Location = new System.Drawing.Point(57, 14);
            this.m_lblName.Name = "m_lblName";
            this.m_lblName.Size = new System.Drawing.Size(53, 13);
            this.m_lblName.TabIndex = 1;
            this.m_lblName.Text = "John Doe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chips:";
            // 
            // m_lblChips
            // 
            this.m_lblChips.AutoSize = true;
            this.m_lblChips.Location = new System.Drawing.Point(58, 35);
            this.m_lblChips.Name = "m_lblChips";
            this.m_lblChips.Size = new System.Drawing.Size(31, 13);
            this.m_lblChips.TabIndex = 3;
            this.m_lblChips.Text = "3000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status:";
            // 
            // m_lblStatus
            // 
            this.m_lblStatus.AutoSize = true;
            this.m_lblStatus.Location = new System.Drawing.Point(61, 54);
            this.m_lblStatus.Name = "m_lblStatus";
            this.m_lblStatus.Size = new System.Drawing.Size(43, 13);
            this.m_lblStatus.TabIndex = 5;
            this.m_lblStatus.Text = "Waiting";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Other:";
            // 
            // m_lblOtherInfo
            // 
            this.m_lblOtherInfo.AutoSize = true;
            this.m_lblOtherInfo.Location = new System.Drawing.Point(61, 73);
            this.m_lblOtherInfo.Name = "m_lblOtherInfo";
            this.m_lblOtherInfo.Size = new System.Drawing.Size(58, 13);
            this.m_lblOtherInfo.TabIndex = 7;
            this.m_lblOtherInfo.Text = "Small Blind";
            // 
            // m_lblSeatPosition
            // 
            this.m_lblSeatPosition.AutoSize = true;
            this.m_lblSeatPosition.Location = new System.Drawing.Point(60, 92);
            this.m_lblSeatPosition.Name = "m_lblSeatPosition";
            this.m_lblSeatPosition.Size = new System.Drawing.Size(13, 13);
            this.m_lblSeatPosition.TabIndex = 9;
            this.m_lblSeatPosition.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Seat:";
            // 
            // m_lblYourCards
            // 
            this.m_lblYourCards.AutoSize = true;
            this.m_lblYourCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblYourCards.Location = new System.Drawing.Point(155, 11);
            this.m_lblYourCards.Name = "m_lblYourCards";
            this.m_lblYourCards.Size = new System.Drawing.Size(191, 18);
            this.m_lblYourCards.TabIndex = 11;
            this.m_lblYourCards.Text = "Your Cards: Unassigned";
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_lblYourCards);
            this.Controls.Add(this.m_lblSeatPosition);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_lblOtherInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_lblChips);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_lblName);
            this.Controls.Add(this.label1);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(382, 123);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_lblChips;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label m_lblStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label m_lblOtherInfo;
        private System.Windows.Forms.Label m_lblSeatPosition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label m_lblYourCards;
    }
}
