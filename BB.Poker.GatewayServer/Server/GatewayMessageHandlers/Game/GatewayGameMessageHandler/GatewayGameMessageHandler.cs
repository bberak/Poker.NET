using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.GatewayServer
{
    public abstract class GatewayGameMessageHandler : BaseMessageHandler<GameMessageType>
    {
        public GatewayNetworkManager2 Manager { get; protected set; }

        public GatewayGameMessageHandler(GatewayNetworkManager2 manager, GameMessageType target)
            : base (target)
        {
            Manager = manager;
        }
    }
}
