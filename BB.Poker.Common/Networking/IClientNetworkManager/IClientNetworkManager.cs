using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace BB.Poker.Common
{
    public interface IClientNetworkManager
    {
        void Disconnected(IPEndPoint fromEndPoint);
        void MessageReceived(IncomingMessage msg, int fromConnectToPort);
        void FailedToConnect(Exception ex);
        void Connected();
    }
}
