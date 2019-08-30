using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public class JoinTableRequestHandler : GatewayGameMessageHandler
    {
        public JoinTableRequestHandler(GatewayNetworkManager2 manager, GameMessageType target)
            : base(manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            JoinTableRequest request = Manager.Serializer.GetObject<JoinTableRequest>(message.Data);

            RouteInfo routeInfo = Manager.GetRouteInfo(request.PlayerName);

            string gameServerId = Manager.GetServerWithTable(request.TableToJoin);

            //-- Stop people trying to bring down the server by sending join requests to tables that do not exist.
            if (string.IsNullOrEmpty(gameServerId) == false)
            {
                IPEndPoint serverEndpoint = Manager.ResolveServer(gameServerId);

                //-- Has the destination server been found?
                if (serverEndpoint != null)
                {
                    Manager.SendEnvelopeObjectToServer(GameMessageType.Server_ReceiveJoinTableRequest,
                        Manager.Serializer.GetBytes(request),
                        serverEndpoint.ToList(),
                        routeInfo);
                }
                else
                {
                    ServerUIShell.WriteLine("-IPEndPoint for server could not be resolved (" + gameServerId + ")");
                }
            }

            message.WasMessageHandled = true;
        }
    }
}
