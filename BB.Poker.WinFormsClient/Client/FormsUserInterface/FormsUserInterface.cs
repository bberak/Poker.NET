using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Poker.Common;
using BB.Common.WinForms;

namespace BB.Poker.WinFormsClient
{
    public partial class FormsUserInterface : Form, IUserInterface
    {
        public const int TABLE_LIST_TAB_INDEX = 0;
        public const int TABLE_PLAY_TAB_INDEX = 1;

        private LoginForm loginForm;
        private PlayerDecisionForm decisionForm;
        private GameOutcomeForm gameOutcomeForm;
        private ChooseSeatForm chooseSeatForm;

        public FormsUserInterface()
        {
            loginForm = new LoginForm();
            gameOutcomeForm = new GameOutcomeForm();
            decisionForm = new PlayerDecisionForm();
            chooseSeatForm = new ChooseSeatForm();
            InitializeComponent();
            this.Text = "Poker Reloaded Client";
        }

        #region IUserInterface Members

        public string GetUserInput()
        {
            return string.Empty;
        }

        public string GetUserInput(string msg)
        {
            return string.Empty;
        }

        public Account GetUserAccount()
        {
            Account result;

            loginForm.ShowDialog();

            result = loginForm.UserAccount;

            //-- Clear the form for the next login
            loginForm.Reset();

            return result;
        }

        public void ShowMessageBox(string toDisplay)
        {
            MessageBox.Show(toDisplay);
        }

        public void Display(string toDisplay)
        {
            toDisplay = m_txtTableConsole.Text + toDisplay + Environment.NewLine;
            m_txtTableConsole.UpdateProperty<string>("Text", toDisplay);
        }

        public void Display(List<TableSummary> summaries)
        {
            TableListPanel.ClearControls();

            foreach (TableSummary ts in summaries)
            {
                TableListItemControl item = new TableListItemControl();
                item.ListItemClicked += new JoinTableEventHandler(ListItemClicked);
                item.LoadFrom(ts);
                TableListPanel.AddToControls(item);
            }
        }

        public void Display(BB.Poker.Common.TableSummary summary)
        {
            m_lblCommunityCards.UpdateProperty<string>("Text", summary.TurnRiverOrFlop.ToString());
            m_lblPotValue.UpdateProperty<string>("Text", summary.PotValue.ToString());
            m_lblTableStatus.UpdateProperty<string>("Text", summary.State.ToString());
            m_lblDealerChipIndex.UpdateProperty<string>("Text", summary.DealerButtonPosition.ToString());
            m_lblBlinds.UpdateProperty<string>("Text", summary.SmallBlind.ToString() + "/" + summary.BigBlind.ToString());
        }

        //-- Delegate code is needed to overcome the
        //-- cross UI thread access exception. Seems to only be a 
        //-- problem with the DataGridView component.
        private void populatePlayerControlsListing(PlayerSummary[] summaries)
        {
            m_pnlPlayerControls.Controls.Clear();

            for (int i = 0; i < summaries.Length; i++)
            {
                PlayerControl pc = new PlayerControl(summaries[i]);
                pc.Top = i * pc.Height;
                pc.Left = 0;
                m_pnlPlayerControls.Controls.Add(pc);
            }
        }

        public void Display(PlayerSummary[] summaries)
        {
            m_pnlPlayerControls.Invoke(new UpdatePlayerSummariesListDelegate(populatePlayerControlsListing), new object[] { summaries });
        }

        public void Display(int dealerChipIndex)
        {
            
        }

        public void Display(BlindFeeNotice bfn, string currentPlayer)
        {
            Display(bfn.SmallBlindPlayer + " has been charged $" + bfn.SmallBlindAmount + " (Small Blind)");
            Display(bfn.BigBlindPlayer + " has been charged $" + bfn.BigBlindAmount + " (Big Blind)");

            foreach (PlayerControl pc in m_pnlPlayerControls.Controls)
            {
                if (pc.PlayerSummary.Name.Equals(bfn.SmallBlindPlayer))
                {
                    pc.PlayerSummary.Chips = bfn.SmallBlindPlayerTotalChips;
                    pc.ExecuteMethod("UpdateControls", typeof(PlayerSummary).ToArray(), new object[] { pc.PlayerSummary });
                }

                if (pc.PlayerSummary.Name.Equals(bfn.BigBlindPlayer))
                {
                    pc.PlayerSummary.Chips = bfn.BigBlindPlayerTotalChips;
                    pc.ExecuteMethod("UpdateControls", typeof(PlayerSummary).ToArray(), new object[] { pc.PlayerSummary });
                }
            }
        }

