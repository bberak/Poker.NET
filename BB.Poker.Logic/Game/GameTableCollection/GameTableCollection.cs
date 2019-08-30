using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class GameTableCollection : ICollection<IGameTable>
    {
        private List<IGameTable> m_gtlTables;

        public GameTableCollection()
        {
            m_gtlTables = new List<IGameTable>();
        }

        public TableSummary[] GetTableSummaries()
        {
            List<TableSummary> summaries = new List<TableSummary>();

            foreach (IGameTable gt in m_gtlTables)
                summaries.Add(gt.GetSummary());

            return summaries.ToArray();
        }

        public IGameTable this[string id]
        {
            get
            {
                IGameTable found = null;

                foreach (IGameTable g in m_gtlTables)
                {
                    if (g.TableId.Equals(id))
                    {
                        found = g;
                        break;
                    }
                }

                return found;
            }
        }

        public IGameTable this[int index]
        {
            get { return m_gtlTables[index]; }

            set { m_gtlTables[index] = value; }
        }

        #region ICollection<IGameTable> Members

        public void Add(IGameTable item)
        {
            m_gtlTables.Add(item);
        }

        public void Clear()
        {
            m_gtlTables.Clear();
        }

        public bool Contains(IGameTable item)
        {
            return m_gtlTables.Contains(item);
        }

        public void CopyTo(IGameTable[] array, int arrayIndex)
        {
            m_gtlTables.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return m_gtlTables.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(IGameTable item)
        {
            return m_gtlTables.Remove(item);
        }

        #endregion

        #region IEnumerable<IGameTable> Members

        public IEnumerator<IGameTable> GetEnumerator()
        {
            return m_gtlTables.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_gtlTables.GetEnumerator();
        }

        #endregion
    }
}
