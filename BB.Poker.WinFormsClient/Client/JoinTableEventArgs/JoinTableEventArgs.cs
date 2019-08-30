using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public class JoinTableEventArgs : EventArgs
    {
        public TableSummary TargetTable {get; protected set;}
        public int AtPosition { get; protected set; }

        public JoinTableEventArgs(TableSummary target, int pos)
        {
            TargetTable = target;
            AtPosition = pos;
        }
    }

    public delegate void JoinTableEventHandler(object sender, JoinTableEventArgs e);
}
