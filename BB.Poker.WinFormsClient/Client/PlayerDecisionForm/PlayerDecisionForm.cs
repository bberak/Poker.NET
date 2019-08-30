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
    public partial class PlayerDecisionForm : Form
    {
        private double currentMinimumBet;
        private Hand currentHand;
        string playerName;

        public PlayerDecisionResponse Decision { get; protected set; }
        public PlayerDecisionForm()
        {
            InitializeComponent();
        }

        public PlayerDecisionForm(double minimumBet, string playerName, Hand playerHand) : this()
        {
            Reset(minimumBet, playerName, playerHand);
        }

        public void Reset(double minimumBet, string playerName, Hand playerHand)
        {
            this.Text = playerName + " please make your decision.";
            currentMinimumBet = minimumBet;
            currentHand = playerHand;
            this.playerName = playerName;
            m_lblMinumum.Text = currentMinimumBet.ToString();

            disableRaise();
            rbtnFold.Checked = false;
            rbtnCheck.Checked = false;
            rbtnCall.Checked = false;
            rbtnRaise.Checked = false;
            rbtnAllIn.Checked = false;

            rbtnFold.Enabled = true;
            rbtnCheck.Enabled = true;
            rbtnCall.Enabled = true;
            rbtnRaise.Enabled = true;
            rbtnAllIn.Enabled = true;

            m_lblPlayerCards.Text = currentHand.ToString();
            Decision = null;

            if (currentMinimumBet >= GameClient.Player.Chips)
            {
                rbtnCheck.Enabled = false;
                rbtnRaise.Enabled = false;
            }
            else if (currentMinimumBet > 0)
            {
                rbtnCheck.Enabled = false;
            }
            else if (currentMinimumBet == 0)
            {
                rbtnCall.Enabled = false;
            }

            int maximumBet = (int)GameClient.Player.Chips - 1;

            m_nudRaiseAmount.Maximum = maximumBet;

            m_nudRaiseAmount.Minimum = (int)currentMinimumBet + 1;

            m_nudRaiseAmount.Value = m_nudRaiseAmount.Minimum;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRaise.Checked)
                enableRaise();
            else
                disableRaise();
        }

        private void enableRaise()
        {
            label1.Enabled = true;
            label2.Enabled = true;
            m_nudRaiseAmount.Enabled = true;
        }

        private void disableRaise()
        {
            label1.Enabled = false;
            label2.Enabled = false;
            m_nudRaiseAmount.Enabled = false;
        }

        private void m_btnDown_Click(object sender, EventArgs e)
        {
            PlayerDecisionResponse pd = new PlayerDecisionResponse();
            pd.PlayerName = playerName;

            foreach (RadioButton rd in m_grpOptions.Controls)
            {
                if (rd.Checked)
                {
                    pd.Type = (DecisionType)Enum.Parse(typeof(DecisionType), (string)rd.Tag);
                    break;
                }
            }

            if (pd.Type == DecisionType.Raise)
                pd.RaiseAmount = (double)m_nudRaiseAmount.Value;

            Decision = pd;
            this.Hide();
        }
    }
}
