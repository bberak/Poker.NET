using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Logic
{
    public class RouteInfo
    {
        public string GatewayServerId { get; set; }

        public string GameServerId { get; set; }

        public string TableId { get; set; }

        public bool IsRoutedToTable()
        {
            if (string.IsNullOrEmpty(GameServerId) == false
                && string.IsNullOrEmpty(TableId) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
