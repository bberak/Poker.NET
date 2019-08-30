using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public abstract partial class GameClientModule : BaseModule
    {
        public new GameClientModuleHost Host { get; protected set; }

        public GameClientModule(GameClientModuleHost host, string name)
            : base(host, name)
        {
            Host = host;
        }

        protected abstract void LoadControls();

        protected override void LoadMessageHandlers()
        {
            LoadControls();
        }
    }
}
