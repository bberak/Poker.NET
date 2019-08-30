using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using BB.Poker.GameServer.Properties;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GameServer
{
    public class GameNetworkManager2 : ServerNetworkManager
    {
        public GameTableCollection Tables { get; protected set; }

        public GameServerInfo ServerInfo { get; protected set; }

        public GameNetworkManager2(GameServerConfig config)
            : base (config)
        {
            Tables = config.Tables;

            ServerInfo = new GameServerInfo();
            ServerInfo.ServerId = ServerId;
            ServerInfo.Type = Type;

            foreach (IGameTable gt in Tables)
            {
                ServerInfo.TableIds.Add(gt.TableId);
            }

            base.CreateHiveNode(ServerInfo);     
        }

        //-- Protected functionality

        protected override void LoadMessageHandlers()
        {
            base.LoadMessageHandlers();

            MessageHandlers.Add(new MessageFromClientHandler(this, ServerMessageType.ReceiveForwardedMessageFromClient));
            MessageHandlers.Add(new PlayerRemovalHandler(this, ServerMessageType.ReceivePlayerRemovalRequest));
        }

        protected override void OnSendMessage()
        {
            base.OnSendMessage();

            foreach (IGameTable gt in Tables)
            {
                OutgoingGameMessageQueueItem msg = (OutgoingGameMessageQueueItem)gt.PlayerPortal.OutgoingQueue.Read();
                if (msg != null)
                {
                    ClientBoundSeverEnvelopeObject envelope = new ClientBoundSeverEnvelopeObject();
                    envelope.InnerData = msg.Data;
                    envelope.InnerOperationCode = (int)msg.OperationCode;
                    envelope.SenderServerId = ServerInfo.ServerId;
                    envelope.PlayerNames = msg.Recipients.GetPlayerNames();

                    OutgoingMessage com = ServerMessageFormatter.CreateOutgoingMessage(
                             (int)ServerMessageType.ReceiveForwardMessageToClientRequest,
                             Serializer.GetBytes(envelope),
                             ResolveServers(msg.Recipients.GetUniqueGatewayServerIds()));

                    NetworkAdapter.SendMessageThroughServer(ListeningPort, com);
                }
            }
        }
    }
}
