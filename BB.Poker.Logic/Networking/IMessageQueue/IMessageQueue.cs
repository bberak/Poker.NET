using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Logic
{
    public interface IMessageQueue<T>
    {
        T Read();
        T Peek();
        IEnumerator GetEnumerator();
        void Add(T item);
        bool HasMessages();
        void Persist();
    }
}
