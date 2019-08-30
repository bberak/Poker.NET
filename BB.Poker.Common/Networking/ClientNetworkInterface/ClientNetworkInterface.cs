using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Lidgren.Network;

namespace BB.Poker.Common
{
    public class ClientNetworkInterface : IClientNetworkInterface
    {
        private Thread receiveThread;
        private NetClient lidgrenClient;
        private IClientNetworkManager Manager;

        public bool IsConnected { get; protected set; }
        public bool IsRunning { get; protected set; }
        public string AppId { get; protected set; }
        public int ContactPort { get; protected set; }
        public string Host { get; protected set; }

        public ClientNetworkInterface(string appIdentifier, 
            string host, 
            int port,
            IClientNetworkManager manager)
        {
            NetPeerConfiguration config = new NetPeerConfiguration(appIdentifier);
            config.EnableMessageType(NetIncomingMessageType.DiscoveryRequest);
            config.EnableMessageType(NetIncomingMessageType.DiscoveryResponse);

            lidgrenClient = new NetClient(config);
            Host = host;
            ContactPort = port;
            AppId = appIdentifier;
            Manager = manager;
        }

        public void Start()
        {
            Action workItem = new Action(connect);
            ThreadPool.QueueUserWorkItem(ignored => workItem());
        }

        private void connect()
        {
            lidgrenClient.Start();
            lidgrenClient.Connect(Host, ContactPort);
            IsRunning = true;
            IsConnected = false;

            ThreadStart ts = new ThreadStart(receiveLoop);
            receiveThread = new Thread(ts);
            receiveThread.Name = lidgrenClient.Configuration.AppIdentifier + " External Receive Loop Thread";
            receiveThread.IsBackground = true;
            receiveThread.Priority = ThreadPriority.Normal;
            receiveThread.Start();

            int seconds = 0;
            while (IsConnected == false)
            {
                Thread.Sleep(1000);
                seconds++;

                if (seconds > 30)
                    break; 
            }

            if (IsConnected)
                Manager.Connected();
            else
            {
                Shutdown();
                Manager.FailedToConnect(new Exception("Failed to connect in time. Bye!"));
            }
        }

        private void receiveLoop()
        {
            while (IsRunning)
            {
                NetIncomingMessage msg = lidgrenClient.ReadMessage();
                if (msg != null)
                {
                    switch (msg.MessageType)
                    {
                        case NetIncomingMessageType.VerboseDebugMessage:
                        case NetIncomingMessageType.DebugMessage:
                        case NetIncomingMessageType.ErrorMessage:
                        case NetIncomingMessageType.WarningMessage:
                            Console.WriteLine(msg.ReadString());
                            break;

                        case NetIncomingMessageType.Data:
                            IncomingMessage im = new IncomingMessage();
                            im.DecodeFrom(msg);
                            Manager.MessageReceived(im, ContactPort);
                            OnMessageReceived(new MessageReceivedEventArgs(im));
                            break;

                        case NetIncomingMessageType.StatusChanged:
                            NetConnectionStatus status = (NetConnectionStatus)msg.ReadByte();
                            string reason = msg.ReadString();
                            Console.WriteLine(msg.SenderConnection + " status: " + status + " (" + reason + ")");
                            
                            if (status == NetConnectionStatus.Disconnected && IsConnected)
                            {
                                Manager.Disconnected(msg.SenderEndpoint);
                                IsConnected = false;
                            }
                            else if (status == NetConnectionStatus.Connected)
                                IsConnected = true;
                            break;

                        default:
                            throw new InvalidOperationException("An unhandled MessageType was received.");
                    }
                    lidgrenClient.Recycle(msg);
                }
                Thread.Sleep(1);
            }
        }


        public void Shutdown()
        {
            lidgrenClient.Shutdown(AppId + " Client is shutting down. Bye!");
            IsRunning = false;
            IsConnected = false;
        }

        public void SendMessage(OutgoingMessage message)
        {
            if (!message.HasBeenEncoded)
                message.EncodeTo(lidgrenClient.CreateMessage());

            lidgrenClient.SendMessage(message.OutgoingPacket, NetDeliveryMethod.ReliableOrdered);
        }

        public bool IsConnectedTo(System.Net.IPEndPoint remoteEndpoint)
        {
            NetConnection nc = lidgrenClient.GetConnection(remoteEndpoint);

            if (nc == null)
                return false;
            else
                return true;
        }


        protected void OnMessageReceived(MessageReceivedEventArgs e)
        {
            if (MessageReceived != null)
            {
                MessageReceived.BeginInvoke(this, e, null, null);
            }
        }

        public event MessageReceivedEventHandler MessageReceived;
    }
}
