using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public class PlayerLogoutHandler : InGameMessageHandler
    {
        public PlayerLogoutHandler(GatewayNetworkManager2 manager, GameMessageType target)
            : base(manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            PlayerLogoutNotice notice = Manager.Serializer.GetObject<PlayerLogoutNotice>(message.Data);

            ConnectionRecord cr = Manager.PlayerConnectionTracker.GetRecordByPlayerName(notice.PlayerName);

            //-- Remove the player's connection record..
            if (cr != null)
            {
                //-- Send the logout notice to the game server..
                if (cr.IsSittingAtTable())
                    base.OnRun(message);

                Manager.CleanPlayerFootprint(cr.PlayerName, GatewayNetworkManager2.PlayerFootprintCleanupType.CleanForPlayerLogoutNotice);

                ServerUIShell.WriteLine("-Player has logged out (" + notice.PlayerName + ")");
            }

            message.WasMessageHandled = true;
        }
    }
}
