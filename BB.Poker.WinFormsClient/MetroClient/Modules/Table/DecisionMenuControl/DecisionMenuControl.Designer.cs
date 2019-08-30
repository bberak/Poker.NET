namespace BB.Poker.WinFormsClient
{
    partial class DecisionMenuControl
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
            this.RightButtonGroupPanel = new System.Windows.Forms.Panel();
            this.AllInButton = new BB.Common.WinForms.MetroButton();
            this.CallButton = new BB.Common.WinForms.MetroButton();
            this.CheckButton = new BB.Common.WinForms.MetroButton();
            this.FoldButton = new BB.Common.WinForms.MetroButton();
            this.RaiseButton = new BB.Common.WinForms.MetroButton();
            this.BoundaryPanel = new System.Windows.Forms.Panel();
            this.Canvas.SuspendLayout();
            this.RightButtonGroupPanel.SuspendLayout();
            this.BoundaryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Controls.Add(this.BoundaryPanel);
            this.Canvas.Padding = new System.Windows.Forms.Padding(0);
            this.Canvas.Size = new System.Drawing.Size(470, 140);
            // 
            // TitleButton
            // 
            this.TitleButton.Size = new System.Drawing.Size(470, 32);
            this.TitleButton.Text = "Decision Menu";
            // 
            // RightButtonGroupPanel
            // 
            this.RightButtonGroupPanel.AutoSize = true;
            this.RightButtonGroupPanel.Controls.Add(this.AllInButton);
            this.RightButtonGroupPanel.Controls.Add(this.CallButton);
            this.RightButtonGroupPanel.Controls.Add(this.CheckButton);
            this.RightButtonGroupPanel.Controls.Add(this.FoldButton);
            this.RightButtonGroupPanel.Location = new System.Drawing.Point(93, 0);
            this.RightButtonGroupPanel.Name = "RightButtonGroupPanel";
            this.RightButtonGroupPanel.Size = new System.Drawing.Size(377, 110);
            this.RightButtonGroupPanel.TabIndex = 5;
            // 
            // AllInButton
            // 
            this.AllInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.AllInButton.BorderColor = System.Drawing.Color.White;
            this.AllInButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllInButton.ForeColor = System.Drawing.Color.White;
            this.AllInButton.Location = new System.Drawing.Point(281, 0);
            this.AllInButton.Margin = new System.Windows.Forms.Padding(0);
            this.AllInButton.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.AllInButton.MouseOverBackColor = System.Drawing.Color.Coral;
            this.AllInButton.MouseOverBorderColor = System.Drawing.Color.White;
            this.AllInButton.MouseOverForeColor = System.Drawing.Color.White;
            this.AllInButton.Name = "AllInButton";
            this.AllInButton.Size = new System.Drawing.Size(96, 110);
            this.AllInButton.TabIndex = 4;
            this.AllInButton.TabStop = false;
            this.AllInButton.Text = "All-in";
            this.AllInButton.UseVisualStyleBackColor = false;
            // 
            // CallButton
            // 
            this.CallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.CallButton.BorderColor = System.Drawing.Color.White;
            this.CallButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CallButton.ForeColor = System.Drawing.Color.White;
            this.CallButton.Location = new System.Drawing.Point(187, 0);
            this.CallButton.Margin = new System.Windows.Forms.Padding(0);
            this.CallButton.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.CallButton.MouseOverBackColor = System.Drawing.Color.Coral;
            this.CallButton.MouseOverBorderColor = System.Drawing.Color.White;
            this.CallButton.MouseOverForeColor = System.Drawing.Color.White;
            this.CallButton.Name = "CallButton";
            this.CallButton.Size = new System.Drawing.Size(96, 110);
            this.CallButton.TabIndex = 3;
            this.CallButton.TabStop = false;
            this.CallButton.Text = "Call";
            this.CallButton.UseVisualStyleBackColor = false;
            // 
            // CheckButton
            // 
            this.CheckButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.CheckButton.BorderColor = System.Drawing.Color.White;
            this.CheckButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckButton.ForeColor = System.Drawing.Color.White;
            this.CheckButton.Location = new System.Drawing.Point(93, 0);
            this.CheckButton.Margin = new System.Windows.Forms.Padding(0);
            this.CheckButton.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.CheckButton.MouseOverBackColor = System.Drawing.Color.Coral;
            this.CheckButton.MouseOverBorderColor = System.Drawing.Color.White;
            this.CheckButton.MouseOverForeColor = System.Drawing.Color.White;
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(96, 110);
            this.CheckButton.TabIndex = 2;
            this.CheckButton.TabStop = false;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = false;
            // 
            // FoldButton
            // 
            this.FoldButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.FoldButton.BorderColor = System.Drawing.Color.White;
            this.FoldButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FoldButton.ForeColor = System.Drawing.Color.White;
            this.FoldButton.Location = new System.Drawing.Point(0, 0);
            this.FoldButton.Margin = new System.Windows.Forms.Padding(0);
            this.FoldButton.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.FoldButton.MouseOverBackColor = System.Drawing.Color.Coral;
            this.FoldButton.MouseOverBorderColor = System.Drawing.Color.White;
            this.FoldButton.MouseOverForeColor = System.Drawing.Color.White;
            this.FoldButton.Name = "FoldButton";
            this.FoldButton.Size = new System.Drawing.Size(95, 110);
            this.FoldButton.TabIndex = 1;
            this.FoldButton.TabStop = false;
            this.FoldButton.Text = "Fold";
            this.FoldButton.UseVisualStyleBackColor = false;
            // 
            // RaiseButton
            // 
            this.RaiseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.RaiseButton.BorderColor = System.Drawing.Color.White;
            this.RaiseButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RaiseButton.ForeColor = System.Drawing.Color.White;
            this.RaiseButton.Location = new System.Drawing.Point(0, 0);
            this.RaiseButton.Margin = new System.Windows.Forms.Padding(0);
            this.RaiseButton.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.RaiseButton.MouseOverBackColor = System.Drawing.Color.Coral;
            this.RaiseButton.MouseOverBorderColor = System.Drawing.Color.White;
            this.RaiseButton.MouseOverForeColor = System.Drawing.Color.White;
            this.RaiseButton.Name = "RaiseButton";
            this.RaiseButton.Size = new System.Drawing.Size(95, 110);
            this.RaiseButton.TabIndex = 0;
            this.RaiseButton.TabStop = false;
            this.RaiseButton.Text = "Raise";
            this.RaiseButton.UseVisualStyleBackColor = false;
            // 
            // BoundaryPanel
            // 
            this.BoundaryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BoundaryPanel.Controls.Add(this.RaiseButton);
            this.BoundaryPanel.Controls.Add(this.RightButtonGroupPanel);
            this.BoundaryPanel.Location = new System.Drawing.Point(0, 30);
            this.BoundaryPanel.Name = "BoundaryPanel";
            this.BoundaryPanel.Size = new System.Drawing.Size(468, 110);
            this.BoundaryPanel.TabIndex = 6;
            // 
            // DecisionMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "DecisionMenuControl";
            this.Size = new System.Drawing.Size(470, 140);
            this.Canvas.ResumeLayout(false);
            this.RightButtonGroupPanel.ResumeLayout(false);
            this.BoundaryPanel.ResumeLayout(false);
            this.BoundaryPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BB.Common.WinForms.MetroButton AllInButton;
        private BB.Common.WinForms.MetroButton CallButton;
        private BB.Common.WinForms.MetroButton CheckButton;
        private BB.Common.WinForms.MetroButton FoldButton;
        private BB.Common.WinForms.MetroButton RaiseButton;
        private System.Windows.Forms.Panel RightButtonGroupPanel;
        private System.Windows.Forms.Panel BoundaryPanel;



    }
}
