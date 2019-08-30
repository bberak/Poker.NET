using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public class TableItemClickedEventArgs : EventArgs
    {
        public TableSummary ChosenTable { get; protected set; }

        public TableItemClickedEventArgs(TableSummary ts)
        {
            ChosenTable = ts;
        }
    }

    public delegate void TableItemClickedEventHandler(object sender, TableItemClickedEventArgs e);
}
