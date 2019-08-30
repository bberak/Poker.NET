using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public abstract class BaseMultiMessageHandler<T> : IMessageHandler<T>
    {
        public T[] Targets { get; protected set; }

        public BaseMultiMessageHandler(params T[] targets)
        {
            Targets = targets;
        }

        public virtual bool CanHandleMessage(T target)
        {
            for (int i = 0; i < Targets.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(Targets[i], target))
                    return true;
            }

            return false;
        }

        public virtual void Run(IncomingMessage message)
        {
            if (!CanHandleMessage(BaseMessageHandler<T>.ReadMessageType(message)))
                return;

            OnRun(message);
        }

        protected abstract void OnRun(IncomingMessage message);
    }
}
