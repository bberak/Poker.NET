using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;
using BB.Poker.Logic;

namespace BB.Poker.GatewayServer
{
    public class MessageToClientHandler : GatewayServerMessageHandler
    {
        public MessageToClientHandler(GatewayNetworkManager2 manager, ServerMessageType target)
            : base (manager, target)
        {
        }

        protected override void OnRun(IncomingMessage message)
        {
            ClientBoundSeverEnvelopeObject envelope = Manager.Serializer.GetObject<ClientBoundSeverEnvelopeObject>(message.Data);

            Manager.SendMessageToPlayers((GameMessageType)envelope.InnerOperationCode, envelope.InnerData, envelope.PlayerNames);

            if (envelope.InnerOperationCode == (int)GameMessageType.Client_ReceiveJoinTableResponse)
                OnJoinTableResponse(Manager.Serializer.GetObject<JoinTableResponse>(envelope.InnerData));
            else if (envelope.InnerOperationCode == (int)GameMessageType.Client_ReceiveForcedTableLeaveNotice)
                OnForcedTableLeaveNotice(Manager.Serializer.GetObject<ForcedTableLeaveNotice>(envelope.InnerData));

            message.WasMessageHandled = true;
        }

        protected virtual void OnJoinTableResponse(JoinTableResponse jtres)
        {
            if (jtres.WasJoinSuccessful)
            {
                ConnectionRecord record = Manager.PlayerConnectionTracker.GetRecordByPlayerName(jtres.PlayerName);

                //-- Only update their connection record with the GameServerId and TableId
                //-- if a record already exists (i.e. the player has logged in)
                if (record != null)
                {
                    //-- Is player already sitting at table?
                    if (record.IsSittingAtTable())
                    {
                        string message = "You have been removed from table " + record.TableId + " because you have joined table " + jtres.TableToJoin;

                        Manager.SendForcedTableLeaveNotice(record.PlayerName, message, record.TableId);

                        Manager.SendPlayerRemovalRequest(record.PlayerName, false, message);
                    }

                    record.GameServerId = jtres.GameServerId;
                    record.TableId = jtres.TableToJoin;

                    Manager.PlayerConnectionTracker.AddOrUpdateRecord(record);
                    //-- OR 
                    //PlayerConnectionTracker.UpdateRecord(record.PlayerName, record.GameServerId, record.TableId);

                    ServerUIShell.WriteLine("-Player has joined a table (" + record.PlayerName + ")");
                }
            }
        }

        protected virtual void OnForcedTableLeaveNotice(ForcedTableLeaveNotice notice)
        {
            Manager.CleanPlayerFootprint(notice.PlayerName, GatewayNetworkManager2.PlayerFootprintCleanupType.CleanForForcedTableLeaveNotice);

            ServerUIShell.WriteLine("-Player has been forced to leave table (" + notice.PlayerName + ")");
        }
    }
}
