using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic.Hive
{
    public class HiveConnectionTracker
    {
        private ThreadSafeList<HiveConnectionRecord> records;

        public HiveConnectionTracker()
        {
            records = new ThreadSafeList<HiveConnectionRecord>();
        }

        public HiveConnectionRecord FindByServerId(string serverId)
        {
            lock (records.SyncLock)
            {
                foreach (HiveConnectionRecord cr in records)
                {
                    if (cr.ServerInfo.ServerId.Equals(serverId))
                        return cr.Clone();
                }

                return null;
            }
        }

        public HiveConnectionRecord FindByIPEndPoint(IPEndPoint nodeEndPoint)
        {
            lock (records.SyncLock)
            {
                foreach (HiveConnectionRecord cr in records)
                {
                    if (cr.RemoteEndPoint.Equals(nodeEndPoint))
                        return cr.Clone();
                }

                return null;
            }
        }

        public IPEndPoint GetEndPoint(string serverId)
        {
            lock (records.SyncLock)
            {
                foreach (HiveConnectionRecord cr in records)
                {
                    if (cr.ServerInfo.ServerId.Equals(serverId))
                        return cr.RemoteEndPoint;
                }

                return null;
            }
        }

        public void AddOrUpdateRecord(HiveConnectionRecord item)
        {
            lock (records.SyncLock)
            {
                if (Contains(item.ServerInfo.ServerId))
                    Remove(item.ServerInfo.ServerId);

                Add(item);
            }
        }

        public void Add(HiveConnectionRecord item)
        {
            if (item.ServerInfo == null)
                throw new InvalidOperationException("Invalid HiveConnectionRecord: Reference must be supplied.");

            if (string.IsNullOrEmpty(item.ServerInfo.ServerId))
                throw new InvalidOperationException("Invalid HiveConnectionRecord: ServerId must be supplied.");

            if (item.RemoteEndPoint == null)
                throw new InvalidOperationException("Invalid ConnectionRecord: RemoteEndPoint must be supplied.");

            if (string.IsNullOrEmpty(item.RemoteEndPoint.Address.ToString()))
                throw new InvalidOperationException("Invalid ConnectionRecord: PlayerEndPoint must be supplied.");

            lock (records.SyncLock)
            {
                if (Contains(item.ServerInfo.ServerId))
                    throw new InvalidOperationException("A particular Node cannot have more than one connection record in the connection tracker.");
                else
                    records.Add(item);
            }
        }

        public void Clear()
        {
            lock (records.SyncLock)
            {
                records.Clear();
            }
        }

        public bool Contains(string serverId)
        {
            if (string.IsNullOrEmpty(serverId))
                return false;

            lock (records.SyncLock)
            {
                foreach (HiveConnectionRecord cr in records)
                {
                    if (serverId.Equals(cr.ServerInfo.ServerId))
                        return true;
                }

                return false;
            }
        }

        public int Count
        {
            get
            {
                lock (records.SyncLock)
                {
                    return records.Count;
                }
            }
        }

        public bool Remove(string serverId)
        {
            if (string.IsNullOrEmpty(serverId))
                return false;

            lock (records.SyncLock)
            {
                bool haveItemsBeenRemoved = false;
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].ServerInfo.ServerId.Equals(serverId))
                    {
                        records.RemoveAt(i);
                        haveItemsBeenRemoved = true;    
                        --i;
                    }
                }

                return haveItemsBeenRemoved;
            }
        }

        public IEnumerator<HiveConnectionRecord> GetEnumerator()
        {
            return records.GetEnumerator();
        }
    }
}
