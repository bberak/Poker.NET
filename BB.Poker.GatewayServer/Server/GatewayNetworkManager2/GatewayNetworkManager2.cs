using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Net;
using Lidgren.Network;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public class GatewayNetworkManager2 : ServerNetworkManager
    {
        public enum PlayerFootprintCleanupType
        {
            CleanForTableLeaveNotice,
            CleanForPlayerLogoutNotice,
            CleanForForcedTableLeaveNotice,
            CleanForPlayerRemovalRequest,
            CleanForNetworkDisconnection, 
            CleanForSuccessfulLogin
        }

        public ConnectionTracker PlayerConnectionTracker { get; protected set; }

        public int ClientListeningPort { get; protected set; }

        public ServerInfo ServerInfo { get; protected set; }

        public IMessageQueue<OutgoingMessage> ExternalOutgoingMessageQueue { get; protected set; }

        protected List<IMessageHandler<GameMessageType>> GameMessageHandlers;

        public GatewayNetworkManager2(GatewayServerConfig config)
            : base(config)
        {
            ClientListeningPort = config.ClientListeningPort;
            NetworkAdapter.AddServerInterface(ObjectFactory.CreateIServerNetworkInterfaceInstance(AppId, ClientListeningPort, this));
            ExternalOutgoingMessageQueue = ObjectFactory.CreateIMessageQueueInstance<OutgoingMessage>();
            PlayerConnectionTracker = new ConnectionTracker();
            GameMessageHandlers = new List<IMessageHandler<GameMessageType>>();
            LoadGameMessageHandlers();

            ServerInfo = new ServerInfo();
            ServerInfo.ServerId = ServerId;
            ServerInfo.Type = ServerType.GatewayServer;

            base.CreateHiveNode(ServerInfo);
        }

        //-- Protected functionality

        protected virtual void LoadGameMessageHandlers()
        {
            GameMessageHandlers.Add(new VerifyClientHandler(this, GameMessageType.Server_ReceiveVerifyClientRequest));
            GameMessageHandlers.Add(new PlayerLoginHandler(this, GameMessageType.Server_ReceivePlayerLoginRequest));
            GameMessageHandlers.Add(new TableListingHandler(this, GameMessageType.Server_ReceiveTableListingRequest));
            GameMessageHandlers.Add(new JoinTableRequestHandler(this, GameMessageType.Server_ReceiveJoinTableRequest));
            GameMessageHandlers.Add(new PlayerLogoutHandler(this, GameMessageType.Server_ReceivePlayerLogoutNotice));
            GameMessageHandlers.Add(new TableLeaveNoticeHandler(this, GameMessageType.Server_ReceiveTableLeaveNotice));
            GameMessageHandlers.Add(new InGameMessageHandler(this, GameMessageType.Server_ReceivePlayerDecision, 
                GameMessageType.Server_ReceiveChatMessage));
        }

        protected virtual void OnReceiveMessageFromClient(IncomingMessage incomingMsg)
        {
            //-- Check first if the player is logged in before handling the message??

            foreach (IMessageHandler<GameMessageType> handler in GameMessageHandlers)
            {
                handler.Run(incomingMsg);

                if (incomingMsg.WasMessageHandled)
                    break; //-- break here if you don't want subsequent handlers to be able
                           //-- to handle this message. Might increase performance a tiny, tiny bit.
            }

            if (incomingMsg.WasMessageHandled == false)
                throw new InvalidOperationException("Message was not handled: " + GatewayGameMessageHandler.ReadMessageType(incomingMsg));
        }

        protected virtual void OnPlayerDisconnection(IPEndPoint playerEndPoint)
        {
            ConnectionRecord cr = PlayerConnectionTracker.GetRecordByIPEndPoint(playerEndPoint);
            if (cr != null)
            {
                SendPlayerRemovalRequest(cr.PlayerName, false, string.Empty);

                CleanPlayerFootprint(cr.PlayerName, PlayerFootprintCleanupType.CleanForNetworkDisconnection);

                ServerUIShell.WriteLine("-Player has disconnected from the network (" + cr.PlayerName + ")");
            }
        }

        protected override void LoadMessageHandlers()
        {
            base.LoadMessageHandlers();

            MessageHandlers.Add(new PlayerRemovalHandler(this, ServerMessageType.ReceivePlayerRemovalRequest));
            MessageHandlers.Add(new MessageToClientHandler(this, ServerMessageType.ReceiveForwardMessageToClientRequest));
        }

        protected override void OnSendMessage()
        {
            base.OnSendMessage();

            OutgoingMessage com = (OutgoingMessage)ExternalOutgoingMessageQueue.Read();

            if (com != null)
                NetworkAdapter.SendMessageThroughServer(ClientListeningPort, com);
        }

        protected override void OnHandleServerDisconnection(IPEndPoint serverEndPoint)
        {
            ServerInfo disonnectedServer = HiveNode.GetServerInfo(serverEndPoint);

            if (disonnectedServer != null && disonnectedServer.Type == ServerType.GameServer)
            {
                foreach (ConnectionRecord cr in PlayerConnectionTracker.GetRecordsByGameServerId(disonnectedServer.ServerId))
                {
                    SendForcedTableLeaveNotice(cr.PlayerName, "The table you were sitting at is no longer available.", cr.TableId);

                    CleanPlayerFootprint(cr.PlayerName, PlayerFootprintCleanupType.CleanForTableLeaveNotice);
                }
            }

            base.OnHandleServerDisconnection(serverEndPoint);
        }

        //-- Public functionality

        public virtual void CleanPlayerFootprint(string playerName, PlayerFootprintCleanupType cleanType)
        {
            if (string.IsNullOrEmpty(playerName) == false)
            {
                switch (cleanType)
                {
                    case PlayerFootprintCleanupType.CleanForTableLeaveNotice:
                    case PlayerFootprintCleanupType.CleanForForcedTableLeaveNotice:
                        PlayerConnectionTracker.UpdateRecord(playerName, string.Empty, string.Empty);
                        break;

                    case PlayerFootprintCleanupType.CleanForPlayerLogoutNotice:
                    case PlayerFootprintCleanupType.CleanForPlayerRemovalRequest:
                    case PlayerFootprintCleanupType.CleanForNetworkDisconnection:
                    case PlayerFootprintCleanupType.CleanForSuccessfulLogin:
                        PlayerConnectionTracker.Remove(playerName);
                        break;

                    default:
                        throw new NotImplementedException("Encountered an unhandled PlayerFootprintCleanupType");
                }
            }
        }

        public virtual List<IPEndPoint> ResolvePlayers(List<string> players)
        {
            List<IPEndPoint> ips = new List<IPEndPoint>();

            foreach (string name in players)
                ips.Add(ResolvePlayer(name));

            return ips;
        }

        public virtual IPEndPoint ResolvePlayer(string name)
        {
            return PlayerConnectionTracker.GetIPEndPointByPlayerName(name);
        }

        public virtual RouteInfo GetRouteInfo(string playerName)
        {
            RouteInfo rInfo = new RouteInfo();

            rInfo.GatewayServerId = ServerId;

            TinyConnectionRecord tcr = PlayerConnectionTracker.GetTinyRecordByPlayerName(playerName);

            if (tcr != null)
            {
                rInfo.GameServerId = tcr.GameServerId;

                rInfo.TableId = tcr.TableId;
            }

            return rInfo;
        }

        public virtual string GetServerWithTable(string tableId)
        {
            List<ServerInfo> gameServers = HiveNode.GetOtherServers().FindByType(ServerType.GameServer);

            foreach (GameServerInfo gsi in gameServers)
            {
                if (gsi.TableIds.Contains(tableId))
                    return gsi.ServerId;
            }

            return string.Empty;
        }

        public virtual void SendForcedTableLeaveNotice(string playerName, string message, string tableId)
        {
            ForcedTableLeaveNotice fln = new ForcedTableLeaveNotice();
            fln.PlayerName = playerName;
            fln.Message = message;
            fln.TableId = tableId;

            SendMessageToPlayers(GameMessageType.Client_ReceiveForcedTableLeaveNotice, fln, playerName.ToList());

            ServerUIShell.WriteLine("-Player has been instructed to leave table (" + playerName + ")");
        }

        public virtual void SendLogoutRequest(string playerName, string message)
        {
            ForcedPlayerLogoutNotice fln = new ForcedPlayerLogoutNotice();
            fln.Message = message;

            SendMessageToPlayers(GameMessageType.Client_ReceiveForcedPlayerLogoutNotice, fln, playerName.ToList());

            ServerUIShell.WriteLine("-Player has been instructed to logout (" + playerName + ")");
        }

        public virtual void SendMessageToPlayers(GameMessageType messageType, object dataObject, List<string> players)
        {
            SendMessageToPlayers(messageType, Serializer.GetBytes(dataObject), players);
        }

        public virtual void SendMessageToPlayers(GameMessageType messageType, byte[] data, List<string> players)
        {
            SendMessageToPlayers(messageType, data, ResolvePlayers(players));
        }

        public virtual void SendMessageToPlayers(GameMessageType messageType, byte[] data, List<IPEndPoint> players)
        {
            OutgoingMessage com = ServerMessageFormatter.CreateOutgoingMessage(
                (int)messageType,
                data,
                players);

            ExternalOutgoingMessageQueue.Add(com);
        }

        public virtual void SendPlayerRemovalRequest(string playerName, bool alsoSendToOtherGateways, string message)
        {
            PlayerRemovalRequest prr = new PlayerRemovalRequest();
            prr.SenderServerId = ServerId;
            prr.RequestId = Guid.NewGuid().ToString();
            prr.Message = message;
            prr.PlayerName = playerName;
            List<string> serverIds = new List<string>();

            TinyConnectionRecord tcr = PlayerConnectionTracker.GetTinyRecordByPlayerName(playerName);

            if (tcr != null && tcr.IsSittingAtTable())
            {
                serverIds.Add(tcr.GameServerId);
                prr.TableId = tcr.TableId;
            }

            if (alsoSendToOtherGateways)
            {
                List<string> gateways = HiveNode.GetOtherServers().FindByType(ServerType.GatewayServer).GetServerIds();
                if (gateways != null && gateways.Count > 0)
                    serverIds.AddRange(gateways);
            }

            if (serverIds.Count > 0)
                SendPlainObjectToServer(ServerMessageType.ReceivePlayerRemovalRequest, prr, ResolveServers(serverIds));

        }

        public virtual void SendEnvelopeObjectToServer(GameMessageType messageType, byte[] innerData, List<IPEndPoint> receivers, RouteInfo routeInfo)
        {
            ServerEnvelopeObject envelope = new ServerEnvelopeObject();
            envelope.InnerOperationCode = (int)messageType;
            envelope.InnerData = innerData;
            envelope.SenderServerId = ServerId;
            envelope.RouteInfo = routeInfo;

            OutgoingMessage com = ServerMessageFormatter.CreateOutgoingMessage(
                (int)ServerMessageType.ReceiveForwardedMessageFromClient,
                Serializer.GetBytes(envelope),
                receivers);

            InternalOutgoingMessageQueue.Add(com);
        }

        public virtual void SendPlainObjectToServer(ServerMessageType messageType, object dataObject, List<IPEndPoint> receivers)
        {
            OutgoingMessage com = ServerMessageFormatter.CreateOutgoingMessage(
                (int)messageType,
                Serializer.GetBytes(dataObject),
                receivers);

            InternalOutgoingMessageQueue.Add(com);
        }

        public virtual bool IsClientVersionAcceptable(Client client)
        {
            Version minimumClientVersion = new Version("0.1.0.0");
            Version usersVersion = new Version(client.Version);

            if (minimumClientVersion.CompareTo(usersVersion) > 0)
                return false;
            else
                return true;
        }

        public override void MessageReceived(IncomingMessage incomingMsg, int fromListenPort)
        {
            base.MessageReceived(incomingMsg, fromListenPort);

            if (fromListenPort == ClientListeningPort)
                OnReceiveMessageFromClient(incomingMsg);
        }

        public override void Disconnected(IPEndPoint endpoint, int fromListenPort)
        {
            base.Disconnected(endpoint, fromListenPort);

            if (fromListenPort == ClientListeningPort)
                OnPlayerDisconnection(endpoint);
        }
    }
}
