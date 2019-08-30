using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Poker.Common;
using BB.Common.WinForms;

namespace BB.Poker.WinFormsClient
{
    public partial class LobbyListItemControl : MetroUserControl
    {
        public TableSummary TableSummary { get; protected set; }

        public bool BorderColorChanged { get; protected set; }

        public LobbyListItemControl()
        {
            InitializeComponent();

            Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));

            this.MouseEnter += new EventHandler(LobbyListItemControl_MouseEnter);
            this.MouseLeave += new EventHandler(LobbyListItemControl_MouseLeave);
            this.MouseClick += new MouseEventHandler(LobbyListItemControl_MouseClick);

            foreach (Control ctrl in Controls)
            {
                ctrl.MouseEnter += new EventHandler(LobbyListItemControl_MouseEnter);
                ctrl.MouseLeave += new EventHandler(LobbyListItemControl_MouseLeave);
                ctrl.MouseClick += new MouseEventHandler(LobbyListItemControl_MouseClick);
            }
        }

        public override void ApplyTheme(BaseTheme newTheme)
        {
            base.ApplyTheme(newTheme);

            BottomBorder.BackColor = newTheme.Colors["ListItemBorderColor"]; ;
        }

        void LobbyListItemControl_MouseClick(object sender, MouseEventArgs e)
        {
            ItemClicked.Fire<TableItemClickedEventArgs>(this, new TableItemClickedEventArgs(TableSummary));
        }

        void LobbyListItemControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = ThemeManager.CurrentTheme.Colors["ListItemMouseOverBackColor"];

            if (BorderColorChanged)
                this.BottomBorder.BackColor = ThemeManager.CurrentTheme.Colors["ListItemMouseOverBackColor"];
        }

        void LobbyListItemControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = ThemeManager.CurrentTheme.Colors["UserControlBackColor"];

            if (BorderColorChanged)
                this.BottomBorder.BackColor = ThemeManager.CurrentTheme.Colors["UserControlBackColor"];
        }

        public void LoadFrom(TableSummary ts)
        {
            TableSummary = ts;

            string blindsText = "$" + ts.SmallBlind.ToString() + "/$" + ts.BigBlind.ToString();
            BlindsLabel.UpdateProperty<string>("Text", blindsText);

            string playerCountText = ts.PlayerCount + "/" + ts.MaxPlayers + " Players";
            PlayerCountLabel.UpdateProperty<string>("Text", playerCountText);

            DescriptionLabel.UpdateProperty<string>("Text", ts.Description);
        }

        public void ChangeBorderColor(bool applyChange)
        {
            BorderColorChanged = applyChange;

            if (BorderColorChanged)
                this.BottomBorder.BackColor = ThemeManager.CurrentTheme.Colors["UserControlBackColor"];
            else
                this.BottomBorder.BackColor = ThemeManager.CurrentTheme.Colors["ListItemBorderColor"];
        }

        public event EventHandler<TableItemClickedEventArgs> ItemClicked;
    }
}