        public void Display(Hand playerHand)
        {
            foreach (PlayerControl pc in m_pnlPlayerControls.Controls)
            {
                if (pc.PlayerSummary.Name.Equals(GameClient.Player.Name))
                {
                    pc.ExecuteMethod("UpdateControls", typeof(PlayerSummary).ToArray(), new object[] { pc.PlayerSummary });
                    PlayerCardsLabel.UpdateProperty<string>("Text", playerHand.ToString());
                }
            }
        }

        public void Display(Card[] turnRiverOrFlop)
        {
            string cardString = string.Empty;
            foreach (Card c in turnRiverOrFlop)
                cardString += c.ToString() + " ";

            m_lblCommunityCards.UpdateProperty<string>("Text", cardString);
        }

        public void Display(PlayerDecisionNotification playerDecisionNotif)
        {
            decisionForm.Hide();
        }

        public void Display(GameOutcome2 go2)
        {
            gameOutcomeForm.Reset(go2);
            gameOutcomeForm.ShowDialog();
        }

        public void ShowTab(int index)
        {
            m_tcTabWindow.ExecuteMethod("SelectTab", typeof(int).ToArray(), new object[] { (object)index });
        }
        public void RefreshListing()
        {
            OnRefreshTableListing(new EventArgs());
        }

        public void ShowGreeting()
        {
            
        }

        public string SelectTable(BB.Poker.Common.TableSummary[] summaries)
        {
            return "2";
        }

        public int SelectSeat(TableSummary ts)
        {
            Random rng = new Random(DateTime.Now.Second * Environment.TickCount);
            return rng.Next(1, 8);
        }

        public PlayerDecisionResponse GetPlayerDecision(double minimumBet, string playerName, BB.Poker.Common.Hand playerHand)
        {
            //-- Close the GameOutcomeForm if it is open, fuck me sideways if this actually ever works as expected!
            gameOutcomeForm.Hide();

            decisionForm.Reset(minimumBet, playerName, playerHand);
            decisionForm.ShowDialog();

            if (decisionForm.Decision == null)
                return PlayerDecisionResponse.GetDefaultDecision(playerName);
            else
                return decisionForm.Decision;
        }

        public void IndicatePlayerIsMakingDecision(string playerName)
        {
            foreach (PlayerControl pc in m_pnlPlayerControls.Controls)
            {
                if (pc.PlayerSummary.Name.Equals(playerName))
                    pc.BackColor = Color.CornflowerBlue;
                else
                {
                    //-- Pretty sure this whole else statement is not required...
                    if (pc.PlayerSummary.State == PlayerState.Folded)
                        pc.BackColor = Color.Red;
                    else
                        pc.BackColor = Color.Gray;
                }
            }
        }

        protected void OnJoinTable(JoinTableEventArgs e) { if (JoinTable != null) JoinTable(this, e); }
        public event JoinTableEventHandler JoinTable;

        protected void OnUserExit(EventArgs e) { if (UserExit != null) UserExit(this, e); }
        public event EventHandler UserExit;

        protected void OnRefreshTableListing(EventArgs e) { if (RefreshTableListing != null) RefreshTableListing(this, e); }
        public event EventHandler RefreshTableListing;

        protected void OnUserLoginLogout(EventArgs e) { if (UserLoginLogout != null) UserLoginLogout(this, e); }
        public event EventHandler UserLoginLogout;

        protected void OnLeaveTable(EventArgs e) { if (LeaveTable != null) LeaveTable(this, e); }
        public event EventHandler LeaveTable;

        public new void Show()
        {
            base.Show();
        }

        public new void Hide()
        {
            base.Hide();
        }

        public void SetLoginButtonText(string newText)
        {
            btnLoginLogout.UpdateProperty<string>("Text", newText);
        }

        public void SetFormText(string newText)
        {
            this.UpdateProperty<string>("Text", newText);
        }

        #endregion

        private void FormsUserInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnUserExit(new EventArgs());
        }

        private void ListItemClicked(object sender, JoinTableEventArgs e)
        {
            chooseSeatForm.UpdateControls(e.TargetTable.AvailableSeats);
            chooseSeatForm.ShowDialog();
            int seatPos = (int)chooseSeatForm.ChosenSeat;

            OnJoinTable(new JoinTableEventArgs(e.TargetTable, seatPos));
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OnRefreshTableListing(new EventArgs());
        }

        private void btnLeaveTable_Click(object sender, EventArgs e)
        {
            OnLeaveTable(e);
        }

        private void btnLoginLogout_Click(object sender, EventArgs e)
        {
            OnUserLoginLogout(new EventArgs());
        }
    }
}
