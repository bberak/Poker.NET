using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public class PlayerDecisionRequest : IRequestObject
    {
        public double MinimumBet { get; set; }

        public string RequestId { get; set; }

        public DecisionType[] AvailableOptions { get; set; }
    }
}
