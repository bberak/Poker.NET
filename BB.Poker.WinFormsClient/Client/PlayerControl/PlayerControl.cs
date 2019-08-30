using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public partial class PlayerControl : UserControl
    {
        private PlayerSummary playerSummary;

        public PlayerSummary PlayerSummary { get { return playerSummary; } }

        public PlayerControl()
        {
            InitializeComponent();
        }

        public PlayerControl(PlayerSummary summary): this()
        {
            playerSummary = summary;
            this.BackColor = Color.Gray;
            UpdateControls();       
        }

        public void UpdateControls()
        {
            m_lblName.Text = playerSummary.Name;
            m_lblChips.Text = playerSummary.Chips.ToString();
            m_lblStatus.Text = playerSummary.State.ToString();
            m_lblSeatPosition.Text = playerSummary.Position.ToString();

            if (GameClient.Player.Equals(playerSummary.Name))
            {
                if (GameClient.PlayerHand != null && GameClient.PlayerHand.Count > 0)
                    m_lblYourCards.Text = "Your Cards: " + GameClient.PlayerHand.ToString();
            }
            else
                m_lblYourCards.Text = string.Empty;

            if (playerSummary.State == PlayerState.Folded)
                this.BackColor = Color.Red;
        }

        public void UpdateControls(PlayerSummary newSummary)
        {
            playerSummary = newSummary;
            UpdateControls();
        }
    }
}
