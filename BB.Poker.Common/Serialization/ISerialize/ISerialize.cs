using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public interface ISerialize
    {
        T GetObject<T>(byte[] data);
        byte[] GetBytes(object dataObject);
    }
}
