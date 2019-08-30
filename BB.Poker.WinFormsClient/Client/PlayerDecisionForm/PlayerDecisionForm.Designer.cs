namespace BB.Poker.WinFormsClient
{
    partial class PlayerDecisionForm
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
            this.m_grpOptions = new System.Windows.Forms.GroupBox();
            this.rbtnAllIn = new System.Windows.Forms.RadioButton();
            this.rbtnRaise = new System.Windows.Forms.RadioButton();
            this.rbtnCall = new System.Windows.Forms.RadioButton();
            this.rbtnCheck = new System.Windows.Forms.RadioButton();
            this.rbtnFold = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnDown = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lblPlayerCards = new System.Windows.Forms.Label();
            this.m_nudRaiseAmount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblMinumum = new System.Windows.Forms.Label();
            this.m_grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRaiseAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // m_grpOptions
            // 
            this.m_grpOptions.Controls.Add(this.rbtnAllIn);
            this.m_grpOptions.Controls.Add(this.rbtnRaise);
            this.m_grpOptions.Controls.Add(this.rbtnCall);
            this.m_grpOptions.Controls.Add(this.rbtnCheck);
            this.m_grpOptions.Controls.Add(this.rbtnFold);
            this.m_grpOptions.Location = new System.Drawing.Point(12, 12);
            this.m_grpOptions.Name = "m_grpOptions";
            this.m_grpOptions.Size = new System.Drawing.Size(200, 146);
            this.m_grpOptions.TabIndex = 0;
            this.m_grpOptions.TabStop = false;
            this.m_grpOptions.Text = "Options";
            // 
            // rbtnAllIn
            // 
            this.rbtnAllIn.AutoSize = true;
            this.rbtnAllIn.Location = new System.Drawing.Point(18, 111);
            this.rbtnAllIn.Name = "rbtnAllIn";
            this.rbtnAllIn.Size = new System.Drawing.Size(48, 17);
            this.rbtnAllIn.TabIndex = 4;
            this.rbtnAllIn.TabStop = true;
            this.rbtnAllIn.Tag = "AllIn";
            this.rbtnAllIn.Text = "All In";
            this.rbtnAllIn.UseVisualStyleBackColor = true;
            // 
            // rbtnRaise
            // 
            this.rbtnRaise.AutoSize = true;
            this.rbtnRaise.Location = new System.Drawing.Point(18, 88);
            this.rbtnRaise.Name = "rbtnRaise";
            this.rbtnRaise.Size = new System.Drawing.Size(52, 17);
            this.rbtnRaise.TabIndex = 3;
            this.rbtnRaise.TabStop = true;
            this.rbtnRaise.Tag = "Raise";
            this.rbtnRaise.Text = "Raise";
            this.rbtnRaise.UseVisualStyleBackColor = true;
            this.rbtnRaise.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // rbtnCall
            // 
            this.rbtnCall.AutoSize = true;
            this.rbtnCall.Location = new System.Drawing.Point(18, 65);
            this.rbtnCall.Name = "rbtnCall";
            this.rbtnCall.Size = new System.Drawing.Size(42, 17);
            this.rbtnCall.TabIndex = 2;
            this.rbtnCall.TabStop = true;
            this.rbtnCall.Tag = "Call";
            this.rbtnCall.Text = "Call";
            this.rbtnCall.UseVisualStyleBackColor = true;
            // 
            // rbtnCheck
            // 
            this.rbtnCheck.AutoSize = true;
            this.rbtnCheck.Location = new System.Drawing.Point(18, 42);
            this.rbtnCheck.Name = "rbtnCheck";
            this.rbtnCheck.Size = new System.Drawing.Size(56, 17);
            this.rbtnCheck.TabIndex = 1;
            this.rbtnCheck.TabStop = true;
            this.rbtnCheck.Tag = "Check";
            this.rbtnCheck.Text = "Check";
            this.rbtnCheck.UseVisualStyleBackColor = true;
            // 
            // rbtnFold
            // 
            this.rbtnFold.AutoSize = true;
            this.rbtnFold.Location = new System.Drawing.Point(18, 19);
            this.rbtnFold.Name = "rbtnFold";
            this.rbtnFold.Size = new System.Drawing.Size(45, 17);
            this.rbtnFold.TabIndex = 0;
            this.rbtnFold.TabStop = true;
            this.rbtnFold.Tag = "Fold";
            this.rbtnFold.Text = "Fold";
            this.rbtnFold.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(235, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Raise to";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(406, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "chips.";
            // 
            // m_btnDown
            // 
            this.m_btnDown.Location = new System.Drawing.Point(511, 154);
            this.m_btnDown.Name = "m_btnDown";
            this.m_btnDown.Size = new System.Drawing.Size(75, 23);
            this.m_btnDown.TabIndex = 4;
            this.m_btnDown.Text = "Done";
            this.m_btnDown.UseVisualStyleBackColor = true;
            this.m_btnDown.Click += new System.EventHandler(this.m_btnDown_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(219, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Your Cards:";
            // 
            // m_lblPlayerCards
            // 
            this.m_lblPlayerCards.AutoSize = true;
            this.m_lblPlayerCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblPlayerCards.Location = new System.Drawing.Point(319, 27);
            this.m_lblPlayerCards.Name = "m_lblPlayerCards";
            this.m_lblPlayerCards.Size = new System.Drawing.Size(213, 18);
            this.m_lblPlayerCards.TabIndex = 6;
            this.m_lblPlayerCards.Text = "Ace-Spades, Queen-Hearts";
            // 
            // m_nudRaiseAmount
            // 
            this.m_nudRaiseAmount.Location = new System.Drawing.Point(290, 81);
            this.m_nudRaiseAmount.Name = "m_nudRaiseAmount";
            this.m_nudRaiseAmount.Size = new System.Drawing.Size(108, 20);
            this.m_nudRaiseAmount.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Required Minimum:";
            // 
            // m_lblMinumum
            // 
            this.m_lblMinumum.AutoSize = true;
            this.m_lblMinumum.Location = new System.Drawing.Point(334, 57);
            this.m_lblMinumum.Name = "m_lblMinumum";
            this.m_lblMinumum.Size = new System.Drawing.Size(13, 13);
            this.m_lblMinumum.TabIndex = 9;
            this.m_lblMinumum.Text = "0";
            // 
            // PlayerDecisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 189);
            this.Controls.Add(this.m_lblMinumum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_nudRaiseAmount);
            this.Controls.Add(this.m_lblPlayerCards);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_btnDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_grpOptions);
            this.Name = "PlayerDecisionForm";
            this.Text = "PlayerDecisionForm";
            this.m_grpOptions.ResumeLayout(false);
            this.m_grpOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRaiseAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox m_grpOptions;
        private System.Windows.Forms.RadioButton rbtnRaise;
        private System.Windows.Forms.RadioButton rbtnCall;
        private System.Windows.Forms.RadioButton rbtnCheck;
        private System.Windows.Forms.RadioButton rbtnFold;
        private System.Windows.Forms.RadioButton rbtnAllIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_btnDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label m_lblPlayerCards;
        private System.Windows.Forms.NumericUpDown m_nudRaiseAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label m_lblMinumum;
    }
}