using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Lidgren.Network;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public class ClientLogicUnit
    {
        public GameClient GameClient { get; set; }

        //-- Consider replacing all transported Collection objects with their array counterparts.
        //-- For example, perhaps Hand should be transported as a Card[] rather than a collection.
        public void ProcessIncomingMessage(IncomingMessage incomingMsg)
        {
            GameMessageType gmt = (GameMessageType)Enum.ToObject(typeof(GameMessageType), incomingMsg.OperationCode);

            switch (gmt)
            {
                case GameMessageType.Client_ReceivePlayerLoginResponse:
                    LoginResponse loginResp = GameClient.Serializer.GetObject<LoginResponse>(incomingMsg.Data);
                    if (loginResp.HasLoginSucceeded)
                    {
                        PlayerSummary player = new PlayerSummary();
                        player.Name = loginResp.PlayerName;
                        player.Chips = loginResp.AvailableFunds;

                        GameClient.Player = player;
                        GameClient.UI.SetLoginButtonText("Logout");
                        GameClient.UI.SetFormText(player.Name + "'s Client");
                        GameClient.SendTableListingRequest();
                    }
                    else
                    {
                        GameClient.UI.ShowMessageBox("You could not be logged in with the supplied credentials");
                    }

                    //GameClient.GameFlow.ContinueIfExpected(loginResp.ResponseId);               
                    break;

                case GameMessageType.Client_ReceiveTableListingResponse:
                    {
                        TableListingResponse listingReponse = GameClient.Serializer.GetObject<TableListingResponse>(incomingMsg.Data);

                        if (listingReponse.ResponseId.Equals(GameClient.ExpectedTableListingResponseId) == false) // It's for a new listing request
                            GameClient.TableList.Clear();

                        GameClient.TableList.AddRange(listingReponse.TableSummaries);

                        GameClient.UI.Display(GameClient.TableList);
                        break;
                    }

                case GameMessageType.Client_ReceiveJoinTableResponse:
                    {
                        JoinTableResponse jtres = GameClient.Serializer.GetObject<JoinTableResponse>(incomingMsg.Data);
                        
                        if (jtres.WasJoinSuccessful)
                        {
                            GameClient.CurrentTable = new TableSummary();
                            GameClient.CurrentTable.TableId = jtres.TableToJoin;
                            GameClient.UI.Display(string.Empty); //Clear the table console..
                            GameClient.UI.ShowTab(FormsUserInterface.TABLE_PLAY_TAB_INDEX);
                        }
                        else
                        {
                            GameClient.UI.ShowMessageBox(jtres.ServerMessage);
                        }
                        break;
                    }

                case GameMessageType.Client_ReceivePlayerSummaries:
                    {
                        PlayerSummary[] summaries = GameClient.Serializer.GetObject<PlayerSummary[]>(incomingMsg.Data);
                        GameClient.UI.Display(summaries);
                        foreach (PlayerSummary ps in summaries)
                        {
                            if (ps.Name.Equals(GameClient.Player.Name))
                                GameClient.Player = ps;
                        }
                        break;
                    }

                case GameMessageType.Client_ReceiveDealerButtonPosition:
                    {
                        int dealerChipIndex = GameClient.Serializer.GetObject<int>(incomingMsg.Data);
                        GameClient.UI.Display(dealerChipIndex);
                        break;
                    }

                case GameMessageType.Client_ReceiveBlindFeeNotice:
                    {
                        BlindFeeNotice bfn = GameClient.Serializer.GetObject<BlindFeeNotice>(incomingMsg.Data);
                        if (bfn.BigBlindPlayer.Equals(GameClient.Player.Name))
                            GameClient.Player.Chips = bfn.BigBlindPlayerTotalChips;
                        else if (bfn.SmallBlindPlayer.Equals(GameClient.Player.Name))
                            GameClient.Player.Chips = bfn.SmallBlindPlayerTotalChips;

                        GameClient.UI.Display(bfn, GameClient.Player.Name);
                        break;
                    }

                case GameMessageType.Client_ReceivePlayerCards:
                    {
                        Card[] cards = GameClient.Serializer.GetObject<Card[]>(incomingMsg.Data);
                        GameClient.PlayerHand.Clear();
                        foreach (Card c in cards)
                            GameClient.PlayerHand.Add(c);
                        GameClient.UI.Display(GameClient.PlayerHand);
                        break;
                    }

                case GameMessageType.Client_ReceiveTableSummary:
                    {
                        TableSummary ts = GameClient.Serializer.GetObject<TableSummary>(incomingMsg.Data);
                        GameClient.UI.Display(ts);
                        GameClient.CurrentTable = ts;
                        break;
                    }

                case GameMessageType.Client_ReceivePlayerDecisionRequest:
                    {
                        PlayerDecisionRequest pdr = GameClient.Serializer.GetObject<PlayerDecisionRequest>(incomingMsg.Data);

                        PlayerDecisionResponse pd = GameClient.UI.GetPlayerDecision(pdr.MinimumBet, GameClient.Player.Name, GameClient.PlayerHand);
                        pd.ResponseId = pdr.RequestId;

                        GameClient.SendMessage((int)GameMessageType.Server_ReceivePlayerDecision, pd);
                        break;
                    }

                case GameMessageType.Client_ReceivePlayerDecisionNotification:
                    {
                        PlayerDecisionNotification pdn = GameClient.Serializer.GetObject<PlayerDecisionNotification>(incomingMsg.Data);
                        GameClient.UI.Display(pdn);
                        string message = pdn.PlayerName + " has made a decision to " + pdn.Type.ToString() + " (" + pdn.RaiseAmount + ")";
                        GameClient.UI.Display(message);
                        break;
                    }

                case GameMessageType.Client_ReceiveTurnRiverOrFlop:
                    {
                        Card[] cards = GameClient.Serializer.GetObject<Card[]>(incomingMsg.Data);
                        GameClient.CurrentTable.TurnRiverOrFlop = cards;
                        GameClient.UI.Display(GameClient.CurrentTable.TurnRiverOrFlop);
                        break;
                    }

                case GameMessageType.Client_ReceiveGameOutcome:
                    {
                        GameOutcome2 outcome = GameClient.Serializer.GetObject<GameOutcome2>(incomingMsg.Data);

                        //-- Clear his current hand.
                        GameClient.PlayerHand.Clear();
                        GameClient.UI.Display(GameClient.PlayerHand);

                        GameClient.UI.Display(outcome);
                        GameClient.UI.Display("The game outcome has been decided.");

                        //-- Update the player here if he is the winner/loser
                        //-- This should be updated with another ReceiveTableSummaries message instead.
                        break;
                    }

                case GameMessageType.Client_ReceiveMakingDecisionNotice:
                    {
                        string playerName = GameClient.Serializer.GetObject<string>(incomingMsg.Data);
                        GameClient.UI.IndicatePlayerIsMakingDecision(playerName);
                        break;
                    }

                case GameMessageType.Client_ReceiveForcedTableLeaveNotice:
                    {
                        ForcedTableLeaveNotice ftln = GameClient.Serializer.GetObject<ForcedTableLeaveNotice>(incomingMsg.Data);
                        GameClient.UI.ShowMessageBox("You have been removed from table: " + ftln.Message);

                        if (GameClient.CurrentTable != null
                            && GameClient.CurrentTable.TableId.Equals(ftln.TableId))
                        {
                            //-- User has been kicked from the current table, and he has not connected to a new one..
                            //-- Therefore show and refresh the table list.
                            GameClient.UI.RefreshListing();
                            GameClient.UI.ShowTab(FormsUserInterface.TABLE_LIST_TAB_INDEX);
                            GameClient.CurrentTable = null;
                        }

                        break;
                    }

                case GameMessageType.Client_ReceiveForcedPlayerLogoutNotice:
                    {
                        ForcedPlayerLogoutNotice logoutRequest = GameClient.Serializer.GetObject<ForcedPlayerLogoutNotice>(incomingMsg.Data);

                        GameClient.CurrentTable = null;
                        GameClient.Player = null;
                        if (GameClient.PlayerHand != null)
                            GameClient.PlayerHand.Clear();   

                        GameClient.UI.ShowMessageBox("You have been logged out: " + logoutRequest.Message);
                        GameClient.UI.SetLoginButtonText("Login");
                        GameClient.UI.SetFormText("Poker Reloaded Client");
                        GameClient.UI.ShowTab(FormsUserInterface.TABLE_LIST_TAB_INDEX);
                        GameClient.TableList.Clear();
                        GameClient.UI.Display(GameClient.TableList);
                        GameClient.CurrentTable = null;
                        break;
                    }

                default:
                    throw new NotImplementedException("You must write a method handler to handle this GameMessageType: " + gmt.ToString()); 
            }
        }
    }
}
