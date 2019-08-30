using System;

namespace BB.Poker.Common
{
    public enum JoinTableInfo
    {
        JoinedButWaitingForPlayers = 0,
        InsufficientFunds = 1,
        JoinedButWaitingForNextGame = 2,
        SeatAlreadyTaken = 3,
        TableFull = 4,
        TableDoesNotExist = 5,
        JoinedAndStartingNewGame = 6
    }
}