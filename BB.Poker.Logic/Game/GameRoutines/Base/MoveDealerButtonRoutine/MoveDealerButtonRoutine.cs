using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class BaseGameTable
    {
        protected class MoveDealerButtonRoutine : BaseGameRoutine
        {
            public MoveDealerButtonRoutine(BaseGameTable table)
                : base(table, TableState.MovingDealerButton)
            {
            }

            public override void Run()
            {
                base.Run();

                if (!Table.HasMinimumNumberOfActivePlayers()) return;
                  
                BaseGameTable bgt = Table;

                bgt.PlayerSlots.MoveDealerButton();

                bgt.PlayerPortal.SendDealerButtonMoved(bgt.Spectators + bgt.PlayerSlots.GetPlayers(),
                    bgt.PlayerSlots.GetDealerButtonPosition());
            }
        }
    }
}
