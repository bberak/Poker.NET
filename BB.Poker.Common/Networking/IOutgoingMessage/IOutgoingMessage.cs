using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BB.Poker.Common
{
    public interface IOutgoingMessage<TPacketType, URecipientType>
    {
        List<URecipientType> Recipients { get; set; }
        TPacketType OutgoingPacket { get;  }
        bool HasBeenEncoded { get;  }
        int DataSize { get; }
        int OperationCode { get; set; }
        byte[] Data { get; set; }
        void EncodeTo(TPacketType packet);
    }
}
