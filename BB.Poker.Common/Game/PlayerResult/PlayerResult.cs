using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class PlayerResult
    {
        public PlayerSummary PlayerSummary { get; set; }
        public Hand Hand { get; set; }
        public double ProfitOrLoss { get; set; }
    }
}
