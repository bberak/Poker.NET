using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class TexasHoldemTable
    {
        protected class CollectBlindsRoutine : TexasHoldemRoutine
        {
            public CollectBlindsRoutine(TexasHoldemTable table)
                : base(table, TableState.CollectingBlinds) { }

            public override void Run()
            {
                base.Run();
             
                if (!Table.HasMinimumNumberOfActivePlayers()) return;

                Player smallBlindPlayer = Table.PlayerSlots.GetSlotWithDealerButton().GetNextActivePlayer();
                Player bigBlindPlayer = Table.PlayerSlots.GetSlotWithDealerButton().GetNextSlotWithActivePlayer().GetNextActivePlayer();

                Table.PotManager.AddToPot(smallBlindPlayer, smallBlindPlayer.HandOverChips(Table.SmallBlind));
                Table.PotManager.AddToPot(bigBlindPlayer, bigBlindPlayer.HandOverChips(Table.BigBlind));

                BlindFeeNotice bfn = new BlindFeeNotice();
                bfn.SmallBlindPlayer = smallBlindPlayer.Name;
                bfn.BigBlindPlayer = bigBlindPlayer.Name;
                bfn.SmallBlindAmount = Table.SmallBlind;
                bfn.BigBlindAmount = Table.BigBlind;
                bfn.SmallBlindPlayerTotalChips = smallBlindPlayer.Chips;
                bfn.BigBlindPlayerTotalChips = bigBlindPlayer.Chips;

                Table.PlayerPortal.SendPostingBlinds(Table.Spectators + Table.PlayerSlots.GetPlayers(), bfn);
            }
        }
    }
}
