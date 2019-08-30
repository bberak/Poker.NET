using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic.Hive
{
    public class HiveNode : IHiveNode<ServerInfo>
    {
        protected HiveConnectionTracker nodeTracker;
        protected INetworkAdapter networkAdapter;
        protected ServerInfo myInfo;
        protected ISerialize serializer;
        protected int listeningPort;

        public HiveNode(INetworkAdapter adapter, ISerialize serializer, ServerInfo myInfo, int listeningPort)
        {
            nodeTracker = new HiveConnectionTracker();
            networkAdapter = adapter;
            this.myInfo = myInfo;
            this.serializer = serializer;
            this.listeningPort = listeningPort;
        }

        public virtual List<ServerInfo> GetOtherServers()
        {
            List<ServerInfo> allServers = new List<ServerInfo>();

            foreach (HiveConnectionRecord hcr in nodeTracker)
                allServers.Add(hcr.ServerInfo);

            return allServers;
        }

        public virtual void SendDiscoveryBeacons(string broadcastRange)
        {
            ServerUIShell.WriteLine("-Beginning Port Scan...");

            for (int i = broadcastRange.GetLowerBroadcastPort(); i <= broadcastRange.GetUpperBroadcastPort(); i++)
            {
                ServerUIShell.WriteLine("-Sending DiscoveryBeacon on: " + listeningPort + "/" + i + " (SourcePort/DestinationPort)");
                networkAdapter.SendDiscoveryRequest(listeningPort, i);
            }

            ServerUIShell.WriteLine("-Port Scan Complete...");
        }

        public virtual void HandleIncomingDiscoveryRequest(System.Net.IPEndPoint sender, int broadcastPort)
        {
            ServerUIShell.WriteLine("-Detected DiscoveryRequest from: " + sender.ToString() + " (on " + broadcastPort + ")");

            //-- If you trust this endpoint, connect to it.
            networkAdapter.ConnectServerTo(listeningPort, sender);
        }

        public virtual void HandleIncomingDiscoveryResponse(byte[] data, IPEndPoint endpoint)
        {
            ServerInfo info = serializer.GetObject<ServerInfo>(data);

            if (info.Type == ServerType.GameServer)
            {
                info = serializer.GetObject<GameServerInfo>(data);
            }

            ServerUIShell.WriteLine("-Saving ServerReference: " + info.Type.ToString() + " (" + endpoint.ToString() + ")");

            HiveConnectionRecord hcr = new HiveConnectionRecord(info, endpoint);

            nodeTracker.AddOrUpdateRecord(hcr);
        }

        public virtual void SendServerReferenceTo(IPEndPoint endPoint, int onInterfacePort)
        {
            //-- If im already connected to this server
            if (networkAdapter.IsServerConnectedTo(endPoint, onInterfacePort))
            {
                ServerUIShell.WriteLine("-Sending ServerReference to " + endPoint.ToString() + " (via " + onInterfacePort + ")");
                ServerInfo info = myInfo;

                OutgoingMessage com = ServerMessageFormatter.CreateOutgoingMessage(
                    (int)ServerMessageType.ReceiveServerReference,
                    serializer.GetBytes(info),
                    endPoint.ToList());

                networkAdapter.SendMessageThroughServer(onInterfacePort, com);
            }
            else
            {
                //-- Else connect first
                networkAdapter.ConnectServerTo(onInterfacePort, endPoint);
            }
        }

        public virtual void HandleDisconnection(IPEndPoint endpoint)
        {
            HiveConnectionRecord hcr = nodeTracker.FindByIPEndPoint(endpoint);

            if (hcr != null)
            {
                if (nodeTracker.Remove(hcr.ServerInfo.ServerId))
                    ServerUIShell.WriteLine("-Server @ " + endpoint.ToString() + " has disconnected");
            }
        }

        public virtual void HandleConnection(IPEndPoint endpoint)
        {
            //-- If you don't trust this endpoint, you can disconnect it from the
            //-- server interface.

            //-- If you trust this endpoint, notify it of your existence.
            SendServerReferenceTo(endpoint, listeningPort);
        }

        public virtual IPEndPoint FindBy(ServerInfo key)
        {
            return FindBy(key.ServerId);
        }

        public virtual IPEndPoint FindBy(string serverId)
        {
            return nodeTracker.GetEndPoint(serverId);
        }

        public virtual ServerInfo GetServerInfo(IPEndPoint endpoint)
        {
            HiveConnectionRecord hcr = nodeTracker.FindByIPEndPoint(endpoint);

            if (hcr != null)
                return hcr.ServerInfo;

            return null;
        }
    }
}
