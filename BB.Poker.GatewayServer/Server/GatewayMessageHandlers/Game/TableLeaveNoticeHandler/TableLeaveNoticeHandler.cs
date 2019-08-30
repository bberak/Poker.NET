using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public class TableLeaveNoticeHandler : InGameMessageHandler
    {
        public TableLeaveNoticeHandler(GatewayNetworkManager2 manager, GameMessageType target)
            : base(manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            base.OnRun(message);

            TableLeaveNotice notice = Manager.Serializer.GetObject<TableLeaveNotice>(message.Data);

            Manager.CleanPlayerFootprint(notice.PlayerName, GatewayNetworkManager2.PlayerFootprintCleanupType.CleanForTableLeaveNotice);

            ServerUIShell.WriteLine("-Player has left a table (" + notice.PlayerName + ")");

            message.WasMessageHandled = true;
        }
    }
}
