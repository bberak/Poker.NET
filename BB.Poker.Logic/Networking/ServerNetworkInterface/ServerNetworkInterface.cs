using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Lidgren.Network;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class ServerNetworkInterface : IServerNetworkInterface
    {
        private Thread externalReceiveThread;
        private NetServer lidgrenServer;

        private IServerNetworkManager Manager;

        public bool IsRunning { get; protected set; }
        public string AppId { get; protected set; }
        public int Port { get; protected set; }
        public IPAddress Address
        {
            get
            {
                if (IsRunning)
                    return lidgrenServer.Configuration.LocalAddress;
                else
                    throw new InvalidOperationException("You must start this network interface before obtaining it's local address");
            }
        }

        public ServerNetworkInterface(string appId, 
            int port,
            IServerNetworkManager manager) 
        {
            Manager = manager;
            AppId = appId;
            Port = port;
            NetPeerConfiguration config = new NetPeerConfiguration(appId);
            config.Port = port;
            config.EnableMessageType(NetIncomingMessageType.DiscoveryRequest);
            config.EnableMessageType(NetIncomingMessageType.DiscoveryResponse);
            config.EnableMessageType(NetIncomingMessageType.UnconnectedData);

            lidgrenServer = new NetServer(config);
        }

        public void Start()
        {
            lidgrenServer.Start();
            IsRunning = true;
            ThreadStart ts = new ThreadStart(receiveLoop);
            externalReceiveThread = new Thread(ts);
            externalReceiveThread.Name = lidgrenServer.Configuration.AppIdentifier + " External Receive Loop Thread";
            externalReceiveThread.Start();
        }

        public void Shutdown()
        {
            lidgrenServer.Shutdown(lidgrenServer.Configuration.AppIdentifier + " is shutting down. Bye!");

            IsRunning = false;
        }

        private void receiveLoop()
        {
            while (IsRunning)
            {
                NetIncomingMessage msg = lidgrenServer.ReadMessage();
                if (msg != null)
                {
                    switch (msg.MessageType)
                    {
                        case NetIncomingMessageType.DiscoveryRequest:     
                            if (NetworkUtility.IsLocalIpAddress(msg.SenderEndpoint.Address.ToString()))
                            {
                                //-- Is it from this app? Send DiscoveryRequest only if its from a different app.
                                if (msg.SenderEndpoint.Port != Port)
                                {
                                    Manager.DiscoveryRequestReceived(msg.SenderEndpoint, Port);
                                }
                            }
                            else
                            {
                                //-- It's from another machine.
                                Manager.DiscoveryRequestReceived(msg.SenderEndpoint, Port);
                            }
                            break;                            

                        case NetIncomingMessageType.VerboseDebugMessage:
                        case NetIncomingMessageType.DebugMessage:
                        case NetIncomingMessageType.ErrorMessage:
                        case NetIncomingMessageType.WarningMessage:
                            ServerUIShell.WriteLine("-Lidgren.Network Message: " + msg.ReadString());
                            break;
 
                        case NetIncomingMessageType.UnconnectedData:
                        case NetIncomingMessageType.Data:
                            IncomingMessage im = new IncomingMessage();
                            im.DecodeFrom(msg);
                            Manager.MessageReceived(im, Port);
                            OnMessageReceived(new MessageReceivedEventArgs(im));
                            break;

                        case NetIncomingMessageType.StatusChanged:
                            NetConnectionStatus status = (NetConnectionStatus)msg.ReadByte();
                            if (status == NetConnectionStatus.Disconnected)
                                Manager.Disconnected(msg.SenderEndpoint, Port);
                            else if (status == NetConnectionStatus.Connected)
                                Manager.Connected(msg.SenderEndpoint, Port);
                            break;

                        default:
                            throw new InvalidOperationException("An unhandled MessageType was received.");
                    }    
                    lidgrenServer.Recycle(msg);
                }
                Thread.Sleep(1);
            }
        }

        public void SendMessage(OutgoingMessage om)
        {
            if (!om.HasBeenEncoded)
                om.EncodeTo(lidgrenServer.CreateMessage());

            List<NetConnection> recipients = Resolve(om.Recipients);

            if (recipients.Count > 0)
            {
                lidgrenServer.SendMessage(om.OutgoingPacket,
                    recipients,
                    om.DeliveryMethod, 
                    om.SequenceChannel);
            }
        }

        public void SendUnconnectedMessage(UnconnectedOutgoingMessage outMessage)
        {
            if (!outMessage.HasBeenEncoded)
                outMessage.EncodeTo(lidgrenServer.CreateMessage());

            lidgrenServer.SendUnconnectedMessage(outMessage.OutgoingPacket,
                outMessage.Recipients);
        }

        public void SendDiscoveryRequest(int port)
        {
            lidgrenServer.DiscoverLocalPeers(port);
        }

        public void Disconnect(IPEndPoint remoteEndPoint, string byeMessage)
        {
            //-- Only disconnect if a current connection already exists
            NetConnection conn = lidgrenServer.GetConnection(remoteEndPoint);

            if (conn != null)
                conn.Disconnect(byeMessage);
        }

        public void Connect(IPEndPoint remoteEndPoint)
        {
            //-- Only connect if a current connection does not already exist
            NetConnection conn = lidgrenServer.GetConnection(remoteEndPoint);

            if (conn == null)
                lidgrenServer.Connect(remoteEndPoint);
        }

        protected List<NetConnection> Resolve(List<IPEndPoint> endpoints)
        {
            List<NetConnection> connections = new List<NetConnection>();

            foreach (IPEndPoint ip in endpoints)
            {
                if (ip != null)
                {
                    NetConnection conn = lidgrenServer.GetConnection(ip);
                    if (conn != null)
                        connections.Add(conn);
                }
            }

            return connections;
        }

        public bool IsConnectedTo(System.Net.IPEndPoint remoteEndpoint)
        {
            NetConnection nc = lidgrenServer.GetConnection(remoteEndpoint);

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
