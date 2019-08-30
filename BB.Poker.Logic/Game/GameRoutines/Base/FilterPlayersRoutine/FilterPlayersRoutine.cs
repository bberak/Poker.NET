using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class BaseGameTable
    {
        protected class FilterPlayersRoutine : BaseGameRoutine
        {
            public FilterPlayersRoutine(BaseGameTable table)
                : base(table, TableState.FilteringIneligiblePlayers)
            {
            }

            public override void Run()
            {
                base.Run();
                
                foreach (PlayerSlot ps in Table.PlayerSlots)
                {
                    if (ps.HasPlayer && ps.Player.State == PlayerState.Bust)
                    {
                        Player moved = ps.Player;
                        moved.State = PlayerState.Spectating;
                        Table.PlayerSlots.RemovePlayer(moved.Name);
                        Table.Spectators.Add(moved);
                        Table.PlayerPortal.SendPersonalAnnouncement(moved, "You do not have enough money to cover the big blind. You have been moved to the spectators stand.");
                    }
                }
            }
        }
    }
}
