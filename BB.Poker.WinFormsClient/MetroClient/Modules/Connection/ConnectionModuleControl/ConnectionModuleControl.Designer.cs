namespace BB.Poker.WinFormsClient
{
    partial class ConnectionModuleControl
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
            this.StatusLabel = new BB.Common.WinForms.MetroLabel();
            this.ExitButton = new BB.Common.WinForms.MetroButton();
            this.RetryButton = new BB.Common.WinForms.MetroButton();
            this.ConnectionProgressBar = new BB.Common.WinForms.MetroProgressBar();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(120, 225);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(124, 23);
            this.StatusLabel.TabIndex = 1;
            this.StatusLabel.Text = "Connecting..";
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ExitButton.BorderColor = System.Drawing.Color.White;
            this.ExitButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(624, 293);
            this.ExitButton.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.ExitButton.MouseOverBackColor = System.Drawing.Color.Coral;
            this.ExitButton.MouseOverBorderColor = System.Drawing.Color.White;
            this.ExitButton.MouseOverForeColor = System.Drawing.Color.White;
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(105, 37);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Visible = false;
            // 
            // RetryButton
            // 
            this.RetryButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RetryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.RetryButton.BorderColor = System.Drawing.Color.White;
            this.RetryButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetryButton.ForeColor = System.Drawing.Color.White;
            this.RetryButton.Location = new System.Drawing.Point(513, 293);
            this.RetryButton.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.RetryButton.MouseOverBackColor = System.Drawing.Color.Coral;
            this.RetryButton.MouseOverBorderColor = System.Drawing.Color.White;
            this.RetryButton.MouseOverForeColor = System.Drawing.Color.White;
            this.RetryButton.Name = "RetryButton";
            this.RetryButton.Size = new System.Drawing.Size(105, 37);
            this.RetryButton.TabIndex = 3;
            this.RetryButton.TabStop = false;
            this.RetryButton.Text = "Retry";
            this.RetryButton.UseVisualStyleBackColor = false;
            this.RetryButton.Visible = false;
            // 
            // ConnectionProgressBar
            // 
            this.ConnectionProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionProgressBar.BackColor = System.Drawing.Color.White;
            this.ConnectionProgressBar.BarStyle = BB.Common.WinForms.MetroProgressBarStyle.Standard;
            this.ConnectionProgressBar.BorderWidth = 2;
            this.ConnectionProgressBar.Location = new System.Drawing.Point(122, 263);
            this.ConnectionProgressBar.Maximum = 100;
            this.ConnectionProgressBar.Name = "ConnectionProgressBar";
            this.ConnectionProgressBar.Padding = new System.Windows.Forms.Padding(2);
            this.ConnectionProgressBar.Size = new System.Drawing.Size(607, 15);
            this.ConnectionProgressBar.TabIndex = 0;
            this.ConnectionProgressBar.Value = 50;
            // 
            // ConnectionModuleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RetryButton);
            this.Controls.Add(this.ConnectionProgressBar);
            this.Name = "ConnectionModuleControl";
            this.Size = new System.Drawing.Size(850, 566);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BB.Common.WinForms.MetroProgressBar ConnectionProgressBar;
        private BB.Common.WinForms.MetroLabel StatusLabel;
        private BB.Common.WinForms.MetroButton ExitButton;
        private BB.Common.WinForms.MetroButton RetryButton;
    }
}
