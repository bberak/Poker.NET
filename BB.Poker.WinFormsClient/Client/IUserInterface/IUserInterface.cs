using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public interface IUserInterface
    {
        string GetUserInput();
        string GetUserInput(string msg);
        Account GetUserAccount();
        void ShowMessageBox(string toDisplay);
        void Display(string toDisplay);
        void Display(List<TableSummary> summaries);
        void Display(TableSummary summary);
        void Display(PlayerSummary[] summaries);
        void Display(int dealerChipIndex);
        void Display(BlindFeeNotice bfn, string currentPlayer);
        void Display(Hand playerHand);
        void Display(Card[] turnRiverOrFlop);
        void Display(PlayerDecisionNotification playerDecisionNotif);
        void Display(GameOutcome2 go2);
        void ShowGreeting();
        void ShowTab(int index);
        void RefreshListing();
        void Show();
        void Hide();
        void IndicatePlayerIsMakingDecision(string playerName);
        string SelectTable(TableSummary[] summaries);
        int SelectSeat(TableSummary ts);
        PlayerDecisionResponse GetPlayerDecision(double minimumBet, string playerName, Hand playerHand);
        void SetLoginButtonText(string newText);
        void SetFormText(string newText);
        event EventHandler UserExit;
        event JoinTableEventHandler JoinTable;
        event EventHandler UserLoginLogout;
        event EventHandler RefreshTableListing;
        event EventHandler LeaveTable;
    }
}
