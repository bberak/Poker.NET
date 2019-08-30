using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;

namespace BB.Poker.Common
{
    public class GameMessageReceivedEventArgs<T> : MessageReceivedEventArgs<GameMessageType, T>
    {
        public GameMessageReceivedEventArgs(IncomingMessage message, ISerialize serializer)
            :base(message, serializer)
        {
        }
    }

    public delegate void GameMessageReceivedEventHandler<T>(object sender, GameMessageReceivedEventArgs<T> e);
}
