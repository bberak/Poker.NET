using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BB.Poker.Common
{
    public abstract class BaseNetworkManager<T> : MessageHandlerComponent<T>
    {
        public string AppId { get; protected set; }

        public ISerialize Serializer { get; protected set; }

        public BaseNetworkManager(string appId, ISerialize serializer)
        {
            this.AppId = appId;
            this.Serializer = serializer;
        }

        public bool IsRunning { get; protected set; }

        public abstract void Start();

        public abstract void Shutdown();
    }
}
