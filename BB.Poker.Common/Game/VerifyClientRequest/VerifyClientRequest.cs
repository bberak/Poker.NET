using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class VerifyClientRequest : IRequestObject
    {
        public Client Client { get; set; }

        public string RequestId { get; set; }
    }
}
