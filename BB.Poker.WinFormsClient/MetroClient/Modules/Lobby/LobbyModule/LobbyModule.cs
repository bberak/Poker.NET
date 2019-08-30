using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BB.Poker.Common;
using BB.Common.WinForms;

namespace BB.Poker.WinFormsClient
{
    public partial class LobbyModule : GameClientModule
    {
        protected LobbyModuleControl Control;
        protected string ListingRequestId;

        public LobbyModule(GameClientModuleHost host, string name)
            : base(host, name)
        {
        }

        public override void Focus(Control target)
        {
            base.Focus(target);

            MetroFlowMenu menu = (MetroFlowMenu)target;

            if (menu.Contains(Name) == false)
            {
                Host.UI.RegisterForDragFeedback(Control);
                menu.AddMenuItem(new MetroMenuItem(Control, MetroMenuTransition.EaseIn, Name));
            }

            menu.ShowMenu(Name);

            //-- Let the menu load..
            Thread.Sleep(500);

            //-- Listing table is empty..
            if (string.IsNullOrEmpty(ListingRequestId))
            {
                //-- Send a request to get the table list
                SendTableListingRequest();
                //-- Focus on the scroll bar as the list is about to grow..
                Control.FocusOnScrollBar();
            }
        }

        protected void SendTableListingRequest()
        {
            TableListingRequest request = new TableListingRequest();
            request.PlayerName = Host.UserAccount.PlayerName;
            request.RequestId = Guid.NewGuid().ToString();

            ListingRequestId = request.RequestId;

            Host.SendMessage(GameMessageType.Server_ReceiveTableListingRequest, request);
        }

        protected void SendJoinTableRequest(TableSummary ts)
        {
            JoinTableRequest request = new JoinTableRequest();
            request.JoinAsSpectator = true;
            request.AvailableChips = Host.UserAccount.Chips;
            request.PlayerName = Host.UserAccount.PlayerName;
            request.RequestId = Guid.NewGuid().ToString();
            request.TableToJoin = ts.TableId;

            Host.SendMessage(GameMessageType.Server_ReceiveJoinTableRequest, request);
        }

        protected override void LoadControls()
        {
            Control = new LobbyModuleControl();
            Control.Dock = DockStyle.Fill;
            Control.TableItemClicked += new EventHandler<TableItemClickedEventArgs>(Control_TableItemClicked);
            Control.RefreshButtonClicked += new EventHandler(Control_RefreshButtonClicked);
        }

        private void Control_RefreshButtonClicked(object sender, EventArgs e)
        {
            Control.ClearTableList();
            SendTableListingRequest();
        }

        private void Control_TableItemClicked(object sender, TableItemClickedEventArgs e)
        {
            SendJoinTableRequest(e.ChosenTable);
        }

        protected override void LoadMessageHandlers()
        {
            base.LoadMessageHandlers();

            MessageHandlers.Add(new TableListingResponseHandler(this));
            MessageHandlers.Add(new JoinTableResponseHandler(this));
        }
    }
}
