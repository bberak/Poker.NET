using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BB.Poker.Common;
using BB.Poker.Logic;
using Lidgren.Network;

namespace BB.Poker.GameServer
{
    /// <summary>
    /// These tests are no longer valid. I will need to add more tests once a clear roadmap for
    /// future development is adopted.
    /// </summary>
    [TestClass]
    [Obsolete]
    public class GameServerTest
    {
        public const int TEST_CLIENT_PORT = 15243;
        public const string TEST_SERVER_ID = "C61BCE7B-C9D4-4cd2-868D-CBBDE900E1B2";
        public const string TEST_APP_ID = "Poker Reloaded Test";
        public const string TEST_TABLE_ID = "1";
        public const string TEST_BROADCAST_RANGE = "58464-58484";

        private GameServer _gs;
        private NetClient _clientOne;
        private NetClient _clientTwo;
        private ThreadController _threader;
        private ISerialize _serializer;
        private readonly string testServerHost;

        public GameServerTest()
        {
            _threader = new ThreadController(false);
            _serializer = new JsonSerializer();
            testServerHost = getLocalIPAddress().ToString();

            //-- Create and start the server
            _gs = new GameServer(TEST_APP_ID, TEST_CLIENT_PORT, TEST_BROADCAST_RANGE, TEST_SERVER_ID, ServerType.GameServer);
            _gs.Start();

            //-- Create the clients
            NetPeerConfiguration config = new NetPeerConfiguration(TEST_APP_ID);
            _clientOne = new NetClient(config);
            _clientTwo = new NetClient(config);
        }

        private IPAddress getLocalIPAddress()
        {
            IPAddress ipV4Address = null;
            string hostName = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);
            if (addresses != null && addresses.Length > 0)
            {
                foreach (IPAddress ip in addresses)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipV4Address = ip;
                        break;
                    }
                }
            }

            return ipV4Address;
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_ConnectTwoPlayers_GameStarts()
        {
            //-- Connect the clients to the server
            //connectClients();

            ////-- Create the join table request
            //JoinTableRequest jtr = new JoinTableRequest();
            //jtr.PlayerName = "Client One";
            //jtr.Position = 1;
            //jtr.Chips = 3000;
            //jtr.TableId = TEST_TABLE_ID;
            //SendMessage(Guid.NewGuid().ToString("N"), (uint)GameMessageType.RequestJoinTable, jtr, _clientOne);
            //_threader.WaitHereFor(1000);
            
            //jtr.PlayerName = "Client Two";
            //jtr.Position = 2;
            //SendMessage(Guid.NewGuid().ToString("N"), (uint)GameMessageType.RequestJoinTable, jtr, _clientTwo);
            //_threader.WaitHereFor(1000);

            //_threader.WaitHereFor(1000);
            //GameTable gt = _gs.Tables[TEST_TABLE_ID];

            //Assert.IsNotNull(gt);
            //Assert.AreEqual<int>(2, gt.Players.Count);
            //Assert.IsTrue(gt.State == TableState.OpeningBets);

            ////-- Below is a semi-decent way of simulating synchronization errors.
            ////-- When the first client shuts down, the table begins to evaluate the player
            ////-- hands. As the table is enumerating through the player collection (which now only
            ////-- contains client two) the second player is removed from the list which causes a sync error.
            ////-- Note that this only occurs on some occasions. I'll need to add some better thread-safety
            ////-- to the game table soon!
            //_clientOne.Shutdown("Bye from GamerServer_ConnectTwoPlayers_GameStarts()");
            //_clientTwo.Shutdown("Bye from GamerServer_ConnectTwoPlayers_GameStarts()");
        }

        private void connectClients()
        {
            _clientOne.Start();
            _clientOne.Connect(testServerHost, TEST_CLIENT_PORT);

            _clientTwo.Start();
            _clientTwo.Connect(testServerHost, TEST_CLIENT_PORT);

            _threader.WaitHereFor(5000);
        }

        public void SendMessage(string messageid, uint opcode, object dataObject, NetClient netClient)
        {
            //OutgoingMessage outMsg = MessageFormatter.CreateOutgoingMessageFrom(netClient.CreateMessage(),
            //    messageid,
            //    opcode,
            //    _serializer.GetBytes(dataObject));
            //outMsg.Encode();

            //netClient.SendMessage(outMsg.GetUnderlyingMedium(), NetDeliveryMethod.ReliableOrdered);
        }
    }
}
