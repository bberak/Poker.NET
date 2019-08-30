using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public abstract class GameClientMessageHandler<T> : BaseMessageHandler<GameMessageType> where T : GameClientModule
    {
        public T Module { get; protected set; }

        public GameClientMessageHandler(T module, GameMessageType target)
            : base(target)
        {
            Module = module;
        }
    }
}
