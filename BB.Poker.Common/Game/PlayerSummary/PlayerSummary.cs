using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class PlayerSummary
    {
        public string Name;
        public double Chips;
        public int Position;
        public PlayerState State;
    }
}
