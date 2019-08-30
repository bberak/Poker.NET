using System;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public enum TableState
    {
        AwaitingPlayers = 0,
        Resetting = 1,
        GeneratingDealerChipIndex = 2,
        ShufflingDeck = 3,
        MovingDealerButton = 4,
        CollectingBlinds = 5,
        DealingPlayerCards = 6,
        OpeningBets = 7,
        DealingFlop = 8,
        FlopBets = 9,
        DealingTurn = 10,
        TurnBets = 11,
        DealingRiver = 12,
        RiverBets = 13,
        Evaluating = 14,
        FilteringIneligiblePlayers = 15,
        Chilling = 16
    }
}