using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.GatewayServer
{
    public class VerifyClientHandler : GatewayGameMessageHandler
    {
        public VerifyClientHandler(GatewayNetworkManager2 manager, GameMessageType target)
            : base(manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            VerifyClientRequest request = Manager.Serializer.GetObject<VerifyClientRequest>(message.Data);

            VerifyClientResponse response = new VerifyClientResponse();
            response.ResponseId = request.RequestId;
            response.IsAcceptable = Manager.IsClientVersionAcceptable(request.Client);

            if (!response.IsAcceptable)
            {
                response.ServerMessage = "Your client is out of date. Please updgrade at: http://someurl.com/download/";
            }

            Manager.SendMessageToPlayers(GameMessageType.Client_ReceiveVerifyClientResponse, Manager.Serializer.GetBytes(response), message.Sender.ToList());

            message.WasMessageHandled = true;
        }
    }
}
