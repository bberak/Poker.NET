using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BB.Poker.Common
{
    //-- http://www.codeproject.com/KB/cs/safe_enumerable.aspx
    public class ThreadSafeEnumerator<T> : IEnumerator<T>
    {
        public const int DEFAULT_LOCK_TIMEOUT = 10000;

        // this is the (thread-unsafe)
        // enumerator of the underlying collection
        private readonly IEnumerator<T> m_Inner;
        // this is the object we shall lock on. 
        private readonly object m_Lock;

        //-- Lock timeout duration;
        private readonly int m_intLockTimeout;

        public ThreadSafeEnumerator(IEnumerator<T> inner, object @lock)
            : this(inner, @lock, DEFAULT_LOCK_TIMEOUT)
        {

        }

        public ThreadSafeEnumerator(IEnumerator<T> inner, object @lock, int timeout)
        {
            m_Inner = inner;
            m_Lock = @lock;
            m_intLockTimeout = timeout;

            // entering lock in constructor
            if (Monitor.TryEnter(m_Lock, m_intLockTimeout) == false)
                throw new TimeoutException("A lock could not be achieved in time, a deadlock situation may have occurred.");
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            // .. and exiting lock on Dispose()
            // This will be called when foreach loop finishes
            Monitor.Exit(m_Lock);
        }

        #endregion

        #region Implementation of IEnumerator

        // we just delegate actual implementation
        // to the inner enumerator, that actually iterates
        // over some collection

        public bool MoveNext()
        {
            return m_Inner.MoveNext();
        }

        public void Reset()
        {
            m_Inner.Reset();
        }

        public T Current
        {
            get { return m_Inner.Current; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        #endregion
    }
}
