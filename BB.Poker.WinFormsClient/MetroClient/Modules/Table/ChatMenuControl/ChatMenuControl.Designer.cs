namespace BB.Poker.WinFormsClient
{
    partial class ChatMenuControl
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
            this.ScrollPanel = new System.Windows.Forms.Panel();
            this.MessagesLabel = new BB.Common.WinForms.MetroLabel();
            this.MessageTextBox = new BB.Common.WinForms.MetroTextBox();
            this.Canvas.SuspendLayout();
            this.ScrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InnerPanel
            // 
            this.Canvas.Controls.Add(this.MessageTextBox);
            this.Canvas.Controls.Add(this.ScrollPanel);
            this.Canvas.Size = new System.Drawing.Size(188, 246);
            // 
            // TitleButton
            // 
            this.TitleButton.Size = new System.Drawing.Size(188, 32);
            this.TitleButton.Text = "Chat";
            // 
            // ScrollPanel
            // 
            this.ScrollPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollPanel.Controls.Add(this.MessagesLabel);
            this.ScrollPanel.Location = new System.Drawing.Point(2, 32);
            this.ScrollPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ScrollPanel.Name = "ScrollPanel";
            this.ScrollPanel.Size = new System.Drawing.Size(184, 181);
            this.ScrollPanel.TabIndex = 1;
            // 
            // MessagesLabel
            // 
            this.MessagesLabel.AutoSize = true;
            this.MessagesLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessagesLabel.ForeColor = System.Drawing.Color.White;
            this.MessagesLabel.Location = new System.Drawing.Point(0, 0);
            this.MessagesLabel.MaximumSize = new System.Drawing.Size(166, 0);
            this.MessagesLabel.Name = "MessagesLabel";
            this.MessagesLabel.Size = new System.Drawing.Size(114, 16);
            this.MessagesLabel.TabIndex = 1;
            this.MessagesLabel.Text = "Table: Welcome";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.MessageTextBox.BorderColor = System.Drawing.Color.White;
            this.MessageTextBox.LeftIndent = 6;
            this.MessageTextBox.Location = new System.Drawing.Point(0, 213);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.PasswordChar = '\0';
            this.MessageTextBox.Size = new System.Drawing.Size(188, 33);
            this.MessageTextBox.TabIndex = 2;
            this.MessageTextBox.Text = "Type your message here";
            this.MessageTextBox.TextBoxFont = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageTextBox.TopIndent = 7;
            // 
            // ChatMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ChatMenuControl";
            this.Size = new System.Drawing.Size(188, 246);
            this.Canvas.ResumeLayout(false);
            this.ScrollPanel.ResumeLayout(false);
            this.ScrollPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ScrollPanel;
        private BB.Common.WinForms.MetroTextBox MessageTextBox;
        private BB.Common.WinForms.MetroLabel MessagesLabel;
    }
}
