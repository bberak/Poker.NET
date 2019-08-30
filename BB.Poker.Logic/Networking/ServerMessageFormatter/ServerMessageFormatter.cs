using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Lidgren.Network;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class ServerMessageFormatter : MessageFormatter
    {
        public static OutgoingMessage CreateOutgoingMessage(int opcode, byte[] data, List<IPEndPoint> recipients)
        {
            OutgoingMessage com = new OutgoingMessage();
            com.OperationCode = opcode;
            com.Data = data;
            com.Recipients = recipients;

            return com;
        }

        public static OutgoingMessage CreateOutgoingMessage(int opcode, byte[] data, List<IPEndPoint> recipients, NetOutgoingMessage packet)
        {
            OutgoingMessage com = CreateOutgoingMessage(opcode, data, recipients);
            com.EncodeTo(packet);
            return com;
        }

        public static UnconnectedOutgoingMessage CreateUnconnectedOutgoingMessage(int opcode, byte[] data, List<IPEndPoint> recipients)
        {
            UnconnectedOutgoingMessage outMessage = new UnconnectedOutgoingMessage();
            outMessage.OperationCode = opcode;
            outMessage.Data = data;
            outMessage.Recipients = recipients;

            return outMessage;
        }

        public static UnconnectedOutgoingMessage CreateUnconnectedOutgoingMessage(int opcode, byte[] data, List<IPEndPoint> recipients, NetOutgoingMessage packet)
        {
            UnconnectedOutgoingMessage outMessage = CreateUnconnectedOutgoingMessage(opcode, data, recipients);
            outMessage.EncodeTo(packet);
            return outMessage;
        }
    }
}
