using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class OutgoingGameMessageQueueItem : GameMessageQueueItem
    {
        public List<Player> Recipients { get; set; }
    }
}
