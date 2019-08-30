using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BB.Poker.Common;
using BB.Common.WinForms;

namespace BB.Poker.WinFormsClient
{
    public class ConnectionModule : GameClientModule
    {
        private ConnectionModuleControl Control;

        public ConnectionModule(GameClientModuleHost host, string name) 
            : base(host, name)
        {
        }

        void Control_RetryButtonClicked(object sender, EventArgs e)
        {
            Host.Connect();
            Control.ChangeStatus("Connecting..");
            Control.SetProgressStyle(BB.Common.WinForms.MetroProgressBarStyle.Marquee);
            Control.HideButtons();
        }

        void Control_ExitButtonClicked(object sender, EventArgs e)
        {
            Host.Exit();
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

            Host.Connect();        
        }

        protected override void OnClientFailedToConnect(EventArgs e)
        {
            Control.ChangeStatus("Could not connect to the network..");
            Control.UpdateProgressBar(0);
            Control.ShowButtons();
        }

        protected override void OnClientConnected(EventArgs e)
        {
            Control.ChangeStatus("Connected..");
            Control.UpdateProgressBar(100);
            Thread.Sleep(1000); // So user can see what's going on..
            

            OnModuleTaskCompleted(e);
        }

        protected override void LoadControls()
        {
            Control = new ConnectionModuleControl();
            Control.Dock = DockStyle.Fill;
            Control.ExitButtonClicked += new EventHandler(Control_ExitButtonClicked);
            Control.RetryButtonClicked += new EventHandler(Control_RetryButtonClicked);
        }
    }
}
