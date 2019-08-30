using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;

namespace BB.Poker.Logic
{
    public class MessageQueue<T> : IMessageQueue<T>
    {
        private Queue m_qUnsyncedQueue;
        private Queue m_qSyncedQueue;

        public MessageQueue()
        {
            m_qUnsyncedQueue = new Queue();
            m_qSyncedQueue = Queue.Synchronized(m_qUnsyncedQueue);
        }

        #region IMessageQueue<T> Members

        public T Read()
        {
            if (HasMessages())
                return (T)m_qSyncedQueue.Dequeue();
            else
                return default(T);
        }

        public T Peek()
        {
            if (HasMessages())
                return (T)m_qSyncedQueue.Peek();
            else
                return default(T);
        }

        public IEnumerator GetEnumerator()
        {
            return m_qSyncedQueue.GetEnumerator();
        }

        public void Add(T item)
        {
            m_qSyncedQueue.Enqueue(item);
        }

        public bool HasMessages()
        {
            if (m_qSyncedQueue.Count > 0)
                return true;
            else
                return false;
        }

        public void Persist()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
