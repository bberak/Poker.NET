namespace BB.Poker.WinFormsClient
{
    partial class LobbyModuleControl
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
            this.components = new System.ComponentModel.Container();
            this.OutterTablePanel = new BB.Common.WinForms.MetroPanel();
            this.BoundaryPanel = new System.Windows.Forms.Panel();
            this.InnerTablePanel = new System.Windows.Forms.Panel();
            this.TableScrollBar = new BB.Common.WinForms.MetroScrollBar();
            this.StatusLabel = new BB.Common.WinForms.MetroLabel();
            this.RefreshListButton = new BB.Common.WinForms.MetroButton();
            this.metroLabel1 = new BB.Common.WinForms.MetroLabel();
            this.OutterTablePanel.SuspendLayout();
            this.BoundaryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutterTablePanel
            // 
            this.OutterTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OutterTablePanel.BorderColor = System.Drawing.Color.White;
            this.OutterTablePanel.Controls.Add(this.TableScrollBar);
            this.OutterTablePanel.Controls.Add(this.BoundaryPanel);
            this.OutterTablePanel.Location = new System.Drawing.Point(45, 26);
            this.OutterTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.OutterTablePanel.Name = "OutterTablePanel";
            this.OutterTablePanel.Size = new System.Drawing.Size(770, 487);
            this.OutterTablePanel.TabIndex = 3;
            // 
            // BoundaryPanel
            // 
            this.BoundaryPanel.Controls.Add(this.InnerTablePanel);
            this.BoundaryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoundaryPanel.Location = new System.Drawing.Point(2, 2);
            this.BoundaryPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BoundaryPanel.Name = "BoundaryPanel";
            this.BoundaryPanel.Size = new System.Drawing.Size(766, 483);
            this.BoundaryPanel.TabIndex = 2;
            // 
            // InnerTablePanel
            // 
            this.InnerTablePanel.AutoSize = true;
            this.InnerTablePanel.Location = new System.Drawing.Point(0, 0);
            this.InnerTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.InnerTablePanel.Name = "InnerTablePanel";
            this.InnerTablePanel.Padding = new System.Windows.Forms.Padding(2);
            this.InnerTablePanel.Size = new System.Drawing.Size(747, 483);
            this.InnerTablePanel.TabIndex = 0;
            // 
            // TableScrollBar
            // 
            this.TableScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.TableScrollBar.Location = new System.Drawing.Point(749, 2);
            this.TableScrollBar.Margin = new System.Windows.Forms.Padding(0);
            this.TableScrollBar.Name = "TableScrollBar";
            this.TableScrollBar.Size = new System.Drawing.Size(19, 483);
            this.TableScrollBar.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(650, 521);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(165, 28);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Fetching Tables..";
            // 
            // RefreshListButton
            // 
            this.RefreshListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.RefreshListButton.BorderColor = System.Drawing.Color.White;
            this.RefreshListButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshListButton.ForeColor = System.Drawing.Color.White;
            this.RefreshListButton.Location = new System.Drawing.Point(45, 519);
            this.RefreshListButton.Margin = new System.Windows.Forms.Padding(0);
            this.RefreshListButton.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.RefreshListButton.MouseOverBackColor = System.Drawing.Color.Coral;
            this.RefreshListButton.MouseOverBorderColor = System.Drawing.Color.White;
            this.RefreshListButton.MouseOverForeColor = System.Drawing.Color.White;
            this.RefreshListButton.Name = "RefreshListButton";
            this.RefreshListButton.Size = new System.Drawing.Size(109, 30);
            this.RefreshListButton.TabIndex = 2;
            this.RefreshListButton.TabStop = false;
            this.RefreshListButton.Text = "Refresh";
            this.RefreshListButton.UseVisualStyleBackColor = false;
            this.RefreshListButton.Click += new System.EventHandler(this.RefreshListButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroLabel1.ForeColor = System.Drawing.Color.White;
            this.metroLabel1.Location = new System.Drawing.Point(43, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(138, 23);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Lobby";
            // 
            // LobbyModuleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.OutterTablePanel);
            this.Controls.Add(this.RefreshListButton);
            this.Name = "LobbyModuleControl";
            this.Size = new System.Drawing.Size(850, 566);
            this.OutterTablePanel.ResumeLayout(false);
            this.BoundaryPanel.ResumeLayout(false);
            this.BoundaryPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BB.Common.WinForms.MetroButton RefreshListButton;
        private BB.Common.WinForms.MetroPanel OutterTablePanel;
        private System.Windows.Forms.Panel InnerTablePanel;
        private BB.Common.WinForms.MetroScrollBar TableScrollBar;
        private System.Windows.Forms.Panel BoundaryPanel;
        private BB.Common.WinForms.MetroLabel metroLabel1;
        private BB.Common.WinForms.MetroLabel StatusLabel;
    }
}
