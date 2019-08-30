using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public abstract class MessageHandlerComponent<T>
    {
        protected List<IMessageHandler<T>> MessageHandlers;

        public MessageHandlerComponent()
        {
            MessageHandlers = new List<IMessageHandler<T>>();

            LoadMessageHandlers();
        }

        protected abstract void LoadMessageHandlers();
    }
}
