using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class ForcedTableLeaveNotice
    {
        public string Message { get; set; }

        public string TableId { get; set; }

        public string PlayerName { get; set; }
    }
}
