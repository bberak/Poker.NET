using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class ChatMessage : BaseClientMessageObject
    {
        public string Message { get; set; }
    }
}
