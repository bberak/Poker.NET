using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BB.Poker.Common
{
    public interface IIncomingMessage<TPacketType>
    {
        IPEndPoint Sender { get;}
        TPacketType IncomingPacket { get; }
        bool HasBeenDecoded { get; }
        bool WasMessageHandled { get; }

        int OperationCode { get; }
        int DataSize { get; }
        int SequenceChannel { get; }
        byte[] Data { get; }
        void DecodeFrom(TPacketType packet);
    }
}
