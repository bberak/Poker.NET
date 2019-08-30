using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public class InGameMessageHandler : BaseMultiMessageHandler<GameMessageType>
    {
        public GatewayNetworkManager2 Manager { get; protected set; }

        public InGameMessageHandler(GatewayNetworkManager2 manager, params GameMessageType[] targets)
            : base(targets)
        {
            Manager = manager;
        }

        protected override void OnRun(IncomingMessage message)
        {
            //-- These messages should be forwarded to the appropriate GameServer.

            BaseClientMessageObject baseMessage = Manager.Serializer.GetObject<BaseClientMessageObject>(message.Data);

            RouteInfo rInfo = Manager.GetRouteInfo(baseMessage.PlayerName);

            if (rInfo.IsRoutedToTable())
            {
                IPEndPoint serverEndPoint = Manager.ResolveServer(rInfo.GameServerId);

                //-- Has the destination server been found?
                if (serverEndPoint != null)
                {
                    Manager.SendEnvelopeObjectToServer((GameMessageType)message.OperationCode,
                        message.Data,
                        serverEndPoint.ToList(), rInfo);
                }
                else
                {
                    ServerUIShell.WriteLine("-IPEndPoint for server could not be resolved (" + rInfo.GameServerId + ")");
                }
            }
            else
            {
                ServerUIShell.WriteLine("-Player has sent a game message without sitting at a table (" + baseMessage.PlayerName + ")");
            }

            message.WasMessageHandled = true;
        }
    }
}
