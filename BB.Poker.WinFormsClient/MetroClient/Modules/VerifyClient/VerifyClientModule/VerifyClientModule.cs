using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BB.Poker.Common;
using BB.Common.WinForms;

namespace BB.Poker.WinFormsClient
{
    public partial class VerifyClientModule : GameClientModule
    {
        public VerifyClientModuleControl Control { get; protected set; }

        public VerifyClientModule(GameClientModuleHost host, string name)
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
                menu.AddMenuItem(new MetroMenuItem(Control, MetroMenuTransition.Instant, Name));
                Control.SetProgressStyle(MetroProgressBarStyle.Marquee);
            }

            menu.ShowMenu(Name);

            Thread.Sleep(1000); // So user can see what's going on..

            VerifyClientRequest vcr = new VerifyClientRequest();
            vcr.Client = Host.Client;
            vcr.RequestId = Guid.NewGuid().ToString();

            Host.SendMessage(GameMessageType.Server_ReceiveVerifyClientRequest, vcr);
        }

        protected override void LoadControls()
        {
            Control = new VerifyClientModuleControl();
            Control.Dock = DockStyle.Fill;
            Control.ExitButtonClicked += new EventHandler(Control_ExitButtonClicked);
            Control.UpdateButtonClicked += new EventHandler(Control_UpdateButtonClicked);
        }

        void Control_UpdateButtonClicked(object sender, EventArgs e)
        {
            Process.Start("http://pizarro-systems.com/downloads");
        }

        void Control_ExitButtonClicked(object sender, EventArgs e)
        {
            Host.Exit();
        }

        protected override void LoadMessageHandlers()
        {
            base.LoadMessageHandlers();

            MessageHandlers.Add(new VerifyClientResponseHandler(this));
        }
    }
}
