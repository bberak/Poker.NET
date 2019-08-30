using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class TexasHoldemTable
    {
        protected class BettingRoundRoutine : TexasHoldemRoutine
        {
            Dictionary<string, int> TurnCounter;

            public BettingRoundRoutine(TexasHoldemTable table, TableState newState)
                : base(table, newState)
            {
                TurnCounter = new Dictionary<string, int>();
            }

            private void LoadTurnCounter()
            {
                TurnCounter.Clear();

                foreach (Player p in Table.PlayerSlots.GetActivePlayers())
                {
                    TurnCounter.Add(p.Name, 0);
                }
            }

            private bool HaveAllPlayersHadATurn()
            {
                foreach (Player p in Table.PlayerSlots.GetActivePlayers())
                {
                    if (TurnCounter[p.Name] == 0)
                        return false;
                }

                return true;
            }

            private bool HaveAllPlayersBetTheSameAmount()
            {
                return Table.PotManager.HaveAllPlayersBetTheSameAmount(Table.PlayerSlots.GetActivePlayers());
            }

            private bool CanRoundContinue()
            {
                if (Table.HasMinimumNumberOfActivePlayers())
                    return !HaveAllPlayersHadATurn() || !HaveAllPlayersBetTheSameAmount();
                else
                    return false;
            }

            private double GetAmountPlayerRequiresToCall(Player p)
            {
                return Table.PotManager.GetHighestPlayerTotal() - Table.PotManager.GetPlayerTotal(p);
            }

            private bool IsValidDecision(Player player, PlayerDecisionResponse decision, double callAmount)
            {
                //-- This method could probably use some simplification etc.. See the GetValidOptions() method.

                if (decision == null)
                    throw new NullReferenceException("The decision argument cannot be null.");

                if (callAmount > 0)
                {
                    switch (decision.Type)
                    {
                        case DecisionType.DisconnectAndFold:
                        case DecisionType.TimeOutAndFold:
                        case DecisionType.InvalidAndFold:
                        case DecisionType.Fold:
                            {
                                return true;
                            }

                        case DecisionType.Call:
                            {
                                if (callAmount >= player.Chips)
                                    return false;
                                else
                                    return true;
                            }

                        case DecisionType.AllIn:
                            return true;

                        case DecisionType.Raise:
                            {
                                if (TurnCounter[player.Name] == 0)
                                {
                                    if (decision.RaiseAmount <= callAmount)
                                        return false;
                                    else if (decision.RaiseAmount >= player.Chips)
                                        return false;
                                    else
                                        return true;
                                }
                                else
                                {
                                    //-- You cannot raise when its you second turn in the round
                                    return false;
                                }
                            }

                        case DecisionType.Check:
                            return false;

                        default:
                            throw new InvalidOperationException("An unknown DecisionType was encountered.");
                    }
                }
                else
                {
                    switch (decision.Type)
                    {
                        case DecisionType.DisconnectAndFold:
                        case DecisionType.TimeOutAndFold:
                        case DecisionType.InvalidAndFold:
                        case DecisionType.Fold:
                        case DecisionType.Check:
                        case DecisionType.AllIn:
                            return true;

                        case DecisionType.Raise:
                            {
                                if (TurnCounter[player.Name] == 0)
                                {
                                    if (decision.RaiseAmount <= callAmount)
                                        return false;
                                    else if (decision.RaiseAmount >= player.Chips)
                                        return false;
                                    else
                                        return true;
                                }
                                else
                                {
                                    //-- You cannot raise when its you second turn in the round
                                    return false;
                                }
                            }

                        case DecisionType.Call:
                            return false;

                        default:
                            throw new InvalidOperationException("An unknown DecisionType was encountered.");
                    }
                }
            }

            private void HandlePlayerDecision(Player player, PlayerDecisionResponse decision)
            {
                switch (decision.Type)
                {
                    case DecisionType.DisconnectAndFold:
                    case DecisionType.TimeOutAndFold:
                    case DecisionType.InvalidAndFold:
                    case DecisionType.Fold:
                        player.State = PlayerState.Folded;
                        break;

                    case DecisionType.Check:
                        player.State = PlayerState.Playing;
                        break;

                    case DecisionType.Call:
                        {
                            double callAmount = GetAmountPlayerRequiresToCall(player);
                            Table.PotManager.AddToPot(player, player.HandOverChips(callAmount));
                            player.State = PlayerState.Playing;
                            break;
                        }

                    case DecisionType.Raise:
                        {
                            Table.PotManager.AddToPot(player, player.HandOverChips(decision.RaiseAmount));
                            player.State = PlayerState.Playing;
                            break;
                        }

                    case DecisionType.AllIn:
                        {
                            Table.PotManager.AddToPot(player, player.AllIn());
                            player.State = PlayerState.AllIn;
                            break;
                        }

                    default:
                        throw new InvalidOperationException("An unknown DecisionType was encountered.");
                }
            }

            private DecisionType[] GetValidOptions(Player player, double minimumBet)
            {
                List<DecisionType> options = new List<DecisionType>();
                options.Add(DecisionType.Fold); //You can fold at any time
                options.Add(DecisionType.Check);
                options.Add(DecisionType.Call);
                options.Add(DecisionType.Raise);
                options.Add(DecisionType.AllIn); //You can go all-in at any time

                if (minimumBet > 0)
                    options.Remove(DecisionType.Check); //Cannot check if you are required to be

                if (minimumBet <= 0)
                    options.Remove(DecisionType.Call); //No amount to call

                if (TurnCounter[player.Name] >= 1 || minimumBet >= player.Chips)
                    options.Remove(DecisionType.Raise); //Cannot raise when it's you second turn or you don't have enought money to raise
                                                        // the current bet

                return options.ToArray();
            }

            protected PlayerDecisionNotification GetPlayerDecisionNotification(PlayerDecisionResponse decision)
            {
                return new PlayerDecisionNotification()
                {
                    PlayerName = decision.PlayerName,
                    RaiseAmount = decision.RaiseAmount,
                    Type = decision.Type,
                    LatestPotValue = Table.PotManager.GetTotal()
                };
            }

            public override void Run()
            {
                base.Run();

                if (!Table.HasMinimumNumberOfActivePlayers()) return;

                Table.PlayerPortal.SendTableSummary(Table.Spectators + Table.PlayerSlots.GetPlayers(), Table.GetSummary());

                LoadTurnCounter();
 
                //-- Perhaps the code below can be moved into the PlayerSlotCollection class, and this can track how many turns the
                //-- players have had etc.
                PlayerSlot currentTurn = Table.PlayerSlots.GetSlotWithDealerButton()
                    .GetNextSlotWithActivePlayer()
                    .GetNextSlotWithActivePlayer();

                while (CanRoundContinue())
                {
                    //-- Get next player
                    currentTurn = currentTurn.GetNextSlotWithActivePlayer();

                    Player currentPlayer = currentTurn.Player;

                    if (currentPlayer == null)
                        continue; // Player may have been removed, continue..

                    double minimumBet = GetAmountPlayerRequiresToCall(currentPlayer);
                    Table.PlayerPortal.SendPlayerMakingDecision(Table.Spectators + Table.PlayerSlots.GetPlayers(), currentPlayer.Name);

                    PlayerDecisionResponse decision = Table.PlayerPortal.GetPlayerDecision(currentPlayer, 
                        minimumBet, 
                        GetValidOptions(currentPlayer, minimumBet));

                    if (decision.Type == DecisionType.TimeOutAndFold)
                    {
                        //-- Player's decision timed out, tell him to hurry next time
                        Table.PlayerPortal.SendPersonalAnnouncement(currentPlayer, "You took too long to make a decision.");
                    }
                    else if (!IsValidDecision(currentPlayer, decision, minimumBet))
                    {
                        //-- Player really made an invalid decision
                        Table.PlayerPortal.SendPersonalAnnouncement(currentPlayer, 
                            @"Your decision was invalid, see http://www.launchpoker.com/texas-holdem/rules/ for rules.");
                        decision.Type = DecisionType.InvalidAndFold;
                    }

                    HandlePlayerDecision(currentPlayer, decision);

                    //-- Sending a lot of message types here, might be worth consolidating this into one big message.
                    //-- The TableSummary can also really be calculated on the client-side using the player's decision.
                    //-- Improved it a bit now..
                    Table.PlayerPortal.SendPlayerDecisionNotification(Table.Spectators + Table.PlayerSlots.GetPlayers(),
                        GetPlayerDecisionNotification(decision));
                    Table.PlayerPortal.SendPlayerSummaries(Table.Spectators + Table.PlayerSlots.GetPlayers(), 
                        Table.PlayerSlots.GetPlayerSummaries().ToArray());
                    
                    //-- Increment player turn count
                    TurnCounter[currentPlayer.Name] += 1;
                }

                Table.PlayerPortal.SendTableSummary(Table.Spectators + Table.PlayerSlots.GetPlayers(), Table.GetSummary());
            }
        }
    }
}
