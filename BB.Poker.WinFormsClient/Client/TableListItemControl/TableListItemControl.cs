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
    public partial class TableListItemControl : UserControl
    {
        protected TableSummary Summary;

        public TableListItemControl()
        {
            InitializeComponent();
        }

        public void LoadFrom(TableSummary ts)
        {
            Summary = ts;

            string blindsText = "$" + ts.SmallBlind.ToString() + "/$" + ts.BigBlind.ToString() + " Blinds";
            BlindsLabel.UpdateProperty<string>("Text", blindsText);

            string playerCountText = ts.PlayerCount + "/" + ts.MaxPlayers + " Players";
            PlayerCountLabel.UpdateProperty<string>("Text", playerCountText);

            TableStateLabel.UpdateProperty<string>("Text", ts.State.ToString());
        }

        private void PlayerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnListItemClicked();
        }

        protected void OnListItemClicked()
        {
            var myEvent = ListItemClicked;

            if (myEvent != null)
                myEvent(this, new JoinTableEventArgs(Summary, -1));
        }

        public event JoinTableEventHandler ListItemClicked;
    }
}
