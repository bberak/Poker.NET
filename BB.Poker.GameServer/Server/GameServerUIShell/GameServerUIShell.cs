using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BB.Poker.GameServer.Properties;

namespace BB.Poker.GameServer
{
    public partial class GameServerUIShell : BB.Poker.Logic.ServerUIShell
    {
        public GameServer GameServer { get; protected set; }

        public GameServerUIShell()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            WriteLine("Game Server is starting...");
            WriteLine();

            GameServer = new GameServer(
                Settings.Default.AppId, 
                Settings.Default.ListeningPort, 
                Settings.Default.BroadcastRange, 
                Settings.Default.ServerId,
                Settings.Default.ServerType);

            GameServer.Start();
        }

        protected override void OnExit()
        {
            GameServer.Shutdown();
        }
    }
}
