using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class BaseGameTable
    {
        protected class ChillRoutine : BaseGameRoutine
        {
            public int LengthInMilliseconds { get; protected set; }

            public ChillRoutine(BaseGameTable table, int length)
                : base(table, TableState.Chilling)
            {
            }

            public override void Run()
            {
                base.Run();

                Thread.Sleep(LengthInMilliseconds);

                //-- No point informing players that the table is "chilling"...
            }
        }
    }
}
