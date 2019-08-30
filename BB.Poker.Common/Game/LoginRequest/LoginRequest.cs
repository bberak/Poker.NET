using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class LoginRequest : IRequestObject
    {
        public string PlayerName { get; set; }

        public string Password { get; set; }

        public string RequestId { get; set; }
    }
}
