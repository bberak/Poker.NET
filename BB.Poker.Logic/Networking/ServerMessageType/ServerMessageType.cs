using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Logic
{
    public enum ServerMessageType
    {
        ReceiveServerReferenceRequest,
        ReceiveServerReference,
        ReceiveForwardedMessageFromClient,
        ReceiveForwardMessageToClientRequest,
        ReceivePlayerRemovalRequest
    }
}
