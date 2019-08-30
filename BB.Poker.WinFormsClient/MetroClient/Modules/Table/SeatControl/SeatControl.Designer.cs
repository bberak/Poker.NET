namespace BB.Poker.WinFormsClient
{
    partial class SeatControl
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
            this.AvatarPanel = new BB.Common.WinForms.MetroPanel();
            this.Card2 = new BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl();
            this.Card1 = new BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl();
            this.NamePanel = new BB.Common.WinForms.MetroPanel();
            this.NameLabel = new BB.Common.WinForms.MetroLabel();
            this.ChipsPanel = new BB.Common.WinForms.MetroPanel();
            this.ChipsLabel = new BB.Common.WinForms.MetroLabel();
            this.TimerProgressBar = new BB.Common.WinForms.MetroProgressBar();
            this.AvatarPanel.SuspendLayout();
            this.NamePanel.SuspendLayout();
            this.ChipsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvatarPanel
            // 
            this.AvatarPanel.BorderColor = System.Drawing.Color.White;
            this.AvatarPanel.Controls.Add(this.Card2);
            this.AvatarPanel.Controls.Add(this.Card1);
            this.AvatarPanel.Location = new System.Drawing.Point(10, 24);
            this.AvatarPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AvatarPanel.Name = "AvatarPanel";
            this.AvatarPanel.Padding = new System.Windows.Forms.Padding(2);
            this.AvatarPanel.Size = new System.Drawing.Size(110, 78);
            this.AvatarPanel.TabIndex = 0;
            // 
            // Card2
            // 
            this.Card2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Card2.Location = new System.Drawing.Point(54, 0);
            this.Card2.Margin = new System.Windows.Forms.Padding(0);
            this.Card2.Name = "Card2";
            this.Card2.Size = new System.Drawing.Size(56, 78);
            this.Card2.TabIndex = 1;
            this.Card2.Visible = false;
            // 
            // Card1
            // 
            this.Card1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Card1.Location = new System.Drawing.Point(0, 0);
            this.Card1.Margin = new System.Windows.Forms.Padding(0);
            this.Card1.Name = "Card1";
            this.Card1.Size = new System.Drawing.Size(56, 78);
            this.Card1.TabIndex = 0;
            this.Card1.Visible = false;
            // 
            // NamePanel
            // 
            this.NamePanel.BorderColor = System.Drawing.Color.White;
            this.NamePanel.Controls.Add(this.NameLabel);
            this.NamePanel.Location = new System.Drawing.Point(0, 0);
            this.NamePanel.Margin = new System.Windows.Forms.Padding(0);
            this.NamePanel.Name = "NamePanel";
            this.NamePanel.Padding = new System.Windows.Forms.Padding(2);
            this.NamePanel.Size = new System.Drawing.Size(130, 26);
            this.NamePanel.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(2, 2);
            this.NameLabel.MaximumFontSize = 10F;
            this.NameLabel.MinimumFontSize = 5F;
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.ScaleFont = true;
            this.NameLabel.Size = new System.Drawing.Size(126, 22);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Empty Seat";
            // 
            // ChipsPanel
            // 
            this.ChipsPanel.BorderColor = System.Drawing.Color.White;
            this.ChipsPanel.Controls.Add(this.ChipsLabel);
            this.ChipsPanel.Location = new System.Drawing.Point(10, 100);
            this.ChipsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ChipsPanel.Name = "ChipsPanel";
            this.ChipsPanel.Padding = new System.Windows.Forms.Padding(2);
            this.ChipsPanel.Size = new System.Drawing.Size(110, 22);
            this.ChipsPanel.TabIndex = 2;
            // 
            // ChipsLabel
            // 
            this.ChipsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChipsLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChipsLabel.ForeColor = System.Drawing.Color.White;
            this.ChipsLabel.Location = new System.Drawing.Point(2, 2);
            this.ChipsLabel.MaximumFontSize = 10F;
            this.ChipsLabel.MinimumFontSize = 5F;
            this.ChipsLabel.Name = "ChipsLabel";
            this.ChipsLabel.ScaleFont = true;
            this.ChipsLabel.Size = new System.Drawing.Size(106, 18);
            this.ChipsLabel.TabIndex = 0;
            this.ChipsLabel.Text = "0";
            // 
            // TimerProgressBar
            // 
            this.TimerProgressBar.BackColor = System.Drawing.Color.White;
            this.TimerProgressBar.BarStyle = BB.Common.WinForms.MetroProgressBarStyle.Standard;
            this.TimerProgressBar.BorderWidth = 2;
            this.TimerProgressBar.Location = new System.Drawing.Point(10, 120);
            this.TimerProgressBar.Maximum = 100;
            this.TimerProgressBar.Name = "TimerProgressBar";
            this.TimerProgressBar.Padding = new System.Windows.Forms.Padding(2);
            this.TimerProgressBar.Size = new System.Drawing.Size(110, 10);
            this.TimerProgressBar.TabIndex = 3;
            this.TimerProgressBar.Value = 0;
            // 
            // SeatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TimerProgressBar);
            this.Controls.Add(this.ChipsPanel);
            this.Controls.Add(this.NamePanel);
            this.Controls.Add(this.AvatarPanel);
            this.Name = "SeatControl";
            this.Size = new System.Drawing.Size(130, 130);
            this.AvatarPanel.ResumeLayout(false);
            this.NamePanel.ResumeLayout(false);
            this.ChipsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BB.Common.WinForms.MetroPanel AvatarPanel;
        private BB.Common.WinForms.MetroPanel NamePanel;
        private BB.Common.WinForms.MetroPanel ChipsPanel;
        private BB.Common.WinForms.MetroProgressBar TimerProgressBar;
        private BB.Common.WinForms.MetroLabel NameLabel;
        private BB.Common.WinForms.MetroLabel ChipsLabel;
        private BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl Card2;
        private BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl.CardControl Card1;
    }
}
