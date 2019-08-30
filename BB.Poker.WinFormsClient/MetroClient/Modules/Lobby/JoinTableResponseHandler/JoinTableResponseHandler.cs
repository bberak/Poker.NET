using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public partial class LobbyModule
    {
        public class JoinTableResponseHandler : GameClientMessageHandler<LobbyModule>
        {
            public JoinTableResponseHandler(LobbyModule module)
                : base(module, GameMessageType.Client_ReceiveJoinTableResponse)
            {
            }

            protected override void OnRun(IncomingMessage message)
            {
                JoinTableResponse response = Module.Host.Serializer.GetObject<JoinTableResponse>(message.Data);

                if (response.WasJoinSuccessful)
                {
                    Module.OnModuleTaskCompleted(new EventArgs());
                }
                else
                {
                    MetroMessageBox.Show(response.ServerMessage);
                }

                message.WasMessageHandled = true;
            }
        }
    }
}
