using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class ServerReferenceRequestHandler : ServerMessageHandler
    {
        public ServerReferenceRequestHandler(ServerNetworkManager manager, ServerMessageType target)
            : base(manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            Manager.HiveNode.SendServerReferenceTo(message.Sender, Manager.ListeningPort);

            message.WasMessageHandled = true;
        }
    }
}
