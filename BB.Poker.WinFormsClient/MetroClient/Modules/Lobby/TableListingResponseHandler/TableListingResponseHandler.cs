using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public partial class LobbyModule
    {
        public class TableListingResponseHandler : GameClientMessageHandler<LobbyModule>
        {
            public TableListingResponseHandler(LobbyModule module)
                : base(module, GameMessageType.Client_ReceiveTableListingResponse)
            {
            }

            protected override void OnRun(IncomingMessage message)
            {
                TableListingResponse response = Module.Host.Serializer.GetObject<TableListingResponse>(message.Data);

                if (response.ResponseId.Equals(Module.ListingRequestId))
                {
                    Module.Control.AppendToTableList(response.TableSummaries);

                    message.WasMessageHandled = true;
                }
                else
                {
                    throw new InvalidOperationException("Was not expecting this message..");
                }
            }
        }
    }
}
