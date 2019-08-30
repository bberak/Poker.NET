using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BB.Poker.Common
{
    [Serializable]
    public class GameOutcome
    {
        public bool WasItAShowDown;
        public PlayerSummary[] Winners;
        public PlayerSummary[] Losers;
    }
}
