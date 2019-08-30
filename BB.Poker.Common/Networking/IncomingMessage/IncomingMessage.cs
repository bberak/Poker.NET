using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Lidgren.Network;

namespace BB.Poker.Common
{
    public class IncomingMessage : IIncomingMessage<NetIncomingMessage>
    {
        public const int OPCODE_BITS = OutgoingMessage.OPCODE_BITS;
        public const int DATASIZE_BITS = OutgoingMessage.DATASIZE_BITS;

        #region IIncomingMessage<NetIncomingMessage> Members

        public IPEndPoint Sender
        {
            get;
            protected set;
        }

        public NetIncomingMessage IncomingPacket
        {
            get;
            protected set;
        }

        public bool HasBeenDecoded
        {
            get;
            protected set;
        }

        private bool wasMessageHandled;
        public bool WasMessageHandled 
        { 
            get { return wasMessageHandled; } 
            set { if (value) wasMessageHandled = value; } 
        }

        public int OperationCode
        {
            get;
            protected set;
        }

        public int DataSize
        {
            get;
            protected set;
        }

        public int SequenceChannel
        {
            get;
            protected set;
        }

        public byte[] Data
        {
            get;
            protected set;
        }

        public void DecodeFrom(NetIncomingMessage packet)
        {
            if (HasBeenDecoded == false)
            {
                IncomingPacket = packet;

                if (IncomingPacket == null)
                    throw new InvalidOperationException("The underlying message must be set before decoding can begin.");

                OperationCode = IncomingPacket.ReadInt32(OPCODE_BITS);
                DataSize = IncomingPacket.ReadInt32(DATASIZE_BITS);
                Data = IncomingPacket.ReadBytes(DataSize);
                Sender = packet.SenderEndpoint;
                SequenceChannel = packet.SequenceChannel;
                HasBeenDecoded = true;            
            }
        }

        #endregion
    }
}
