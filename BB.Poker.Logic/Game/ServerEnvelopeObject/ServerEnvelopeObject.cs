using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Logic
{
    [Serializable]
    public class ServerEnvelopeObject : BaseServerMessageObject
    {
        public int InnerOperationCode { get; set; }

        public byte[] InnerData { get; set; }

        public RouteInfo RouteInfo { get; set; }
    }
}
