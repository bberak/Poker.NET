using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class ReceiveServerReferenceHandler : ServerMessageHandler
    {
        public ReceiveServerReferenceHandler(ServerNetworkManager manager, ServerMessageType target)
            : base(manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            Manager.HiveNode.HandleIncomingDiscoveryResponse(message.Data, message.Sender);

            message.WasMessageHandled = true;
        }
    }
}
