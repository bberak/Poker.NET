using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class TableListingResponse : IResponseObject
    {
        public TableSummary[] TableSummaries { get; set; }

        public string ResponseId { get; set; }
    }
}
