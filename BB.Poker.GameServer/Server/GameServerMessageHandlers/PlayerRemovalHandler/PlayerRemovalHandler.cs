using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GameServer
{
    public class PlayerRemovalHandler : GameServerMessageHandler
    {
        public PlayerRemovalHandler(GameNetworkManager2 manager, ServerMessageType target)
            : base(manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            PlayerRemovalRequest prr = Manager.Serializer.GetObject<PlayerRemovalRequest>(message.Data);

            if (string.IsNullOrEmpty(prr.TableId) == false)
            {
                IGameTable gt = Manager.Tables[prr.TableId];

                if (gt != null)
                {
                    gt.PlayerPortal.RemovePlayer(prr.PlayerName);
                }
            }

            message.WasMessageHandled = true;
        }
    }
}
