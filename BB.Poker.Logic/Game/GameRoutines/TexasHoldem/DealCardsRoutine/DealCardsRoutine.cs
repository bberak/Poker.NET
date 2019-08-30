using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class TexasHoldemTable
    {
        protected class DealCardsRoutine : TexasHoldemRoutine
        {
            public const int NUMBER_OF_CARDS_PER_PLAYER = 2;

            public DealCardsRoutine(TexasHoldemTable table)
                : base(table, TableState.DealingPlayerCards) { }

            public override void Run()
            {
                base.Run();

                if (!Table.HasMinimumNumberOfActivePlayers()) return;

                PlayerSlot dealToMe = Table.PlayerSlots.GetSlotWithDealerButton().GetNextSlotWithActivePlayer();

                while (dealToMe.Player.Cards.Count > NUMBER_OF_CARDS_PER_PLAYER)
                {
                    dealToMe.Player.Cards.Add(Table.Deck.PullCard());
                    dealToMe = dealToMe.GetNextSlotWithActivePlayer();
                }

                Table.PlayerPortal.SendPlayerHands(Table.PlayerSlots.GetPlayers());
                Table.PlayerPortal.SendTableSummary(Table.Spectators, Table.GetSummary());// So the spectators are on the same page
            }
        }
    }
}
