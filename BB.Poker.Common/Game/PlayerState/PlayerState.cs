using System;
using System.Text;

namespace BB.Poker.Common
{
    [Flags]
    [Serializable]
    public enum PlayerState
    {
        Spectating = 1,
        Bust = 2,
        JustSatDown = 4,
        Folded = 8,
        Playing = 16,
        AllIn = 32
    }
}