using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BB.Poker.Common
{
    [Serializable]
    public class GameOutcome2
    {
        public bool WasItAShowDown {get; set; }

        public PlayerResult[] Winners { get; set; }

        //-- Should be no losers if it was not a showdown (GameOutcome2 only documents losers if it was a showdown)
        public PlayerResult[] Losers { get; set; }

        public void ClearHands()
        {
            foreach (PlayerResult winner in Winners)
                winner.Hand.Clear();

            foreach (PlayerResult loser in Losers)
                loser.Hand.Clear();
        }
    }
}
