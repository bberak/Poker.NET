using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BB.Poker.Common
{
    public interface IClientNetworkInterface
    {
        void Start();
        void Shutdown();
        void SendMessage(OutgoingMessage message);
        bool IsRunning { get; }
        bool IsConnected { get; }
        bool IsConnectedTo(IPEndPoint remoteEndpoint);
        string AppId { get; }
        int ContactPort { get; }
        string Host { get; }
        event MessageReceivedEventHandler MessageReceived;  
    }
}
