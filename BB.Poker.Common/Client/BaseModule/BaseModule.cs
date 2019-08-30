using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Common.WinForms;

namespace BB.Poker.Common
{
    public abstract class BaseModule : MessageHandlerComponent<GameMessageType>, IModule<BaseModuleHost>
    {
        public BaseModuleHost Host { get; protected set; }

        public string Name { get; protected set; }

        public bool HasFocus { get; protected set; }

        public BaseModule(BaseModuleHost host, string name)
        {
            Name = name;
            Host = host;

            Host.ClientConnected += (object sender, EventArgs e) => { OnClientConnected(e); };
            Host.ClientDisconnected += (object sender, EventArgs e) => { OnClientDisconnected(e); };
            Host.ClientFailedToConnect += (object sender, EventArgs e) => { OnClientFailedToConnect(e); };
            Host.ClientReceivedMessage += (object sender, MessageReceivedEventArgs e) => { OnClientReceivedMessage(e); };      
        }

        public virtual void Focus(Control target)
        {
            HasFocus = true;
        }

        public virtual void LostFocus()
        {
            HasFocus = false;
        }

        protected virtual void OnClientConnected(EventArgs e)
        {
        }

        protected virtual void OnClientDisconnected(EventArgs e)
        {
        }

        protected virtual void OnClientFailedToConnect(EventArgs e)
        {
        }

        protected virtual void OnClientReceivedMessage(MessageReceivedEventArgs e)
        {
            foreach (IMessageHandler<GameMessageType> handler in MessageHandlers)
                handler.Run(e.IncomingMessage);
        }

        protected virtual void OnModuleTaskCompleted(EventArgs e)
        {
            ModuleTaskCompleted.Fire(this, e);
        }

        public event EventHandler ModuleTaskCompleted;
    }
}
