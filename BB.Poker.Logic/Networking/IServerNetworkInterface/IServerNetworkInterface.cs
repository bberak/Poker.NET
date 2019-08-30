using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public interface IServerNetworkInterface
    {
        void Start();
        void Shutdown();
        void SendMessage(OutgoingMessage message);
        void SendUnconnectedMessage(UnconnectedOutgoingMessage message);
        void SendDiscoveryRequest(int port);
        void Disconnect(IPEndPoint remoteEndPoint, string byeMessage);
        void Connect(IPEndPoint remoteEndPoint);
        bool IsConnectedTo(IPEndPoint remoteEndpoint);
        bool IsRunning { get; }
        string AppId { get; }
        int Port { get; }
        IPAddress Address { get; }
        event MessageReceivedEventHandler MessageReceived;
    }
}
