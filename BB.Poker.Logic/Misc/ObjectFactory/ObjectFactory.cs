using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;
using BB.Poker.Logic.Hive;

namespace BB.Poker.Logic
{
    public sealed class ObjectFactory
    {
        private static readonly ObjectFactory instance = new ObjectFactory();

        //-- Explicit static constructor to tell C# compiler
        //-- not to mark type as beforefieldinit.
        static ObjectFactory()
        {
        }

        private ObjectFactory()
        {
        }

        public static IShuffle CreateIShuffleInstance()
        {
            IShuffle shuffler = new StandardShuffler();
            return shuffler;
        }

        public static DeckFactory CreateDeckFactoryInstance()
        {
            DeckFactory df = new DeckFactory(CreateIShuffleInstance());
            return df;
        }

        public static IPlayerPortal CreateIPlayerPortalInstance()
        {
            IPlayerPortal portal = new NetworkPlayerPortal(CreateIMessageQueueInstance<IncomingGameMessageQueueItem>(),
                CreateIMessageQueueInstance<OutgoingGameMessageQueueItem>(),
                CreateISerializeInstance());

            return portal;
        }

        public static IGameTable CreateIGameTableTableInstance(double smallBlind, double bigBlind, int maxPlayers, string tableId, string description, string serverId)
        {
            IGameTable table = new TexasHoldemTable(smallBlind, bigBlind, maxPlayers, tableId, description, serverId);

            return table;
        }

        public static IHiveNode<ServerInfo> CreateIHiveNodeInstance(INetworkAdapter adapter, ISerialize serializer, ServerInfo myInfo, int listeningPort)
        {
            IHiveNode<ServerInfo> hn = new HiveNode(adapter, serializer, myInfo, listeningPort);
            return hn;
        }

        public static IMessageQueue<T> CreateIMessageQueueInstance<T>()
        {
            IMessageQueue<T> mq = new MessageQueue<T>();
            return mq;
        }

        public static INetworkAdapter CreateINetworkAdapterInstance(string appId)
        {
            INetworkAdapter na = new NetworkAdapter(appId);
            return na;
        }

        public static IServerNetworkInterface CreateIServerNetworkInterfaceInstance(string appId, int listeningPort, IServerNetworkManager manager)
        {
            IServerNetworkInterface ni = new ServerNetworkInterface(appId, listeningPort, manager);
            return ni;
        }

        public static ISerialize CreateISerializeInstance()
        {
            ISerialize js = new JsonSerializer();
            return js;
        }

        public static ObjectFactory Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
