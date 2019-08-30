using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class JoinTableEventArgs : EventArgs
    {
        public JoinTableRequest Request { get; protected set; }

        public RouteInfo RouteInfo { get; protected set; }

        public JoinTableEventArgs(JoinTableRequest request, RouteInfo routeInfo)
        {
            Request = request;

            RouteInfo = routeInfo;
        }
    }
}
