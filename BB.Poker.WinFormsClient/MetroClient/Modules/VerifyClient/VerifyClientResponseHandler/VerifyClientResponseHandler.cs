using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public partial class VerifyClientModule
    {
        public class VerifyClientResponseHandler : GameClientMessageHandler<VerifyClientModule>
        {
            public VerifyClientResponseHandler(VerifyClientModule module)
                : base(module, GameMessageType.Client_ReceiveVerifyClientResponse)
            {
            }

            protected override void OnRun(IncomingMessage message)
            {
                VerifyClientResponse vcr = Module.Host.Serializer.GetObject<VerifyClientResponse>(message.Data);

                if (vcr.IsAcceptable)
                {
                    Module.Control.ChangeStatus("Software is up to date..");
                    Module.Control.UpdateProgressBar(100);

                    Thread.Sleep(1000); // So user can see what's going on..

                    Module.OnModuleTaskCompleted(new EventArgs());
                }
                else
                {
                    Module.Control.UpdateProgressBar(0);
                    Module.Control.ChangeStatus("Your software is out of date. Please update your client.");
                    Module.Control.ShowButtons();
                }

                message.WasMessageHandled = true;
            }
        }
    }
}
