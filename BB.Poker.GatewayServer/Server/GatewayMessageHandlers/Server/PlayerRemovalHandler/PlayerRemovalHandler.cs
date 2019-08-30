using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public class PlayerRemovalHandler : GatewayServerMessageHandler
    {
        public PlayerRemovalHandler(GatewayNetworkManager2 manager, ServerMessageType target)
            : base(manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            PlayerRemovalRequest prr = Manager.Serializer.GetObject<PlayerRemovalRequest>(message.Data);

            ConnectionRecord cr = Manager.PlayerConnectionTracker.GetRecordByPlayerName(prr.PlayerName);

            Manager.SendLogoutRequest(prr.PlayerName, prr.Message);

            Manager.CleanPlayerFootprint(prr.PlayerName, GatewayNetworkManager2.PlayerFootprintCleanupType.CleanForPlayerRemovalRequest);

            message.WasMessageHandled = true;
        }
    }
}
