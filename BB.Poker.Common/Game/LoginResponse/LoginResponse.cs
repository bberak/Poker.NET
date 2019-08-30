using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class LoginResponse : IResponseObject
    {
        public string ResponseId { get; set; }

        public double AvailableFunds { get; set; }

        public bool HasLoginSucceeded { get; set; }

        public string PlayerName { get; set; }

        public string ServerMessage { get; set; }
    }
}
