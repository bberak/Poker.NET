using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public abstract class GameMessageQueueItem
    {
        public GameMessageType OperationCode { get; set; }
        public byte[] Data { get; set; }
    }
}
