using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    [Serializable]
    public class PlayerRemovalRequest : BaseServerMessageObject, IRequestObject
    {
        public string PlayerName { get; set; }

        public string TableId { get; set; }

        public string RequestId { get; set; }

        public string Message { get; set; }
    }
}
