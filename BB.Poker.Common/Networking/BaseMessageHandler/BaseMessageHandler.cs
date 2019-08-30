using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public abstract class BaseMessageHandler<T> : IMessageHandler<T>
    {
        public T Target { get; protected set; }

        public BaseMessageHandler(T target)
        {
            Target = target;
        }

        public virtual bool CanHandleMessage(T target)
        {
            if (EqualityComparer<T>.Default.Equals(Target, target))
                return true;

            return false;
        }

        public virtual void Run(IncomingMessage message)
        {
            if (!CanHandleMessage(ReadMessageType(message)))
                return;

            OnRun(message);
        }

        protected abstract void OnRun(IncomingMessage message);

        public static T ReadMessageType(IncomingMessage message)
        {
            return (T)Enum.ToObject(typeof(T), message.OperationCode);
        }
    }
}
