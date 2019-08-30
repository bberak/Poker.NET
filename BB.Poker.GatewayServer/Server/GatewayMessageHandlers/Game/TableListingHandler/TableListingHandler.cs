using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public class TableListingHandler : GatewayGameMessageHandler
    {
        public TableListingHandler(GatewayNetworkManager2 manager, GameMessageType target)
            : base(manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            BaseClientMessageObject baseMessage = Manager.Serializer.GetObject<BaseClientMessageObject>(message.Data);

            RouteInfo rInfo = Manager.GetRouteInfo(baseMessage.PlayerName);

            List<string> serverIds = Manager.HiveNode.GetOtherServers().FindByType(ServerType.GameServer).GetServerIds();

            List<IPEndPoint> gameServers = Manager.ResolveServers(serverIds);

            Manager.SendEnvelopeObjectToServer((GameMessageType)message.OperationCode, message.Data, gameServers, rInfo);

            message.WasMessageHandled = true;
        }
    }
}
