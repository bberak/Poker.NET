namespace BB.Poker.WinFormsClient
{
    partial class MetroMessageBoxForm
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
            this.BottomDivider = new System.Windows.Forms.Label();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.TopDivider = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.OkButton = new BB.Common.WinForms.MetroButton();
            this.Canvas.SuspendLayout();
            this.MessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.MouseOverBackColor = System.Drawing.Color.Black;
            this.ExitButton.MouseOverForeColor = System.Drawing.Color.LightSkyBlue;
            this.ExitButton.UseVisualStyleBackColor = false;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Visible = false;
            // 
            // ResizeButton
            // 
            this.ResizeButton.Visible = false;
            // 
            // Canvas
            // 
            this.Canvas.Controls.Add(this.OkButton);
            this.Canvas.Controls.Add(this.MessagePanel);
            this.Canvas.Size = new System.Drawing.Size(414, 296);
            this.Canvas.Controls.SetChildIndex(this.TitleBarPanel, 0);
            this.Canvas.Controls.SetChildIndex(this.StatusBarPanel, 0);
            this.Canvas.Controls.SetChildIndex(this.MessagePanel, 0);
            this.Canvas.Controls.SetChildIndex(this.OkButton, 0);
            // 
            // StatusBarPanel
            // 
            this.StatusBarPanel.BackColor = System.Drawing.Color.Silver;
            this.StatusBarPanel.Location = new System.Drawing.Point(0, 270);
            this.StatusBarPanel.Size = new System.Drawing.Size(414, 26);
            // 
            // TitleBarPanel
            // 
            this.TitleBarPanel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.TitleBarPanel.Size = new System.Drawing.Size(414, 42);
            // 
            // BottomDivider
            // 
            this.BottomDivider.BackColor = System.Drawing.Color.Black;
            this.BottomDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomDivider.Location = new System.Drawing.Point(0, 190);
            this.BottomDivider.Name = "BottomDivider";
            this.BottomDivider.Size = new System.Drawing.Size(414, 2);
            this.BottomDivider.TabIndex = 5;
            // 
            // MessagePanel
            // 
            this.MessagePanel.Controls.Add(this.TopDivider);
            this.MessagePanel.Controls.Add(this.MessageLabel);
            this.MessagePanel.Controls.Add(this.BottomDivider);
            this.MessagePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessagePanel.Location = new System.Drawing.Point(0, 42);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(414, 192);
            this.MessagePanel.TabIndex = 6;
            // 
            // TopDivider
            // 
            this.TopDivider.BackColor = System.Drawing.Color.Black;
            this.TopDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopDivider.Location = new System.Drawing.Point(0, 0);
            this.TopDivider.Name = "TopDivider";
            this.TopDivider.Size = new System.Drawing.Size(414, 2);
            this.TopDivider.TabIndex = 7;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(28, 16);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(373, 161);
            this.MessageLabel.TabIndex = 6;
            this.MessageLabel.Text = "Message goes here.";
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.Location = new System.Drawing.Point(155, 250);
            this.OkButton.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(105, 30);
            this.OkButton.TabIndex = 7;
            this.OkButton.TabStop = false;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // MetroMessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 300);
            this.Name = "MetroMessageBoxForm";
            this.Text = "MetroMessageBox";
            this.Canvas.ResumeLayout(false);
            this.MessagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label BottomDivider;
        private BB.Common.WinForms.MetroButton OkButton;
        private System.Windows.Forms.Panel MessagePanel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label TopDivider;
    }
}