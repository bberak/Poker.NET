using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public interface IFreezeable
    {
        void Freeze();
        bool IsFrozen { get; }
    }
}
