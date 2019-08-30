using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BB.Poker.Common
{
    public interface IConnection<T>
    {
        IPEndPoint RemoteEndPoint { get; }
        long UniqueIdentifier { get; }
        T GenericConnection { get; }
    }
}
