using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public partial class GameOutcomeForm : Form
    {
        public GameOutcome2 GameOutcome { get; protected set; }

        public GameOutcomeForm()
        {
            InitializeComponent();
        }

        public void Reset(GameOutcome2 go2)
        {
            GameOutcome = go2;

            m_lblWinners.Text = string.Empty;
            m_lblLosers.Text = string.Empty;

            //var winnerQuery = from w in GameOutcome.Winners
            //            select new
            //            {
            //                Name = w.Player.Name,
            //                Cards = w.Cards.ToString(),
            //                Combination = w.BestCombination.ToString()
            //            };

            //m_dgvWinners.DataSource = winnerQuery;

            //var loserQuery = from l in GameOutcome.Losers
            //                  select new
            //                  {
            //                      Name = l.Player.Name,
            //                      Cards = l.Cards.ToString(),
            //                      Combination = l.BestCombination.ToString()
            //                  };

            //m_dgvLosers.DataSource = loserQuery;

            foreach (PlayerResult winner in GameOutcome.Winners)
            {
                string playerName = string.Empty;
                if (winner.PlayerSummary.Name.Equals(GameClient.Player.Name))
                    playerName = winner.PlayerSummary.Name + " (You)";
                else
                    playerName = winner.PlayerSummary.Name;

                string row = playerName + ": " + winner.Hand.ToString() + ", " + winner.Hand.BestCombination.ToString() + Environment.NewLine;
                m_lblWinners.Text += row;
            }

            foreach (PlayerResult loser in GameOutcome.Losers)
            {
                string playerName = string.Empty;
                if (loser.PlayerSummary.Name.Equals(GameClient.Player.Name))
                    playerName = loser.PlayerSummary.Name + " (You)";
                else
                    playerName = loser.PlayerSummary.Name;

                string row = playerName + ": " + loser.Hand.ToString() + ", " + loser.Hand.BestCombination.ToString() + Environment.NewLine;
                m_lblLosers.Text += row;
            }
        }

        private void m_btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
