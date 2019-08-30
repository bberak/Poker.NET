using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Lidgren.Network;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    [Serializable]
    public class PlayerCollection : IFreezeable, IGenericCloneable<PlayerCollection>, IEnumerable<Player>
    {
        private ThreadSafeList<Player> m_plPlayerList;
        private bool isFrozen;

        public object SyncLock { get { return m_plPlayerList.SyncLock; } }

        public PlayerCollection()
        {
            m_plPlayerList = new ThreadSafeList<Player>();
        }

        public PlayerCollection(IEnumerable<Player> coll)
        {
            m_plPlayerList = new ThreadSafeList<Player>(coll);
        }

        public PlayerCollection(List<Player> coll)
        {
            m_plPlayerList = new ThreadSafeList<Player>(coll);
        }

        public PlayerCollection(ThreadSafeList<Player> coll)
        {
            m_plPlayerList = new ThreadSafeList<Player>(coll);
        }

        public PlayerCollection(Player p)
        {
            m_plPlayerList = new ThreadSafeList<Player>();
            Add(p);
        }

        public Player this[string name]
        {
            get 
            { 
                Player found = null;

                lock (m_plPlayerList.SyncLock)
                {
                    foreach (Player p in m_plPlayerList)
                    {
                        if (p.Name.Equals(name))
                        {
                            found = p;
                            break;
                        }
                    }
                }

                return found;
            }
        }

        public Player this[int index]
        {
            get 
            {
                lock (m_plPlayerList.SyncLock)
                {
                    return m_plPlayerList[index];
                }
            }
            set 
            {
                lock (m_plPlayerList.SyncLock)
                {
                    m_plPlayerList[index] = value;
                }
            }
        }

        public void Sort()
        {
            if (IsFrozen)
                throw new InvalidOperationException("This component is frozen and cannot be altered. Call the Clone() method to retrieve a copy.");

            lock (m_plPlayerList.SyncLock)
            {
                m_plPlayerList.Sort();
            }
        }

        public void Sort(IComparer<Player> comparer)
        {
            if (IsFrozen)
                throw new InvalidOperationException("This component is frozen and cannot be altered. Call the Clone() method to retrieve a copy.");

            lock (m_plPlayerList.SyncLock)
            {
                m_plPlayerList.Sort(comparer);
            }
        }

        #region ICollection<Player> Members

        public void Add(Player item)
        {
            if (IsFrozen)
                throw new InvalidOperationException("This component is frozen and cannot be altered. Call the Clone() method to retrieve a copy.");

            lock (m_plPlayerList.SyncLock)
            {
                m_plPlayerList.Add(item);
            }
        }

        public void Clear()
        {
            if (IsFrozen)
                throw new InvalidOperationException("This component is frozen and cannot be altered. Call the Clone() method to retrieve a copy.");

            lock (m_plPlayerList.SyncLock)
            {
                m_plPlayerList.Clear();
            }
        }

        public bool Contains(Player item)
        {
            lock (m_plPlayerList.SyncLock)
            {
                return m_plPlayerList.Contains(item);
            }
        }

        public int Count
        {
            get
            {
                lock (m_plPlayerList.SyncLock)
                {
                    return m_plPlayerList.Count;
                }
            }
        }

        public bool IsReadOnly
        {
            get { return isFrozen; }
        }

        public bool Remove(Player item)
        {
            if (IsFrozen)
                throw new InvalidOperationException("This component is frozen and cannot be altered. Call the Clone() method to retrieve a copy.");

            lock (m_plPlayerList.SyncLock)
            {
                return m_plPlayerList.Remove(item);
            }
        }

        #endregion

        #region IEnumerable<Player> Members

        public IEnumerator<Player> GetEnumerator()
        {
            lock (m_plPlayerList.SyncLock)
            {
                return m_plPlayerList.GetEnumerator();
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            lock (m_plPlayerList.SyncLock)
            {
                foreach (Player p in this)
                    sb.Append(p.ToString() + Environment.NewLine);
            }
            
            return sb.ToString().TrimEnd();
        }

        public IEnumerable<Player> GetSubset(PlayerState pState)
        {
            lock (m_plPlayerList.SyncLock)
            {
                var subset = from p in this
                             where (pState & p.State) == p.State
                             select p;

                return subset;
            }
        }

        public IEnumerable<Player> GetActivePlayers()
        {
            lock (m_plPlayerList.SyncLock)
            {
                var activePlayers = from p in this
                                    where p.State == PlayerState.Playing
                                    select p;

                return activePlayers;
            }
        }

        public int ActivePlayerCount
        {
            get
            {
                lock (m_plPlayerList.SyncLock)
                {
                    return this.GetActivePlayers().Count<Player>();
                }
            }
        }

        public static PlayerCollection operator +(PlayerCollection coll1, PlayerCollection coll2)
        {
            lock (coll1.SyncLock)
            {
                lock (coll2.SyncLock)
                {
                    PlayerCollection unionList = new PlayerCollection();

                    foreach (Player p in coll1)
                        unionList.Add(p);

                    foreach (Player p in coll2)
                        unionList.Add(p);

                    return unionList;
                }
            }
        }

        public static PlayerCollection operator +(IEnumerable<Player> coll1, PlayerCollection coll2)
        {
            lock (coll2.SyncLock)
            {
                PlayerCollection unionList = new PlayerCollection();

                foreach (Player p in coll1)
                    unionList.Add(p);

                foreach (Player p in coll2)
                    unionList.Add(p);

                return unionList;
            }
        }

        public static PlayerCollection operator -(PlayerCollection coll1, PlayerCollection coll2)
        {
            lock (coll1.SyncLock)
            {
                lock (coll2.SyncLock)
                {
                    PlayerCollection subtractedList = new PlayerCollection(coll1);

                    foreach (Player p in coll2)
                        subtractedList.Remove(p);

                    return subtractedList;
                }
            }
        }

        public static PlayerCollection operator -(IEnumerable<Player> coll1, PlayerCollection coll2)
        {
            lock (coll2.SyncLock)
            {
                PlayerCollection subtractedList = new PlayerCollection(coll1);

                foreach (Player p in coll2)
                    subtractedList.Remove(p);

                return subtractedList;
            }
        }

        public static implicit operator Player[](PlayerCollection coll)
        {
            lock (coll.SyncLock)
            {
                return coll.ToArray<Player>();
            }
        }

        public static implicit operator List<Player>(PlayerCollection coll)
        {
            lock (coll.SyncLock)
            {
                return coll.ToList<Player>();
            }
        }

        #region IFreezeable Members

        public void Freeze()
        {
            isFrozen = true;
        }

        public bool IsFrozen
        {
            get { return isFrozen; }
        }

        #endregion

        #region IGenericCloneable<PlayerCollection> Members

        public PlayerCollection Clone()
        {
            lock (m_plPlayerList.SyncLock)
            {
                return new PlayerCollection(m_plPlayerList);
            }
        }

        #endregion
    }
}
