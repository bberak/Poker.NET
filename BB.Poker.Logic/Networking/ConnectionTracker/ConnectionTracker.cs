using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class ConnectionTracker
    {
        class TableColumns
        {
            public const string PlayerName = "PlayerName";
            public const string PlayerEndPoint = "PlayerEndPoint";
            public const string GameServerId = "GameServerId";
            public const string TableId = "TableId";

            public const int PlayerNameIndex = 0;
            public const int PlayerEndPointIndex = 1;
            public const int GameServerIdIndex = 2;
            public const int TableIdIndex = 3;
        }

        private DataTable Records;

        private object RecordsSyncLock;

        public ConnectionTracker()
        {
            Records = GetTable();

            RecordsSyncLock = new object();
        }

        private static ConnectionRecord FormatRow(DataRow row)
        {
            //-- Could really cache the endpoint somewhere after parsing..
            return new ConnectionRecord((string)row[TableColumns.PlayerNameIndex], 
                IPTools.IPEndPointFromString((string)row[TableColumns.PlayerEndPointIndex]),
                (string)row[TableColumns.GameServerIdIndex],
                (string)row[TableColumns.TableIdIndex]);
        }

        private static TinyConnectionRecord FormatRow2(DataRow row)
        {
            return new TinyConnectionRecord((string)row[TableColumns.GameServerIdIndex],
                (string)row[TableColumns.TableIdIndex]);
        }

        private void Validate(ConnectionRecord item)
        {
            if (string.IsNullOrEmpty(item.PlayerName))
                throw new InvalidOperationException("Invalid ConnectionRecord: PlayerName must be supplied.");

            if (item.PlayerEndPoint == null)
                throw new InvalidOperationException("Invalid ConnectionRecord: PlayerEndPoint must be supplied.");
        }

        public ConnectionRecord GetRecordByPlayerName(string playerName)
        {
            DataRow result = Records.Rows.Find(playerName);
            if (result != null)
                return FormatRow(result);
            else
                return null;
        }

        public TinyConnectionRecord GetTinyRecordByPlayerName(string playerName)
        {
            DataRow result = Records.Rows.Find(playerName);
            if (result != null)
                return FormatRow2(result);
            else
                return null;
        }

        public ConnectionRecord GetRecordByIPEndPoint(IPEndPoint playerEndPoint)
        {
            DataRow[] results = Records.Select(string.Format("PlayerEndPoint = '{0}'", playerEndPoint.ToString()));
            if (results != null && results.Length > 0)
                return FormatRow(results[0]);
            else
                return null;
        }

        public List<ConnectionRecord> GetRecordsByNameOrEndPoint(string name, IPEndPoint endPoint)
        {
            List<ConnectionRecord> crList = new List<ConnectionRecord>();

            DataRow[] rows = Records.Select(string.Format("PlayerName = '{0}' OR PlayerEndPoint = '{1}'", name, endPoint.ToString()));

            if (rows != null && rows.Length > 0)
            {
                foreach (DataRow dr in rows)
                {
                    crList.Add(FormatRow(dr));
                }
            }

            return crList;
        }

        public List<ConnectionRecord> GetRecordsByGameServerId(string gameServerId)
        {
            List<ConnectionRecord> crList = new List<ConnectionRecord>();

            DataRow[] rows = Records.Select(string.Format("GameServerId = '{0}'", gameServerId));

            if (rows != null && rows.Length > 0)
            {
                foreach (DataRow dr in rows)
                {
                    crList.Add(FormatRow(dr));
                }
            }

            return crList;
        }

        public IPEndPoint GetIPEndPointByPlayerName(string playerName)
        {
            //-- Could really cache the endpoint somewhere after parsing..
            DataRow result = Records.Rows.Find(playerName);
            if (result != null)
                return IPTools.IPEndPointFromString((string)result[TableColumns.PlayerEndPointIndex]);
            else
                return null;
        }

        public bool Contains(string playerName)
        {
            DataRow result = Records.Rows.Find(playerName);
            if (result != null)
                return true;
            else
                return false;
        }

        public void AddOrUpdateRecord(ConnectionRecord item)
        {
            Validate(item);

            lock (RecordsSyncLock)
            {
                DataRow existing = Records.Rows.Find(item.PlayerName);

                if (existing != null)
                {
                    //-- PlayerName is readonly.
                    existing[TableColumns.PlayerEndPointIndex] = item.PlayerEndPoint.ToString();
                    existing[TableColumns.GameServerIdIndex] = item.GameServerId;
                    existing[TableColumns.TableIdIndex] = item.TableId;
                }
                else
                    Records.Rows.Add(item.PlayerName, item.PlayerEndPoint.ToString(), item.GameServerId, item.TableId);
            }
        }

        public void UpdateRecord(string playerName, string gameServerId, string tableId)
        {
            lock (RecordsSyncLock)
            {
                DataRow existing = Records.Rows.Find(playerName);

                if (existing != null)
                {
                    //-- PlayerName is readonly.
                    existing[TableColumns.GameServerIdIndex] = gameServerId;
                    existing[TableColumns.TableIdIndex] = tableId;
                }
                else
                    throw new DataException("Could not find row with Primary Key=" + playerName);
            }
        }

        public void Clear()
        {
            lock (RecordsSyncLock)
            {
                Records.Rows.Clear();
            }
        }

        public int Count
        {
            get
            {
                lock (RecordsSyncLock)
                {
                    return Records.Rows.Count;
                }
            }
        }

        public bool Remove(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
                return false;

            lock (RecordsSyncLock)
            {
                bool haveItemsBeenRemoved = false;

                DataRow deleteMe = Records.Rows.Find(playerName);

                if (deleteMe != null)
                {
                    deleteMe.Delete();

                    haveItemsBeenRemoved = true;
                }

                return haveItemsBeenRemoved;
            }
        }

        private static DataTable GetTable()
        {
            //-- Here we create a DataTable with four columns.
            DataTable table = new DataTable();
 
            DataColumn playerName = new DataColumn();
            playerName.DataType = typeof(string);
            playerName.ColumnName = TableColumns.PlayerName;
            playerName.ReadOnly = true;
            playerName.Unique = true;
            playerName.AutoIncrement = false;
            table.Columns.Add(playerName);

            DataColumn playerEndPoint = new DataColumn();
            playerEndPoint.DataType = typeof(string);
            playerEndPoint.ColumnName = TableColumns.PlayerEndPoint;
            playerEndPoint.ReadOnly = false;
            playerEndPoint.Unique = true;
            playerEndPoint.AutoIncrement = false;
            table.Columns.Add(playerEndPoint);

            DataColumn gameServerId = new DataColumn();
            gameServerId.DataType = typeof(string);
            gameServerId.ColumnName = TableColumns.GameServerId;
            gameServerId.ReadOnly = false;
            gameServerId.Unique = false;
            gameServerId.AutoIncrement = false;
            gameServerId.DefaultValue = string.Empty;
            table.Columns.Add(gameServerId);

            DataColumn tableId = new DataColumn();
            tableId.DataType = typeof(string);
            tableId.ColumnName = TableColumns.TableId;
            tableId.ReadOnly = false;
            tableId.Unique = false;
            tableId.AutoIncrement = false;
            tableId.DefaultValue = string.Empty;
            table.Columns.Add(tableId);

            table.PrimaryKey = new DataColumn[] { playerName };
            return table;
        }
    }
}
