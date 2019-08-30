using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BB.Poker.Common
{
    [Serializable]
    public enum DecisionType
    {
        DisconnectAndFold = 0,
        TimeOutAndFold = 1,
        InvalidAndFold = 2,
        Fold = 3,
        Check = 4,
        Call = 5,
        Raise = 6,
        AllIn = 7
    }
}
