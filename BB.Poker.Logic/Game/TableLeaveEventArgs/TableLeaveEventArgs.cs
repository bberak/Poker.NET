using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class TableLeaveEventArgs : EventArgs
    {
        public string PlayerName { get; protected set; }

        public TableLeaveEventArgs(string playerName)
        {
            PlayerName = playerName;
        }
    }
}
