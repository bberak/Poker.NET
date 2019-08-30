namespace BB.Poker.WinFormsClient
{
    partial class FormsUserInterface
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
            this.m_tcTabWindow = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnLeaveTable = new System.Windows.Forms.Button();
            this.m_lblBlinds = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtTableConsole = new System.Windows.Forms.TextBox();
            this.m_lblDealerChipIndex = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lblTableStatus = new System.Windows.Forms.Label();
            this.m_lblPotValue = new System.Windows.Forms.Label();
            this.m_lblCommunityCards = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_pnlPlayerControls = new System.Windows.Forms.Panel();
            this.btnLoginLogout = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.PlayerCardsLabel = new System.Windows.Forms.Label();
            this.TableListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.m_tcTabWindow.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tcTabWindow
            // 
            this.m_tcTabWindow.Controls.Add(this.tabPage1);
            this.m_tcTabWindow.Controls.Add(this.tabPage2);
            this.m_tcTabWindow.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_tcTabWindow.Location = new System.Drawing.Point(0, 0);
            this.m_tcTabWindow.Margin = new System.Windows.Forms.Padding(0);
            this.m_tcTabWindow.Name = "m_tcTabWindow";
            this.m_tcTabWindow.SelectedIndex = 0;
            this.m_tcTabWindow.Size = new System.Drawing.Size(673, 480);
            this.m_tcTabWindow.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.TableListPanel);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(665, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Table Listing";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(9, 417);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PlayerCardsLabel);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btnLeaveTable);
            this.tabPage2.Controls.Add(this.m_lblBlinds);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.m_txtTableConsole);
            this.tabPage2.Controls.Add(this.m_lblDealerChipIndex);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.m_lblTableStatus);
            this.tabPage2.Controls.Add(this.m_lblPotValue);
            this.tabPage2.Controls.Add(this.m_lblCommunityCards);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.m_pnlPlayerControls);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(665, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Current Game";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnLeaveTable
            // 
            this.btnLeaveTable.Location = new System.Drawing.Point(22, 21);
            this.btnLeaveTable.Name = "btnLeaveTable";
            this.btnLeaveTable.Size = new System.Drawing.Size(75, 23);
            this.btnLeaveTable.TabIndex = 14;
            this.btnLeaveTable.Text = "Leave Table";
            this.btnLeaveTable.UseVisualStyleBackColor = true;
            this.btnLeaveTable.Click += new System.EventHandler(this.btnLeaveTable_Click);
            // 
            // m_lblBlinds
            // 
            this.m_lblBlinds.AutoSize = true;
            this.m_lblBlinds.Location = new System.Drawing.Point(505, 200);
            this.m_lblBlinds.Name = "m_lblBlinds";
            this.m_lblBlinds.Size = new System.Drawing.Size(74, 13);
            this.m_lblBlinds.TabIndex = 13;
            this.m_lblBlinds.Text = "Blinds go here";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(408, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Small/Big Blinds:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Console:";
            // 
            // m_txtTableConsole
            // 
            this.m_txtTableConsole.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_txtTableConsole.Location = new System.Drawing.Point(411, 239);
            this.m_txtTableConsole.Multiline = true;
            this.m_txtTableConsole.Name = "m_txtTableConsole";
            this.m_txtTableConsole.ReadOnly = true;
            this.m_txtTableConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtTableConsole.Size = new System.Drawing.Size(246, 201);
            this.m_txtTableConsole.TabIndex = 10;
            // 
            // m_lblDealerChipIndex
            // 
            this.m_lblDealerChipIndex.AutoSize = true;
            this.m_lblDealerChipIndex.Location = new System.Drawing.Point(505, 177);
            this.m_lblDealerChipIndex.Name = "m_lblDealerChipIndex";
            this.m_lblDealerChipIndex.Size = new System.Drawing.Size(83, 13);
            this.m_lblDealerChipIndex.TabIndex = 9;
            this.m_lblDealerChipIndex.Text = "Index goes here";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dealer Chip Index:";
            // 
            // m_lblTableStatus
            // 
            this.m_lblTableStatus.AutoSize = true;
            this.m_lblTableStatus.Location = new System.Drawing.Point(484, 154);
            this.m_lblTableStatus.Name = "m_lblTableStatus";
            this.m_lblTableStatus.Size = new System.Drawing.Size(110, 13);
            this.m_lblTableStatus.TabIndex = 7;
            this.m_lblTableStatus.Text = "Table state goes here";
            // 
            // m_lblPotValue
            // 
            this.m_lblPotValue.AutoSize = true;
            this.m_lblPotValue.Location = new System.Drawing.Point(440, 128);
            this.m_lblPotValue.Name = "m_lblPotValue";
            this.m_lblPotValue.Size = new System.Drawing.Size(102, 13);
            this.m_lblPotValue.TabIndex = 6;
            this.m_lblPotValue.Text = "Pot value goes here";
            // 
            // m_lblCommunityCards
            // 
            this.m_lblCommunityCards.Location = new System.Drawing.Point(505, 73);
            this.m_lblCommunityCards.Name = "m_lblCommunityCards";
            this.m_lblCommunityCards.Size = new System.Drawing.Size(154, 42);
            this.m_lblCommunityCards.TabIndex = 5;
            this.m_lblCommunityCards.Text = "Cards go here";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Table Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Pot:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Community Cards:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Players:";
            // 
            // m_pnlPlayerControls
            // 
            this.m_pnlPlayerControls.AutoScroll = true;
            this.m_pnlPlayerControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlPlayerControls.Location = new System.Drawing.Point(22, 73);
            this.m_pnlPlayerControls.Name = "m_pnlPlayerControls";
            this.m_pnlPlayerControls.Size = new System.Drawing.Size(380, 367);
            this.m_pnlPlayerControls.TabIndex = 0;
            // 
            // btnLoginLogout
            // 
            this.btnLoginLogout.Location = new System.Drawing.Point(592, 487);
            this.btnLoginLogout.Name = "btnLoginLogout";
            this.btnLoginLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLoginLogout.TabIndex = 1;
            this.btnLoginLogout.Text = "Login";
            this.btnLoginLogout.UseVisualStyleBackColor = true;
            this.btnLoginLogout.Click += new System.EventHandler(this.btnLoginLogout_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(408, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Your Cards:";
            // 
            // PlayerCardsLabel
            // 
            this.PlayerCardsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerCardsLabel.Location = new System.Drawing.Point(476, 31);
            this.PlayerCardsLabel.Name = "PlayerCardsLabel";
            this.PlayerCardsLabel.Size = new System.Drawing.Size(181, 36);
            this.PlayerCardsLabel.TabIndex = 16;
            this.PlayerCardsLabel.Text = "Cards go here";
            // 
            // TableListPanel
            // 
            this.TableListPanel.AutoScroll = true;
            this.TableListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TableListPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TableListPanel.Location = new System.Drawing.Point(9, 41);
            this.TableListPanel.Name = "TableListPanel";
            this.TableListPanel.Size = new System.Drawing.Size(648, 370);
            this.TableListPanel.TabIndex = 4;
            this.TableListPanel.WrapContents = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Available Tables:";
            // 
            // FormsUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 517);
            this.Controls.Add(this.btnLoginLogout);
            this.Controls.Add(this.m_tcTabWindow);
            this.Name = "FormsUserInterface";
            this.Text = "FormsUserInterface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormsUserInterface_FormClosing);
            this.m_tcTabWindow.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl m_tcTabWindow;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel m_pnlPlayerControls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_lblTableStatus;
        private System.Windows.Forms.Label m_lblPotValue;
        private System.Windows.Forms.Label m_lblCommunityCards;
        private System.Windows.Forms.Label m_lblDealerChipIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox m_txtTableConsole;
        private System.Windows.Forms.Label m_lblBlinds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLeaveTable;
        private System.Windows.Forms.Button btnLoginLogout;
        private System.Windows.Forms.Label PlayerCardsLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel TableListPanel;
        private System.Windows.Forms.Label label9;
    }
}