using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public interface IMessageHandler<T>
    {
        bool CanHandleMessage(T target);

        void Run(IncomingMessage message);
    }
}
