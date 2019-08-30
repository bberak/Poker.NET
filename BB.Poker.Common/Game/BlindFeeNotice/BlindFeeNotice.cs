using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{ 
    [Serializable]
    public class BlindFeeNotice
    {
        public string SmallBlindPlayer;
        public string BigBlindPlayer;
        public double SmallBlindPlayerTotalChips;
        public double BigBlindPlayerTotalChips;
        public double SmallBlindAmount;
        public double BigBlindAmount;
    }
}
