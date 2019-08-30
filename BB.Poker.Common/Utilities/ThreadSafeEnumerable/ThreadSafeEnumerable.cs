using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    //-- http://www.codeproject.com/KB/cs/safe_enumerable.aspx
    public class ThreadSafeEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> m_Inner;
        private readonly object m_Lock;

        public ThreadSafeEnumerable(IEnumerable<T> inner, object @lock)
        {
            m_Lock = @lock;
            m_Inner = inner;
        }

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return new ThreadSafeEnumerator<T>(m_Inner.GetEnumerator(), m_Lock);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
