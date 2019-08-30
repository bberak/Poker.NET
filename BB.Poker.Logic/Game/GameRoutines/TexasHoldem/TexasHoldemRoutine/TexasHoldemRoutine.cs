using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class TexasHoldemTable
    {
        protected abstract class TexasHoldemRoutine : BaseGameRoutine
        {
            public new TexasHoldemTable Table { get; protected set; }

            public TexasHoldemRoutine(TexasHoldemTable table, TableState newState)
                : base(table, newState) 
            {
                Table = table;
            }
        }
    }
}
