using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GameServer
{
    public class MessageFromClientHandler : GameServerMessageHandler
    {
        public MessageFromClientHandler(GameNetworkManager2 manager, ServerMessageType target)
            : base(manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            ServerEnvelopeObject envelope = Manager.Serializer.GetObject<ServerEnvelopeObject>(message.Data);
            GameMessageType gmt = (GameMessageType)Enum.ToObject(typeof(GameMessageType), envelope.InnerOperationCode);

            switch (gmt)
            {
                case GameMessageType.Server_ReceiveTableListingRequest:
                    OnTableListingRequest(Manager.Serializer.GetObject<TableListingRequest>(envelope.InnerData), envelope.RouteInfo);
                    break;

                case GameMessageType.Server_ReceiveJoinTableRequest:
                    OnJoinTableRequest(envelope);
                    break;

                default:
                    IncomingGameMessageQueueItem defaultItem = new IncomingGameMessageQueueItem();
                    defaultItem.OperationCode = (GameMessageType)envelope.InnerOperationCode;
                    defaultItem.Data = envelope.InnerData;
                    defaultItem.RouteInfo = envelope.RouteInfo;

                    Manager.Tables[defaultItem.RouteInfo.TableId].PlayerPortal.IncomingQueue.Add(defaultItem);
                    break;
            }

            message.WasMessageHandled = true;
        }

        protected void OnTableListingRequest(TableListingRequest listingRequest, RouteInfo routeInfo)
        {
            TableListingResponse listingResponse = new TableListingResponse();
            listingResponse.ResponseId = listingRequest.RequestId;
            listingResponse.TableSummaries = Manager.Tables.GetTableSummaries();

            ClientBoundSeverEnvelopeObject envelope = new ClientBoundSeverEnvelopeObject();
            envelope.InnerData = Manager.Serializer.GetBytes(listingResponse);
            envelope.InnerOperationCode = (int)GameMessageType.Client_ReceiveTableListingResponse;
            envelope.SenderServerId = Manager.ServerInfo.ServerId;
            envelope.PlayerNames = listingRequest.PlayerName.ToList();

            OutgoingMessage outgoingMessage = ServerMessageFormatter.CreateOutgoingMessage(
                     (int)ServerMessageType.ReceiveForwardMessageToClientRequest,
                     Manager.Serializer.GetBytes(envelope),
                     Manager.ResolveServers(routeInfo.GatewayServerId.ToList()));

            Manager.InternalOutgoingMessageQueue.Add(outgoingMessage);
        }

        protected virtual void OnJoinTableRequest(ServerEnvelopeObject envelope)
        {
            JoinTableRequest jtres = Manager.Serializer.GetObject<JoinTableRequest>(envelope.InnerData);

            IncomingGameMessageQueueItem joinTableItem = new IncomingGameMessageQueueItem();
            joinTableItem.OperationCode = (GameMessageType)envelope.InnerOperationCode;
            joinTableItem.Data = envelope.InnerData;
            joinTableItem.RouteInfo = envelope.RouteInfo;

            Manager.Tables[jtres.TableToJoin].PlayerPortal.IncomingQueue.Add(joinTableItem);
        }
    }
}
