using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class NetworkAdapter : INetworkAdapter
    {
        public List<IServerNetworkInterface> ServerInterfaces { get; protected set; }
        public List<IClientNetworkInterface> ClientInterfaces { get; protected set; }

        public string AppId { get; protected set; }
        public bool IsRunning { get; protected set; }

        public NetworkAdapter(string appId)
        {
            AppId = appId;
            ServerInterfaces = new List<IServerNetworkInterface>();
            ClientInterfaces = new List<IClientNetworkInterface>();
        }

        public void Start()
        {
            foreach (IServerNetworkInterface inf in ServerInterfaces)
                inf.Start();

            foreach (IClientNetworkInterface inf in ClientInterfaces)
                inf.Start();

            IsRunning = true;
        }

        public void Shutdown()
        {
            foreach (IServerNetworkInterface inf in ServerInterfaces)
                inf.Shutdown();

            foreach (IClientNetworkInterface inf in ClientInterfaces)
                inf.Shutdown();

            IsRunning = false;
        }

        #region INetworkAdapter Members


        public void SendMessageThroughClient(int port, OutgoingMessage om)
        {
            foreach (IClientNetworkInterface inf in ClientInterfaces)
            {
                if (inf.ContactPort == port)
                    inf.SendMessage(om);
            }
        }

        public void SendMessageThroughServer(int port, OutgoingMessage om)
        {
            foreach (IServerNetworkInterface inf in ServerInterfaces)
            {
                if (inf.Port == port)
                    inf.SendMessage(om);
            }
        }

        public void SendUnconnectedMessageThroughServer(int port, UnconnectedOutgoingMessage om)
        {
            foreach (IServerNetworkInterface inf in ServerInterfaces)
            {
                if (inf.Port == port)
                    inf.SendUnconnectedMessage(om);
            }
        }

        public void SendDiscoveryRequest(int viaPort, int listeningOnPort)
        {
            foreach (IServerNetworkInterface inf in ServerInterfaces)
            {
                if (inf.Port == viaPort)
                    inf.SendDiscoveryRequest(listeningOnPort);
            }
        }

        public void DisconnectFromServer(IPEndPoint remoteEndPoint, int viaPort, string byeMessage)
        {
            foreach (IServerNetworkInterface inf in ServerInterfaces)
            {
                if (inf.Port == viaPort)
                    inf.Disconnect(remoteEndPoint, byeMessage);
            }
        }

        public void ConnectServerTo(int interfacePort, IPEndPoint remoteEndPoint)
        {
            foreach (IServerNetworkInterface inf in ServerInterfaces)
            {
                if (inf.Port == interfacePort)
                    inf.Connect(remoteEndPoint);
            }
        }

        public bool IsServerConnectedTo(IPEndPoint remoteEndpoint, int serverInterfacePort)
        {
            foreach (IServerNetworkInterface inf in ServerInterfaces)
            {
                if (inf.Port == serverInterfacePort)
                    return inf.IsConnectedTo(remoteEndpoint);
            }

            throw new InvalidOperationException("Server interface port (" + serverInterfacePort + ") could not be found.");
        }

        public bool IsClientConnectedTo(IPEndPoint remoteEndpoint, int clientInterfacePort)
        {
            foreach (IClientNetworkInterface inf in ClientInterfaces)
            {
                if (inf.ContactPort == clientInterfacePort)
                    return inf.IsConnectedTo(remoteEndpoint);
            }

            throw new InvalidOperationException("Client interface port (" + clientInterfacePort + ") could not be found.");
        }

        public void AddClientInterface(IClientNetworkInterface clientInf)
        {
            if (IsRunning)
                throw new InvalidOperationException("An interface cannot be added whilst the network adapter is running, if you want this functionality implement the ThreadSafeList component.");

            ClientInterfaces.Add(clientInf);
        }

        public void AddServerInterface(IServerNetworkInterface serverInf)
        {
            if (IsRunning)
                throw new InvalidOperationException("An interface cannot be added whilst the network adapter is running, if you want this functionality implement the ThreadSafeList component.");

            ServerInterfaces.Add(serverInf);
        }

        #endregion
    }
}
