using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public abstract class GatewayServerMessageHandler : ServerMessageHandler
    {
        public new GatewayNetworkManager2 Manager { get; protected set; }

        public GatewayServerMessageHandler(GatewayNetworkManager2 manager, ServerMessageType target)
            : base(manager, target)
        {
            Manager = manager;
        }
    }
}
