using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;

namespace BB.Poker.Common
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public IncomingMessage IncomingMessage { get; protected set; }

        public bool WasMessageHandled
        {
            get { return IncomingMessage.WasMessageHandled; }
            set { IncomingMessage.WasMessageHandled = value; }
        }

        public MessageReceivedEventArgs(IncomingMessage message)
        {
            IncomingMessage = message;
        }
    }

    public class MessageReceivedEventArgs<T, U> : MessageReceivedEventArgs
    {
        public T OperationCode { get; protected set; }

        public U DataObject { get; protected set; }

        public MessageReceivedEventArgs(IncomingMessage message, ISerialize serializer)
            :base(message)
        {
            IncomingMessage = message;

            OperationCode = BaseMessageHandler<T>.ReadMessageType(message);

            DataObject = serializer.GetObject<U>(message.Data);
        }
    }

    public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);

    public delegate void MessageReceivedEventHandler<T, U>(object sender, MessageReceivedEventArgs<T, U> e);
}
