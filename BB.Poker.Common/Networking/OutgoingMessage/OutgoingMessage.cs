using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Lidgren.Network;

namespace BB.Poker.Common
{
    public class OutgoingMessage : UnconnectedOutgoingMessage
    {
        public OutgoingMessage() : base()
        {
            DeliveryMethod = DEFAULT_DELIVERY_METHOD;
            SequenceChannel = DEFAULT_SEQUENCE_CHANNEL;
        }

        public int SequenceChannel { get; set; }

        public NetDeliveryMethod DeliveryMethod { get; set; }
    }
}
