using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BB.Poker.Logic.Hive
{
    public class HiveConnectionRecord
    {
        public IPEndPoint RemoteEndPoint { get; set; }

        public ServerInfo ServerInfo { get; set; }

        public HiveConnectionRecord() { }

        public HiveConnectionRecord(ServerInfo serverInfo, IPEndPoint endpoint)
        {
            ServerInfo = serverInfo;

            RemoteEndPoint = endpoint;
        }

        public HiveConnectionRecord Clone()
        {
            HiveConnectionRecord newRecord = new HiveConnectionRecord();
            newRecord.ServerInfo = ServerInfo;
            newRecord.RemoteEndPoint = RemoteEndPoint;

            return newRecord;
        }
    }
}
