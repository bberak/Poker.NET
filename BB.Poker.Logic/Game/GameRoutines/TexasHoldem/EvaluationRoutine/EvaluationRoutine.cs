using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class TexasHoldemTable
    {
        protected class EvaluationRoutine : TexasHoldemRoutine
        {
            HandEvaluator Evaluator;

            Dictionary<string, double> ProfitOrLossCounter;

            Dictionary<string, Hand> PlayerHands;

            public EvaluationRoutine(TexasHoldemTable table)
                : base(table, TableState.Evaluating)
            {
                Evaluator = new HandEvaluator();

                ProfitOrLossCounter = new Dictionary<string, double>(Table.MAX_PLAYERS);

                PlayerHands = new Dictionary<string, Hand>(Table.MAX_PLAYERS);
            }

            private void DeterminePlayerHands(List<Player> players)
            {
                //-- Player should not have a Hand property.. Instead, player should only
                //-- have a cards, property.. Hands should only be created at the end of each
                //-- game. This will require me to break some of the other components..

                PlayerHands.Clear();

                foreach (Player player in players)
                {
                    if (player.State > PlayerState.Folded)
                    {
                        Evaluator.Cards = player.Cards + Table.TurnRiverOrFlop;

                        PlayerHands.Add(player.Name, Evaluator.GetBestHand());
                    }
                }
            }

            private List<Player> GetWinners(List<Player> players)
            {
                List<Player> winners = new List<Player>();

                foreach (Player player in players)
                {
                    if (player.State > PlayerState.Folded)
                    {
                        if (winners.Count < 1) // if there is no one in the winners list yet
                            winners.Add(player);
                        else
                        {
                            int compareResult = HandEvaluator.Compare(PlayerHands[player.Name], PlayerHands[winners[0].Name]);

                            if (compareResult == 1)
                            {
                                winners.Clear();
                                winners.Add(player);
                            }
                            else if (compareResult == 0)
                            {
                                winners.Add(player);
                            }
                        }
                    }
                }

                return winners;
            }

            private List<Player> GetLosers(List<Player> winners)
            {
                List<Player> loserList = Table.PlayerSlots.GetPlayers(PlayerState.Playing | PlayerState.AllIn);

                foreach (Player player in winners)
                    loserList.Remove(player);

                return loserList;
            }

            private void RecordCurrentChips(List<Player> players)
            {
                ProfitOrLossCounter.Clear();

                foreach (Player player in players)
                    ProfitOrLossCounter.Add(player.Name, player.Chips);
            }

            private void DetermineProfitOrLoss(List<Player> players)
            {
                foreach (Player player in players)
                {
                    double profitOrLoss = player.Chips - ProfitOrLossCounter[player.Name];

                    ProfitOrLossCounter[player.Name] = profitOrLoss;
                }
            }

            private List<Player> Combine(params List<Player>[] lists)
            {
                List<Player> total = new List<Player>();

                foreach (List<Player> list in lists)
                {
                    foreach (Player p in list)
                        total.Add(p);
                }

                return total;
            }

            private double GetProfitOrLoss(string playerName)
            {
                return ProfitOrLossCounter[playerName];
            }

            private void UpdatePlayerStates()
            {
                foreach (PlayerSlot ps in Table.PlayerSlots)
                {
                    if (ps.HasPlayer && ps.Player.Chips < Table.BigBlind)
                        ps.Player.State = PlayerState.Bust;
                }
            }

            public override void Run()
            {
                base.Run();

                Table.PlayerPortal.SendTableSummary(Table.Spectators + Table.PlayerSlots.GetPlayers(), Table.GetSummary());

                DeterminePlayerHands(Table.PlayerSlots.GetPlayers());

                List<Player> winners = GetWinners(Table.PlayerSlots.GetPlayers());
                List<Player> losers = GetLosers(winners);


                RecordCurrentChips(Combine(winners, losers));
                Table.PotManager.AwardPot(winners, losers, Table.PlayerSlots.GetPlayers());
                DetermineProfitOrLoss(Combine(winners, losers));

                GameOutcome2 go2 = new GameOutcome2();

                PlayerResult[] winnersResults = new PlayerResult[winners.Count];
                for (int i = 0; i < winnersResults.Length; i++)
                {
                    string playerName = winners[i].Name;
                    winnersResults[i] = new PlayerResult();
                    winnersResults[i].PlayerSummary = winners[i].GetSummary(Table.PlayerSlots.GetSlotPosition(playerName));
                    winnersResults[i].Hand = PlayerHands[playerName];
                    winnersResults[i].ProfitOrLoss = GetProfitOrLoss(playerName);
                }

                PlayerResult[] losersResults = new PlayerResult[losers.Count];
                for (int i = 0; i < losersResults.Length; i++)
                {
                    string playerName = losers[i].Name;
                    losersResults[i] = new PlayerResult();
                    losersResults[i].PlayerSummary = losers[i].GetSummary(Table.PlayerSlots.GetSlotPosition(playerName));
                    losersResults[i].Hand = PlayerHands[playerName];
                    losersResults[i].ProfitOrLoss = GetProfitOrLoss(playerName);
                }

                go2.Winners = winnersResults;
                go2.Losers = losersResults;
                go2.WasItAShowDown = (winners.Count + losers.Count) > 1;

                //-- If it was not a showdown, clear the hands before you send them out.
                if (go2.WasItAShowDown == false)
                {
                    go2.ClearHands();
                }

                Table.PlayerPortal.SendGameOutcome(Table.Spectators + Table.PlayerSlots.GetPlayers(), go2);

                UpdatePlayerStates();

                Table.PlayerPortal.SendPlayerSummaries(Table.Spectators + Table.PlayerSlots.GetPlayers(), 
                    Table.PlayerSlots.GetPlayerSummaries().ToArray());
            }
        }
    }
}
