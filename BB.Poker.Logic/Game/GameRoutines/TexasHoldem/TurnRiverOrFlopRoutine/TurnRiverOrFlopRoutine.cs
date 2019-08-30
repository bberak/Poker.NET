using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class TexasHoldemTable
    {
        protected class TurnRiverOrFlopRoutine : TexasHoldemRoutine
        {
            public TurnRiverOrFlopRoutine(TexasHoldemTable table, TableState newState)
                : base(table, newState)
            {
            }

            public override void Run()
            {
                base.Run();

                Table.Deck.PullCard(); //Burn a card

                switch (RoutineState)
                {
                    case TableState.DealingFlop:
                        {
                            Table.TurnRiverOrFlop.Add(Table.Deck.PullCard());
                            Table.TurnRiverOrFlop.Add(Table.Deck.PullCard());
                            Table.TurnRiverOrFlop.Add(Table.Deck.PullCard());
                            break;
                        }

                    case TableState.DealingTurn:
                    case TableState.DealingRiver:
                        Table.TurnRiverOrFlop.Add(Table.Deck.PullCard());
                        break;

                    default:
                        throw new InvalidOperationException("The supplied TableState is invalid in this context");

                }

                Table.PlayerPortal.SendTurnRiverOrFlop(Table.Spectators + Table.PlayerSlots.GetPlayers(), Table.TurnRiverOrFlop);
            }
        }
    }
}
