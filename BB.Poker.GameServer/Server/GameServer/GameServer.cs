using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GameServer
{
    public class GameServer
    {
        private GameTableCollection m_gtcTables;

        private ServerNetworkManager m_nmNetworkManager;

        private Thread PlayerBridgeLoopThread;

        public GameTableCollection Tables { get { return m_gtcTables; } }

        public string ServerId { get; protected set; }

        public GameServer(string appId, int listeningPort, string broadcastRange, string serverId, ServerType type)
        {
            ServerId = serverId;

            m_gtcTables = new GameTableCollection();
            Random rng = new Random((int)DateTime.Now.Ticks + DateTime.Now.Month + DateTime.Now.Day);

            for (int i = 0; i < 50; i++)
            {
                int smallBlind = rng.Next(10, 500);
                m_gtcTables.Add(ObjectFactory.CreateIGameTableTableInstance(smallBlind, smallBlind * 2, 9, Guid.NewGuid().ToString(), "Texas Holdem Table " + i, ServerId));
            }

            GameServerConfig config = new GameServerConfig();
            config.AppId = appId;
            config.BroadcastRange = broadcastRange;
            config.ListeningPort = listeningPort;
            config.Serializer = ObjectFactory.CreateISerializeInstance();
            config.ServerId = serverId;
            config.ServerType = type;
            config.Tables = m_gtcTables;

            m_nmNetworkManager = new GameNetworkManager2(config);

        }

        public void Start()
        {
            m_nmNetworkManager.Start();

            foreach (IGameTable gt in m_gtcTables)
                gt.OpenTable();

            ThreadStart ts = new ThreadStart(ReadPlayerBridgeQueues);
            PlayerBridgeLoopThread = new Thread(ts);
            PlayerBridgeLoopThread.Name = ServerId + ": NetworkPlayerBridge Read Incoming Queue Thread";
            PlayerBridgeLoopThread.Start();
        }

        private void ReadPlayerBridgeQueues()
        {
            while (m_nmNetworkManager.IsRunning)
            {
                foreach (IGameTable gt in m_gtcTables)
                    gt.PlayerPortal.ReadIncomingQueue();
            }
        }

        public void Shutdown()
        {
            foreach (IGameTable gt in m_gtcTables)
                gt.CloseTable();

            m_nmNetworkManager.Shutdown();
        }
    }
}
