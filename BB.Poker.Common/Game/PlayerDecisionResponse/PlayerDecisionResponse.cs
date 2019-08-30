using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class PlayerDecisionResponse : BaseClientMessageObject, IResponseObject
    {
        public DecisionType Type { get; set; }
        public double RaiseAmount { get; set; }
        public string ResponseId { get; set; }

        public PlayerDecisionResponse()
        {
            Type = DecisionType.Fold;
        }

        public static PlayerDecisionResponse GetDefaultDecision(string playerName)
        {
            PlayerDecisionResponse pd = new PlayerDecisionResponse();
            pd.PlayerName = playerName;
            pd.RaiseAmount = 0;
            pd.Type = DecisionType.Fold;
            return pd;
        }
    }
}
