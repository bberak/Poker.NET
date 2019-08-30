using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class JoinTableResponse : IResponseObject
    {
        public bool WasJoinSuccessful { get; set; }
        public string ResponseId { get; set; }
        public string GameServerId { get; set; }
        public string PlayerName { get; set; }
        public string TableToJoin { get; set; }
        public string ServerMessage { get; set; }
    }
}
