using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class Client
    {
        public string Version { get; set; }
        public ClientType Type { get; set; }
    }
}
