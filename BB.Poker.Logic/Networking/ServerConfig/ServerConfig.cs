using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public abstract class ServerConfig
    {
        public string AppId { get; set; }

        public string ServerId { get; set; }

        public ISerialize Serializer { get; set; }

        public string BroadcastRange { get; set; }

        public int ListeningPort { get; set; }

        public ServerType ServerType  { get; set; }
    }
}
