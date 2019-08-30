using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BB.Poker.GameServer.Properties;

namespace BB.Poker.GameServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(737);
            Application.Run(new GameServerUIShell());
            return;
        }
    }
}
