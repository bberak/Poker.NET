using System;
using System.Text;
using Newtonsoft.Json;

namespace BB.Poker.Common
{
    [Serializable]
    public enum Combination
    {
        Unassigned = 0,
        HighCard = 1,
        OnePair = 2,
        TwoPair = 3,
        ThreeOfAKind = 4,
        Straight = 5,
        Flush = 6,
        FullHouse = 7,
        FourOfAKind = 8,
        StraightFlush = 9,
        RoyalFlush = 10
    }
}