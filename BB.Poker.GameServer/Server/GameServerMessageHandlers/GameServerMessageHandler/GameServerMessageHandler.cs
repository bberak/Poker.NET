using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GameServer
{
    public abstract class GameServerMessageHandler : ServerMessageHandler
    {
        public new GameNetworkManager2 Manager { get; protected set; }

        public GameServerMessageHandler(GameNetworkManager2 manager, ServerMessageType target)
            : base(manager, target)
        {
            Manager = manager;
        }
    }
}
