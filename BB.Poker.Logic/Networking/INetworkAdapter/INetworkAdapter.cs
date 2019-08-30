using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public interface INetworkAdapter
    {
        void Start();
        void Shutdown();
        string AppId { get; }
        void AddServerInterface(IServerNetworkInterface serverInf);
        void AddClientInterface(IClientNetworkInterface clientInf);
        void SendMessageThroughClient(int viaPort, OutgoingMessage om);
        void SendMessageThroughServer(int viaPort, OutgoingMessage om);
        void SendUnconnectedMessageThroughServer(int viaPort, UnconnectedOutgoingMessage om);
        void SendDiscoveryRequest(int viaPort, int listeningOnPort);
        void DisconnectFromServer(IPEndPoint remoteEndPoint, int viaPort, string byeMessage);
        void ConnectServerTo(int interfacePort, IPEndPoint remoteEndPoint);
        bool IsServerConnectedTo(IPEndPoint remoteEndpoint, int serverInterfacePort);
        bool IsClientConnectedTo(IPEndPoint remoteEndpoint, int clientInterfacePort);
        List<IServerNetworkInterface> ServerInterfaces { get; }
        List<IClientNetworkInterface> ClientInterfaces { get; }
    }
}
