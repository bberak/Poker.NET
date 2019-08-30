using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class Bet
    {
        public readonly double Value;
        public readonly Player Player;
        public readonly TableState TableState;

        public Bet(Player player, double value)
        {
            this.Player = player;
            this.Value = value;
        }

        public Bet(Player player, double value, TableState tState)
        {
            this.Player = player;
            this.Value = value;
            this.TableState = tState;
        }
    }
}
