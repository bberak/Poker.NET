using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Lidgren.Network;

namespace BB.Poker.Common
{
    public class MessageFormatter
    {
        public static OutgoingMessage CreateOutgoingMessage(int opcode, byte[] data)
        {
            OutgoingMessage com = new OutgoingMessage();
            com.OperationCode = opcode;
            com.Data = data;
            com.Recipients = null;

            return com;
        }

        public static OutgoingMessage CreateOutgoingMessage(int opcode, byte[] data, NetOutgoingMessage packet)
        {
            OutgoingMessage com = CreateOutgoingMessage(opcode, data); 
            com.EncodeTo(packet);

            return com;
        }
    }
}
