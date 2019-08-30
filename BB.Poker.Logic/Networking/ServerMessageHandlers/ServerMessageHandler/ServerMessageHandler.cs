using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public abstract class ServerMessageHandler : BaseMessageHandler<ServerMessageType>
    {
        public ServerNetworkManager Manager { get; protected set; }

        public ServerMessageHandler(ServerNetworkManager manager, ServerMessageType target)
            : base(target)
        {
            Manager = manager;      
        }
    }
}
