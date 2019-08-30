using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public delegate void MessageReceivedDelegate(IncomingMessage incomingMessage, IServerNetworkInterface source);
    public delegate void DisconnectedDelegate(IPEndPoint disconnectedFrom, IServerNetworkInterface source);
}
