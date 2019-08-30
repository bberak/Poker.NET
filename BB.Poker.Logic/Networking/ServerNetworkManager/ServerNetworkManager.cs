using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using BB.Poker.Common;
using BB.Poker.Logic.Hive;

namespace BB.Poker.Logic
{
    public abstract class ServerNetworkManager : BaseNetworkManager<ServerMessageType>, IServerNetworkManager
    {
        protected Thread SendThread;
 
        public string ServerId { get; protected set; }
        public int ListeningPort { get; protected set; }
        public string BroadcastRange { get; protected set; }
        public ServerType Type { get; protected set; }
        public IMessageQueue<OutgoingMessage> InternalOutgoingMessageQueue { get; protected set; }
        public INetworkAdapter NetworkAdapter { get; protected set; }
        public IHiveNode<ServerInfo> HiveNode { get; protected set; }

        public ServerNetworkManager(ServerConfig config)
            : base(config.AppId, config.Serializer)
        {
            NetworkAdapter = ObjectFactory.CreateINetworkAdapterInstance(AppId);
            NetworkAdapter.AddServerInterface(ObjectFactory.CreateIServerNetworkInterfaceInstance(AppId, config.ListeningPort, this));
            InternalOutgoingMessageQueue = ObjectFactory.CreateIMessageQueueInstance<OutgoingMessage>();
            IsRunning = false;
            ServerId = config.ServerId;
            ListeningPort = config.ListeningPort;
            BroadcastRange = config.BroadcastRange;
            Type = config.ServerType;
        }

        //-- Protected functionality

        protected override void LoadMessageHandlers()
        {
            MessageHandlers.Add(new ReceiveServerReferenceHandler(this, ServerMessageType.ReceiveServerReference));
            MessageHandlers.Add(new ServerReferenceRequestHandler(this, ServerMessageType.ReceiveServerReferenceRequest));
        }

        protected virtual void CreateHiveNode(ServerInfo serverInfo)
        {
            HiveNode = ObjectFactory.CreateIHiveNodeInstance(NetworkAdapter, Serializer, serverInfo, ListeningPort);
        }

        protected virtual void SendLoop()
        {
            while (IsRunning)
            {
                OnSendMessage();
                Thread.Sleep(1);
            }
        }

        protected virtual void OnSendMessage()
        {
            OutgoingMessage com = (OutgoingMessage)InternalOutgoingMessageQueue.Read();

            if (com != null)
                NetworkAdapter.SendMessageThroughServer(ListeningPort, com);
        }

        protected virtual void OnReceiveMessage(IncomingMessage incomingMsg)
        {
            foreach (ServerMessageHandler handler in MessageHandlers)
                handler.Run(incomingMsg);

            if (incomingMsg.WasMessageHandled == false)
                throw new InvalidOperationException("Message was not handled: " + ServerMessageHandler.ReadMessageType(incomingMsg));
        }

        protected virtual void OnHandleServerDisconnection(IPEndPoint serverEndPoint)
        {
            HiveNode.HandleDisconnection(serverEndPoint);
        }

        protected virtual void OnHandleServerConnection(IPEndPoint serverEndPoint)
        {
            HiveNode.HandleConnection(serverEndPoint);
        }

        //-- Public functionality

        public override void Start()
        {       
            NetworkAdapter.Start();
            IsRunning = true;
            HiveNode.SendDiscoveryBeacons(BroadcastRange);

            ThreadStart ts2 = new ThreadStart(SendLoop);
            SendThread = new Thread(ts2);
            SendThread.Name = AppId + " Send Loop Thread";
            SendThread.Start();
        }

        public override void Shutdown()
        {
            NetworkAdapter.Shutdown();
            IsRunning = false;       
        }

        public virtual List<IPEndPoint> ResolveServers(List<string> serverIds)
        {
            List<IPEndPoint> ips = new List<IPEndPoint>();

            foreach (string id in serverIds)
                ips.Add(ResolveServer(id));

            return ips;
        }

        public virtual IPEndPoint ResolveServer(string serverId)
        {
            IPEndPoint ip = HiveNode.FindBy(serverId);

            return ip;
        }

        public virtual void Disconnected(IPEndPoint endpoint, int fromListenPort)
        {
            if (fromListenPort == ListeningPort)
                OnHandleServerDisconnection(endpoint);
        }

        public virtual void Connected(IPEndPoint endpoint, int fromListenPort)
        {
            if (fromListenPort == ListeningPort)
                OnHandleServerConnection(endpoint);
        }

        public virtual void MessageReceived(IncomingMessage msg, int fromListenPort)
        {
            if (fromListenPort == ListeningPort)
                OnReceiveMessage(msg);
        }

        public virtual void DiscoveryRequestReceived(System.Net.IPEndPoint endPoint, int onPort)
        {
            if (onPort == ListeningPort)
                HiveNode.HandleIncomingDiscoveryRequest(endPoint, onPort);
        }
    }
}
