using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Lidgren.Network;

namespace BB.Poker.Common
{
    public class UnconnectedOutgoingMessage : IOutgoingMessage<NetOutgoingMessage, IPEndPoint>
    {
        public const int OPCODE_BITS = 8;
        public const int DATASIZE_BITS = 16;
        public const int DEFAULT_SEQUENCE_CHANNEL = 0;
        public const NetDeliveryMethod DEFAULT_DELIVERY_METHOD = NetDeliveryMethod.ReliableOrdered;

        public UnconnectedOutgoingMessage()
        {
            Recipients = new List<IPEndPoint>();
            data = new byte[0];
        }

        public List<IPEndPoint> Recipients { get; set; }

        public NetOutgoingMessage OutgoingPacket { get; protected set; }

        public bool HasBeenEncoded { get; protected set; }

        private int operationCode;
        public int OperationCode
        {
            get { return operationCode; }

            set { if (!HasBeenEncoded) operationCode = value; else throw new InvalidOperationException("Properties cannot be updated once the message has been encoded."); }
        }

        private int dataSize;
        public int DataSize
        {
            get { return dataSize; }
        }

        byte[] data;
        public byte[] Data
        {
            get { return data; }

            set
            {
                if (!HasBeenEncoded)
                {
                    data = value;
                    dataSize = data.Length;
                }
                else
                    throw new InvalidOperationException("Properties cannot be updated once the message has been encoded.");
            }
        }

        public virtual void EncodeTo(NetOutgoingMessage packet)
        {
            if (!HasBeenEncoded)
            {
                OutgoingPacket = packet;

                if (OutgoingPacket == null)
                    throw new InvalidOperationException("The underlying packet cannot be null.");

                OutgoingPacket.Write(OperationCode, OPCODE_BITS);
                OutgoingPacket.Write(DataSize, DATASIZE_BITS);
                OutgoingPacket.Write(Data);
                HasBeenEncoded = true;
            }
            else
                throw new InvalidOperationException("This message has already been encoded to a packet and cannot be encoded again.");
        }
    }
}
