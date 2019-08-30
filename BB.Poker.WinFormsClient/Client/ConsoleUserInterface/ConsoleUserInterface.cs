using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public class ConsoleUserInterface : IUserInterface
    {
        public ConsoleUserInterface() { }

        private string readString()
        {
            string input = Console.ReadLine();

            if (input.ToLower().Equals("exit"))
                OnUserExit(new EventArgs());

            return input;
        }

        private int readInt()
        {
            string input = readString();

            int val;

            if (int.TryParse(input, out val) == false)
                return -1;
            else
                return val;
        }

        #region IUserInterface Members

        public Account GetUserAccount()
        {
            string name = GetPlayerName();
            double chips = GetUserFunds();

            Account acc = new Account(name, string.Empty, chips);
            return acc;
        }

        public string GetPlayerName()
        {
            Display(Environment.NewLine + "What is your player name?");
            return readString();
        }

        public double GetUserFunds()
        {
            Display(Environment.NewLine + "How much money would you like to withdraw?");

            double cash = (double)readInt();

            if (cash < 0)
                return GetUserFunds();
            else
                return cash;
        }

        #endregion

        #region IUserInterface Members

        public void ShowMessageBox(string toDisplay)
        {

        }

        public void Display(string toDisplay)
        {
            Console.WriteLine(toDisplay);
        }

        public void ShowTab(int index)
        {
            throw new NotImplementedException();
        }

        public void RefreshListing()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserInterface Members

        public event JoinTableEventHandler JoinTable;

        public event EventHandler UserExit;

        public event EventHandler UserLogout;

        public event EventHandler RefreshTableListing;

        public event EventHandler LeaveTable;

        #endregion

        protected void OnJoinTable(JoinTableEventArgs e) { if (JoinTable != null) JoinTable(this, e); }

        protected void OnUserExit(EventArgs e) { if (UserExit != null) UserExit(this, e); }

        protected void OnUserLogout(EventArgs e) { if (UserLogout != null) UserLogout(this, e); }

        protected void OnRefreshTableListing(EventArgs e) { if (RefreshTableListing != null) RefreshTableListing(this, e); }

        protected void OnLeaveTable(EventArgs e) { if (LeaveTable != null) LeaveTable(this, e); }

        #region IUserInterface Members


        public void Display(List<TableSummary> summaries)
        {
            throw new NotImplementedException();
        }

        public void Display(TableSummary ts)
        {
            Console.WriteLine("Table State: " + ts.State);
            Console.WriteLine(Environment.NewLine + "ID: " + ts.TableId + " Players: " + ts.PlayerCount + "/" + ts.MaxPlayers
             + " Blinds: " + ts.SmallBlind + "/" + ts.BigBlind + " Pot: $" + ts.PotValue);
        }

        public void Display(PlayerSummary[] summaries)
        {
            if (summaries != null)
            {
                foreach (PlayerSummary ps in summaries)
                    Console.WriteLine(Environment.NewLine + "Name: " + ps.Name + " Chips: " + ps.Chips
                        + " Position: " + ps.Position + " State: " + ps.State);
            }
        }

        public void Display(int dealerChipIndex)
        {
            Console.WriteLine(Environment.NewLine + "Dealer Chip Index is: " + dealerChipIndex);
        }

        public void Display(BlindFeeNotice bfn, string currentPlayer)
        {
            if (bfn.BigBlindPlayer.Equals(currentPlayer))
            {
                Display("You have been charged $" + bfn.BigBlindAmount + " (BigBlind)");
                Display(bfn.SmallBlindPlayer + " has been charged $" + bfn.SmallBlindAmount + " (SmallBlind)"); 
            }
            else if (bfn.SmallBlindPlayer.Equals(currentPlayer))
            {
                Display(bfn.BigBlindPlayer + " has been charged $" + bfn.BigBlindAmount + " (BigBlind)");
                Display("You have have been charged $" + bfn.SmallBlindAmount + " (SmallBlind)"); ;
            }
            else
            {
                Display(bfn.BigBlindPlayer + " has been charged $" + bfn.BigBlindAmount + " (BigBlind)");
                Display(bfn.SmallBlindPlayer + " has been charged $" + bfn.SmallBlindAmount + " (SmallBlind)"); 
            }
        }

        public void Display(Hand playerHand)
        {
            Display("Your hand is: " + playerHand.ToString());
        }

        public void Display(Card[] turnRiverOrFlop)
        {
            string cardString = string.Empty;
            foreach (Card c in turnRiverOrFlop)
                cardString += c.ToString() + " ";

            if (turnRiverOrFlop.Length == 3)
                Display("Here comes the flop: " + cardString);
            else if (turnRiverOrFlop.Length == 4)
                Display("Here comes the turn: " + cardString);
            else
                Display("Here comes the river: " + cardString);
        }

        public void Display(GameOutcome2 go2)
        {
            Console.WriteLine("********* GAME OUTCOME *********");

            if (go2.WasItAShowDown)
            {
                if (go2.Winners.Length == 1)
                    Console.WriteLine(go2.Winners[0].PlayerSummary.Name + " has won the game with " + TextFormatter.GetString(go2.Winners[0].Hand) + " (" + go2.Winners[0].Hand.BestCombination + ")!");
                else
                {
                    foreach (PlayerResult pRes in go2.Winners)
                        Console.WriteLine(pRes.PlayerSummary.Name + " has tied with " + TextFormatter.GetString(pRes.Hand) + " (" + pRes.Hand.BestCombination + ")!");
                }

                foreach (PlayerResult pRes in go2.Losers)
                    Console.WriteLine(pRes.PlayerSummary.Name + " has lost with " + TextFormatter.GetString(pRes.Hand) + " (" + pRes.Hand.BestCombination + ")!");
            }
            else
                Console.WriteLine(go2.Winners[0].PlayerSummary.Name + " has won the game!");
        }

        public void Display(JoinTableResponse jtrres)
        {

        }

        public void ShowGreeting()
        {
            Console.WriteLine("Poker Reloaded Version 0.1 By Pizarro Systems" + Environment.NewLine);
            Console.WriteLine(Environment.NewLine + "Type 'exit' at any time to quit the game.");
        }

        public string SelectTable(TableSummary[] summaries)
        {
            if (summaries != null && summaries.Length > 0)
            {
                string tableListing = string.Empty;
                foreach (TableSummary ts in summaries)
                {
                    tableListing += ts.TableId + ", ";
                }
                tableListing = tableListing.Substring(0, tableListing.Length - 2);

                Console.WriteLine(Environment.NewLine + "The following tables are available: " + tableListing);
                Console.WriteLine(Environment.NewLine + "Which table would you like to join?");

                return readString();
            }
            else
                return string.Empty;
        }

        public int SelectSeat(TableSummary ts)
        {
            string seats = String.Empty; ;
            foreach (int s in ts.AvailableSeats)
            {
                seats += s.ToString() + ", ";
            }
            seats = seats.Substring(0, seats.Length - 2);

            Console.WriteLine(Environment.NewLine + "The following seats are available: " + seats);
            Console.WriteLine(Environment.NewLine + "Which seat would you like to join?");

            return readInt();
        }

        public PlayerDecisionResponse GetPlayerDecision(double minimumBet, string playerName, Hand playerHand)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("********* AWAITING PLAYER DECISION BELOW *********");
            Console.WriteLine("Options: 'fold', 'check', 'call', 'raise' or 'allin'...");
            Console.WriteLine(playerName + ": Your hand is " + playerHand + ". The minimum bet is $" + minimumBet + ". What is your decision?");

            PlayerDecisionResponse pd = new PlayerDecisionResponse();
            pd.PlayerName = playerName;

            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "fold":
                    pd.Type = DecisionType.Fold;
                    break;

                case "check":
                    pd.Type = DecisionType.Check;
                    break;

                case "call":
                    pd.Type = DecisionType.Call;
                    break;

                case "raise":
                    {
                        pd.Type = DecisionType.Raise;
                        Console.WriteLine(playerName + ": How much would you like to raise to?");
                        double toParse = pd.RaiseAmount;
                        if (double.TryParse(Console.ReadLine(), out toParse) == false)
                            pd = this.GetPlayerDecision(minimumBet, playerName, playerHand);
                        break;
                    }

                case "allin":
                    pd.Type = DecisionType.AllIn;
                    break;

                default:
                    pd = this.GetPlayerDecision(minimumBet, playerName, playerHand);
                    break;
            }

            return pd;
        }

        public void Display(PlayerDecisionNotification playerDecisionNotif)
        {
            Console.WriteLine(playerDecisionNotif.PlayerName + " has made the following decision:");
            Console.WriteLine(playerDecisionNotif.Type + ": $" + playerDecisionNotif.RaiseAmount);
        }

        public string GetUserInput(string msg)
        {
            Display(msg);
            return GetUserInput();
        }

        public string GetUserInput()
        {
            return readString();
        }

        public void Show()
        {
            
        }

        public void Hide()
        {
            
        }

        public void IndicatePlayerIsMakingDecision(string playerName)
        {
            Console.WriteLine(playerName + " is making his/her decision.");
        }

        #endregion

        #region IUserInterface Members


        public void SetLoginButtonText(string newText)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserInterface Members


        public void SetFormText(string newText)
        {
            throw new NotImplementedException();
        }

        public event EventHandler UserLoginLogout;

        #endregion

        protected void OnUserLoginLogout()
        {
            //-- Stub method for removing the 'UserLoginLogout event is never used' warning..
            var myEvent = UserLoginLogout;
        }
    }
}
