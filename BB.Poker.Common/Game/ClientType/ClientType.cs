using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public enum ClientType
    {
        Windows = 0,
        Mac = 1,
        Linux = 2,
        IPhone = 3,
        Android = 4,
        Other = 5
    }
}
