using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public static class Extensions
    {
        public static ServerInfo FindByServerId(this List<ServerInfo> me, string serverId)
        {
            foreach (ServerInfo info in me)
            {
                if (info.ServerId.Equals(serverId))
                {
                    return info;
                }
            }

            return null;
        }

        public static List<string> GetUniqueGatewayServerIds(this List<Player> me)
        {
            List<string> ids = new List<string>();

            foreach (Player p in me)
            {
                if (ids.Contains(p.GatewayServerId) == false)
                    ids.Add(p.GatewayServerId);
            }

            return ids;
        }

        public static List<string> GetPlayerNames(this List<Player> me)
        {
            List<string> names = new List<string>();

            foreach (Player p in me)
            {
                names.Add(p.Name);
            }

            return names;
        }

        public static List<ServerInfo> FindByType(this List<ServerInfo> me, ServerType type)
        {
            List<ServerInfo> result = new List<ServerInfo>();

            foreach (ServerInfo si in me)
            {
                if (si.Type == type)
                    result.Add(si);
            }

            return result;
        }

        public static List<string> GetServerIds(this List<ServerInfo> me)
        {
            List<string> result = new List<string>();

            foreach (ServerInfo si in me)
            {
                result.Add(si.ServerId);
            }

            return result;
        }

        public static RouteInfo ToRouteInfo(this ConnectionRecord record, string gatewayServerId)
        {
            RouteInfo routeInfo = new RouteInfo();
            routeInfo.GatewayServerId = gatewayServerId;
            routeInfo.GameServerId = record.GameServerId;
            routeInfo.TableId = record.TableId;

            return routeInfo;
        }

        public static int GetLowerBroadcastPort(this string range)
        {
            string[] arr = range.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            return Convert.ToInt32(arr[0].Trim());
        }

        public static int GetUpperBroadcastPort(this string range)
        {
            string[] arr = range.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            return Convert.ToInt32(arr[1].Trim());
        }
    }
}
