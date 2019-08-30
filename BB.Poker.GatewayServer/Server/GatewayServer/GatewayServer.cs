using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public class GatewayServer
    {
        protected ServerNetworkManager NetworkManager;

        public GatewayServer(string appId, int clientListeningPort, string broadcastRange, int listeningPort, string serverId, ServerType type)
        {
            GatewayServerConfig config = new GatewayServerConfig();
            config.AppId = appId;
            config.BroadcastRange = broadcastRange;
            config.ClientListeningPort = clientListeningPort;
            config.ListeningPort = listeningPort;
            config.Serializer = ObjectFactory.CreateISerializeInstance();
            config.ServerId = serverId;
            config.ServerType = type;

            NetworkManager = new GatewayNetworkManager2(config);
        }

        public void Start()
        {
            NetworkManager.Start();
        }

        public void Shutdown()
        {
            NetworkManager.Shutdown();
        }
    }
}
