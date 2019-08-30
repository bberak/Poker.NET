using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BB.Poker.GatewayServer.Properties;

namespace BB.Poker.GatewayServer
{
    public partial class GatewayServerUIShell : BB.Poker.Logic.ServerUIShell
    {
        public GatewayServer GatewayServer { get; protected set; }
        public GatewayServerUIShell()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            WriteLine("Gateway Server is starting...");
            WriteLine();

            GatewayServer = new GatewayServer(
                Settings.Default.AppId,
                Settings.Default.ClientListeningPort,
                Settings.Default.BroadcastRange,
                Settings.Default.ListeningPort,
                Settings.Default.ServerId,
                Settings.Default.ServerType);

            GatewayServer.Start();
        }

        protected override void OnExit()
        {
            GatewayServer.Shutdown();
        }
    }
}
