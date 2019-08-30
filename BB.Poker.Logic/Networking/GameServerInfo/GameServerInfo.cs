using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Logic
{
    [Serializable]
    public class GameServerInfo : ServerInfo
    {
        public GameServerInfo()
        {
            TableIds = new List<string>();
        }

        public List<string> TableIds
        {
            get;
            set;
        }
    }
}
