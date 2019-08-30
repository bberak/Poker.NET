using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class BaseGameTable
    {
        protected class ShuffleDeckRoutine : BaseGameRoutine
        {
            public ShuffleDeckRoutine(BaseGameTable table)
                : base(table, TableState.ShufflingDeck)
            {
            }

            public override void Run()
            {
                base.Run();

                Table.Deck = Table.DeckFactory.GetShuffledDeck();
            }
        }
    }
}
