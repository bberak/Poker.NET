using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public partial class LoginModule
    {
        public class LoginResponseHandler : GameClientMessageHandler<LoginModule>
        {
            public LoginResponseHandler(LoginModule module)
                : base(module, GameMessageType.Client_ReceivePlayerLoginResponse)
            {
            }

            protected override void OnRun(IncomingMessage message)
            {
                LoginResponse response = Module.Host.Serializer.GetObject<LoginResponse>(message.Data);

                if (response.HasLoginSucceeded)
                {
                    Module.Host.UserAccount = new Account(response.PlayerName, "", response.AvailableFunds);
                    Module.OnModuleTaskCompleted(new EventArgs());               
                }
                else
                {
                    Module.Control.ChangeStatus("Incorrent usernname or password");
                }

                message.WasMessageHandled = true;
            }
        }
    }
}
