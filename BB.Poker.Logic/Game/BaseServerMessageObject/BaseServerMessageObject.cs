using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Logic
{
    [Serializable]
    public abstract class BaseServerMessageObject
    {
        public string SenderServerId { get; set; }
    }
}
