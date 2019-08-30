using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public class GatewayServerConfig : ServerConfig
    {
        public int ClientListeningPort { get; set; }
    }
}
