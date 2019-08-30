using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class BaseClientMessageObject
    {
        public string PlayerName { get; set; }
    }
}
