using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class PlayerDecisionNotification : BaseClientMessageObject
    {
        public DecisionType Type { get; set; }
        public double RaiseAmount { get; set; }
        public double LatestPotValue { get; set; }
    }
}
