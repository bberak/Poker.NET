using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class JoinTableRequest : BaseClientMessageObject, IRequestObject
    {
        public double AvailableChips { get; set; }
        public string TableToJoin { get; set; }
        public int SeatNumber { get; set; }
        public string RequestId { get; set; }
        public bool JoinAsSpectator { get; set; }
    }
}
