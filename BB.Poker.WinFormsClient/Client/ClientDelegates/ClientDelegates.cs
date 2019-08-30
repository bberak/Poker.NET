using System;
using System.Collections;
using System.Collections.Generic;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public delegate void UpdatePlayerSummariesListDelegate(PlayerSummary[] summaries);
    public delegate void UpdateTableSummaryDelegate(TableSummary ts);
}
