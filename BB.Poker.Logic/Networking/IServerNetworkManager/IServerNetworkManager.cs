using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public interface IServerNetworkManager
    {
        void Disconnected(IPEndPoint endpoint, int fromListenPort);
        void Connected(IPEndPoint endpoint, int fromListenPort);
        void MessageReceived(IncomingMessage msg, int fromListenPort);
        void DiscoveryRequestReceived(IPEndPoint endPoint, int onPort);
    }
}
