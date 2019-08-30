using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public interface IGameTable
    {
        double SmallBlind { get; }
        double BigBlind { get; }
        string TableId { get; }
        string ServerId { get; }
        string Description { get; }
        bool IsOpen { get; }
        bool IsChatEnabled { get; }
        double CurrentPotValue { get; }
        int DealerChipIndex { get; }
        PokerType PokerType { get; }
        IPlayerPortal PlayerPortal { get; }
        TableState CurrentState { get; }
        void OpenTable();
        void CloseTable();
        TableSummary GetSummary();
        bool Equals(object obj);
        int GetHashCode();
    }
}
