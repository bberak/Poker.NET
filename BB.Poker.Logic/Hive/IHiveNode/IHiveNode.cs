using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using BB.Poker.Logic;

namespace BB.Poker.Logic.Hive
{
    public interface IHiveNode<T>
    {
        List<T> GetOtherServers();

        void SendDiscoveryBeacons(string broadcastRange);

        void HandleIncomingDiscoveryRequest(IPEndPoint sender, int onListenPort);

        void HandleIncomingDiscoveryResponse(byte[] data, IPEndPoint endpoint);

        void SendServerReferenceTo(IPEndPoint endPoint, int onInterfacePort);

        void HandleDisconnection(IPEndPoint endpoint);

        void HandleConnection(IPEndPoint endpoint);

        IPEndPoint FindBy(string serverId);

        IPEndPoint FindBy(T key);

        ServerInfo GetServerInfo(IPEndPoint endpoint);
    }
}
