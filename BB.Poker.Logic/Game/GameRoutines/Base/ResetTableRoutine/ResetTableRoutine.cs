using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class BaseGameTable
    {
        protected class ResetTableRoutine : BaseGameRoutine
        {
            public ResetTableRoutine(BaseGameTable table) : base(table, TableState.Resetting) { }

            public override void Run()
            {
                base.Run();

                Table.PotManager.Reset();
                Table.TurnRiverOrFlop.Clear();
                Table.PlayerPortal.Reset();
                Table.PlayerSlots.ClearPlayerCards();
                Table.PlayerSlots.ResetPlayerStates(PlayerState.Playing);

                Table.PlayerPortal.SendPlayerSummaries(Table.Spectators + Table.PlayerSlots.GetPlayers(),
                    Table.PlayerSlots.GetPlayerSummaries().ToArray());
            }
        }
    }
}
