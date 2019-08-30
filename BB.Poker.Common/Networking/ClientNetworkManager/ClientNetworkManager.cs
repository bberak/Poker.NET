using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public abstract class ClientNetworkManager : BaseNetworkManager<GameMessageType>, IClientNetworkManager
    {
        protected IClientNetworkInterface NetworkInterface;

        public ClientNetworkManager(string appId, string host, int port) 
            : base(appId, new JsonSerializer())
        {
            NetworkInterface = new ClientNetworkInterface(appId, host, port, this);
        }

        public override void Start()
        {
            NetworkInterface.Start();
            IsRunning = true;
        }

        public override void Shutdown()
        {
            NetworkInterface.Shutdown();
            IsRunning = false;
        }

        public void SendMessage(OutgoingMessage message)
        {
            NetworkInterface.SendMessage(message);
        }

        public abstract void Disconnected(System.Net.IPEndPoint fromEndPoint);

        public abstract void MessageReceived(IncomingMessage msg, int fromConnectToPort);

        public abstract void FailedToConnect(Exception ex);

        public abstract void Connected();
    }
}
