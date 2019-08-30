using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public sealed class ThreadSafeList<T> : IEnumerable<T>
    {
        private List<T> m_list = new List<T>();
        private object m_lock = new object();

        public object SyncLock { get { return m_lock; } }

        public ThreadSafeList() { }

        public ThreadSafeList(IEnumerable<T> coll)
        {
            m_list = new List<T>(coll);
        }

        public ThreadSafeList(List<T> coll)
        {
            m_list = new List<T>(coll);
        }

        public ThreadSafeList(int capacity)
        {
            m_list = new List<T>(capacity);
        }

        public ThreadSafeList(ThreadSafeList<T> coll)
        {
            foreach (T item in coll)
            {
                Add(item);
            }
        }

        public void Add(T value)
        {
            lock (m_lock)
            {
                m_list.Add(value);
            }
        }
        public bool Remove(T value)
        {
            lock (m_lock)
            {
                return m_list.Remove(value);
            }
        }

        public void RemoveAt(int index)
        {
            lock (m_lock)
            {
                m_list.RemoveAt(index);
            }
        }

        public void RemoveAll(Predicate<T> match)
        {
            lock (m_lock)
            {
                m_list.RemoveAll(match);
            }
        }

        public bool Contains(T value)
        {
            lock (m_lock)
            {
                return m_list.Contains(value);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ThreadSafeEnumerator<T>(m_list.GetEnumerator(), m_lock);
        }

        public void Clear()
        {
            lock (m_lock)
            {
                m_list.Clear();
            }
        }

        public void Sort()
        {
            lock (m_lock)
            {
                m_list.Sort();
            }
        }

        public void Sort(IComparer<T> comparer)
        {
            lock (m_lock)
            {
                m_list.Sort(comparer);
            }
        }

        public int Count { get { lock (m_lock) { return m_list.Count; } } }
        public T this[int index]
        {
            get { lock (m_lock) { return m_list[index]; } }
            set { lock (m_lock) { m_list[index] = value; } }
        }

        public T Find(Predicate<T> match)
        {
            lock (m_lock)
            {
                return m_list.Find(match);
            }
        }

        public List<T> FindAll(Predicate<T> match)
        {
            lock (m_lock)
            {
                return m_list.FindAll(match);
            }
        }

        public int IndexOf(T item)
        {
            lock (m_lock)
            {
                return m_list.IndexOf(item);
            }
        }

        public int BinarySearch(T item)
        {
            lock (m_lock)
            {
                return m_list.BinarySearch(item);
            }
        }

        public void Insert(int index, T item)
        {
            lock (m_lock)
            {
                m_list.Insert(index, item);
            }
        }

        public static List<T> operator +(ThreadSafeList<T> list1, ThreadSafeList<T> list2)
        {
            lock (list1.SyncLock)
            {
                lock (list2.SyncLock)
                {
                    List<T> unionList = new List<T>();

                    foreach (T element in list1)
                        unionList.Add(element);

                    foreach (T element in list2)
                        unionList.Add(element);

                    return unionList;
                }
            }
        }

        public static List<T> operator +(ThreadSafeList<T> list1, List<T> list2)
        {
            lock (list1.SyncLock)
            {
                List<T> unionList = new List<T>();

                foreach (T element in list1)
                    unionList.Add(element);

                foreach (T element in list2)
                    unionList.Add(element);

                return unionList;
            }
        }

        public static implicit operator List<T>(ThreadSafeList<T> list)
        {
            lock (list.SyncLock)
            {
                List<T> returnList = new List<T>();

                foreach (T element in list)
                    returnList.Add(element);

                return returnList;
            }
        }

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new ThreadSafeEnumerator<T>(m_list.GetEnumerator(), m_lock);
        }

        #endregion
    }
}
