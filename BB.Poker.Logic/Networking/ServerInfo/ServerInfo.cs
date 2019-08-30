using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BB.Poker.Logic
{
    [Serializable]
    public class ServerInfo
    {
        public ServerInfo() { }

        public ServerInfo(string serverId)
        {
            ServerId = serverId;
        }

        public ServerType Type { get; set; }

        public string ServerId { get; set; }

        public override int GetHashCode()
        {
            return ServerId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is ServerInfo)
            {
                ServerInfo otherServerRef = obj as ServerInfo;
                return ServerId.Equals(otherServerRef.ServerId);
            }
            return false;
        }
    }
}
