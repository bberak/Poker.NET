using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public class PlayerLoginHandler : GatewayGameMessageHandler
    {
        public PlayerLoginHandler(GatewayNetworkManager2 manager, GameMessageType target)
            : base(manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            LoginRequest login = Manager.Serializer.GetObject<LoginRequest>(message.Data);

            LoginResponse response = new LoginResponse();
            response.ResponseId = login.RequestId;

            if (string.IsNullOrEmpty(login.PlayerName) == false && string.IsNullOrEmpty(login.Password) == false)
            {
                //-- Tell the other servers to log this player out.
                string logoutMessage = "You have been logged out because you have connected to the Poker Reloaded Network on a different client application.";
                Manager.SendPlayerRemovalRequest(login.PlayerName, true, logoutMessage);

                response.AvailableFunds = 3000;
                response.HasLoginSucceeded = true;
                response.PlayerName = login.PlayerName;

                //-- Remove this player's record if they have previously logged in..
                //-- Could just to an update here..
                List<ConnectionRecord> list = Manager.PlayerConnectionTracker.GetRecordsByNameOrEndPoint(login.PlayerName, message.Sender);

                foreach (ConnectionRecord record in list)
                {
                    Manager.SendLogoutRequest(record.PlayerName, logoutMessage);

                    Manager.CleanPlayerFootprint(record.PlayerName, GatewayNetworkManager2.PlayerFootprintCleanupType.CleanForSuccessfulLogin);
                }

                ConnectionRecord cr = new ConnectionRecord(login.PlayerName, message.Sender);
                Manager.PlayerConnectionTracker.AddOrUpdateRecord(cr);
                ServerUIShell.WriteLine("-Player has logged in (" + login.PlayerName + ")");
            }
            else
            {
                response.HasLoginSucceeded = false;
                response.ServerMessage = "Your username and password were incorrect.";
            }

            Manager.SendMessageToPlayers(GameMessageType.Client_ReceivePlayerLoginResponse, Manager.Serializer.GetBytes(response), message.Sender.ToList());

            message.WasMessageHandled = true;
        }
    }
}
