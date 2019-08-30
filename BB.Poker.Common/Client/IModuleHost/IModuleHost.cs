using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BB.Poker.Common
{
    public interface IModuleHost
    {
        ISerialize Serializer { get; }

        Client Client { get; }

        Account UserAccount { get; }

        Logger Log { get; }

        void Connect();

        void Exit();

        void SendMessage(OutgoingMessage message);

        void SendMessage(GameMessageType opcode, object dataObject);

        event EventHandler ClientConnected;

        event EventHandler ClientDisconnected;

        event EventHandler ClientFailedToConnect;

        event EventHandler<MessageReceivedEventArgs> ClientReceivedMessage;
    }
}
