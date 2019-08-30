using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class TableListingRequest : BaseClientMessageObject, IRequestObject
    {
        public string RequestId { get; set; }
    }
}
