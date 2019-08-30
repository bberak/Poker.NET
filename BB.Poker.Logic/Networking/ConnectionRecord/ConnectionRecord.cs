using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace BB.Poker.Logic
{
    public class ConnectionRecord : TinyConnectionRecord
    {
        public string PlayerName { get; set; }
        public IPEndPoint PlayerEndPoint { get; set; }

        public ConnectionRecord() : base()
        {
        }

        public ConnectionRecord(string name, IPEndPoint endPoint): base()
        {
            PlayerName = name;
            PlayerEndPoint = endPoint;
        }

        public ConnectionRecord(string name, IPEndPoint endPoint, string gameServerId, string tableId) : base (gameServerId, tableId)
        {
            PlayerName = name;
            PlayerEndPoint = endPoint;
        }

        public new ConnectionRecord Clone()
        {
            ConnectionRecord newRecord = new ConnectionRecord();
            newRecord.PlayerName = PlayerName;
            newRecord.PlayerEndPoint = PlayerEndPoint;
            newRecord.GameServerId = GameServerId;
            newRecord.TableId = TableId;

            return newRecord;
        }

        public void UpdateWith(ConnectionRecord me)
        {
            PlayerName = me.PlayerName;
            PlayerEndPoint = me.PlayerEndPoint;
            GameServerId = me.GameServerId;
            TableId = me.TableId;
        }

        public override int GetHashCode()
        {
            return PlayerName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is ConnectionRecord)
            {
                ConnectionRecord compareTo = (ConnectionRecord)obj;

                if (compareTo.PlayerName.Equals(PlayerName))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
