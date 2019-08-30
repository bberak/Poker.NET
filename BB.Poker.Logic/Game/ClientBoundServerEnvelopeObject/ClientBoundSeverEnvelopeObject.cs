using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Logic
{
    [Serializable]
    public class ClientBoundSeverEnvelopeObject : ServerEnvelopeObject
    {
        public List<string> PlayerNames { get; set; }
    }
}
