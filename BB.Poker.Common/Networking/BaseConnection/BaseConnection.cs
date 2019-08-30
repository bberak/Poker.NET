using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Lidgren.Network;

namespace BB.Poker.Common
{
    public class BaseConnection : IConnection<NetConnection>
    {
        public BaseConnection(NetConnection conn)
        {
            RemoteEndPoint = conn.RemoteEndpoint;
            UniqueIdentifier = conn.RemoteUniqueIdentifier;
            GenericConnection = conn;
        }

        public BaseConnection(IConnection<NetConnection> conn) 
        {
            RemoteEndPoint = conn.RemoteEndPoint;
            UniqueIdentifier = conn.UniqueIdentifier;
            GenericConnection = conn.GenericConnection;
        }

        public BaseConnection(IPEndPoint endpoint, long uid, NetConnection genConn)
        {
            RemoteEndPoint = endpoint;
            UniqueIdentifier = uid;
            GenericConnection = genConn;
        }

        public BaseConnection(IPAddress ip, int port, long uid, NetConnection genConn)
        {
            RemoteEndPoint = new IPEndPoint(ip, port);
            UniqueIdentifier = uid;
            GenericConnection = genConn;
        }

        public BaseConnection(IPEndPoint endPoint, long uid)
        {
            RemoteEndPoint = endPoint;
            UniqueIdentifier = uid;
            GenericConnection = null;
        }

        public static implicit operator NetConnection(BaseConnection bc)
        {
            if (bc.GenericConnection == null)
                throw new InvalidOperationException("The GenericConnection was not set. Perhaps you could query the RemoteEndPoint property instead?");

            return bc.GenericConnection;
        }

        #region IConnection<NetConnection> Members

        public NetConnection GenericConnection { get; protected set; }
        public IPEndPoint RemoteEndPoint { get; protected set; }
        public long UniqueIdentifier { get; protected set; }

        #endregion
    }
}
