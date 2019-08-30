namespace BB.Poker.WinFormsClient
{
    partial class VerifyClientModuleControl
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
            this.UpdateButton = new BB.Common.WinForms.MetroButton();
            this.ProgressBar = new BB.Common.WinForms.MetroProgressBar();
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
            this.StatusLabel.Size = new System.Drawing.Size(298, 23);
            this.StatusLabel.TabIndex = 1;
            this.StatusLabel.Text = "Checking for software updates..";
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
            // UpdateButton
            // 
            this.UpdateButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.UpdateButton.BorderColor = System.Drawing.Color.White;
            this.UpdateButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.Location = new System.Drawing.Point(513, 293);
            this.UpdateButton.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.UpdateButton.MouseOverBackColor = System.Drawing.Color.Coral;
            this.UpdateButton.MouseOverBorderColor = System.Drawing.Color.White;
            this.UpdateButton.MouseOverForeColor = System.Drawing.Color.White;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(105, 37);
            this.UpdateButton.TabIndex = 3;
            this.UpdateButton.TabStop = false;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Visible = false;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.BackColor = System.Drawing.Color.White;
            this.ProgressBar.BarStyle = BB.Common.WinForms.MetroProgressBarStyle.Standard;
            this.ProgressBar.BorderWidth = 2;
            this.ProgressBar.Location = new System.Drawing.Point(122, 263);
            this.ProgressBar.Maximum = 100;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Padding = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Size = new System.Drawing.Size(607, 15);
            this.ProgressBar.TabIndex = 0;
            this.ProgressBar.Value = 50;
            // 
            // VerifyClientModuleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.ProgressBar);
            this.Name = "VerifyClientModuleControl";
            this.Size = new System.Drawing.Size(850, 566);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BB.Common.WinForms.MetroProgressBar ProgressBar;
        private BB.Common.WinForms.MetroLabel StatusLabel;
        private BB.Common.WinForms.MetroButton ExitButton;
        private BB.Common.WinForms.MetroButton UpdateButton;
    }
}
