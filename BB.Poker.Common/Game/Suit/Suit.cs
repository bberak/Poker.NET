using System;
using System.Text;
using Newtonsoft.Json;

namespace BB.Poker.Common
{
    [Serializable]
    public enum Suit
    {
        Unassigned, 
        Diamonds, 
        Hearts, 
        Clubs, 
        Spades
    }
}