using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class VerifyClientResponse : IResponseObject
    {
        public string ResponseId { get; set; }

        public bool IsAcceptable { get; set; }

        public string ServerMessage { get; set; }
    }
}
