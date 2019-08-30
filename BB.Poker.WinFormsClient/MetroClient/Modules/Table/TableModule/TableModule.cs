using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BB.Poker.Common;
using BB.Common.WinForms;

namespace BB.Poker.WinFormsClient
{
    public partial class TableModule : GameClientModule
    {
        protected TableModuleControl Control;

        public TableModule(GameClientModuleHost host, string name)
            : base(host, name)
        {
            Host.TableSummaryReceived += new GameMessageReceivedEventHandler<TableSummary>(Host_TableSummaryReceived);
            Host.PlayerSummariesReceived += new GameMessageReceivedEventHandler<PlayerSummary[]>(Host_PlayerSummariesReceived);
        }

        void Host_PlayerSummariesReceived(object sender, GameMessageReceivedEventArgs<PlayerSummary[]> e)
        {
            e.WasMessageHandled = true;
        }

        void Host_TableSummaryReceived(object sender, GameMessageReceivedEventArgs<TableSummary> e)
        {
            e.WasMessageHandled = true;
        }

        public override void Focus(Control target)
        {
            base.Focus(target);

            MetroFlowMenu menu = (MetroFlowMenu)target;

            if (menu.Contains(Name) == false)
            {
                Host.UI.RegisterForDragFeedback(Control);
                Host.UI.RegisterForDragFeedback(Control.DeckAndPotControl);

                menu.AddMenuItem(new MetroMenuItem(Control, MetroMenuTransition.EaseIn, Name));
            }

            menu.ShowMenu(Name);
        }

        protected override void LoadControls()
        {
            Control = new TableModuleControl();
            Control.Dock = DockStyle.Fill;
        }

        protected override void LoadMessageHandlers()
        {
            base.LoadMessageHandlers();
        }
    }
}
