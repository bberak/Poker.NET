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
    public partial class LoginModule : GameClientModule
    {
        public LoginModuleControl Control { get; protected set; }

        public LoginModule(GameClientModuleHost host, string name)
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
        }

        protected override void LoadControls()
        {
            Control = new LoginModuleControl();
            Control.Dock = DockStyle.Fill;
            Control.SignInButtonClicked += new EventHandler<LoginModuleControl.SignInEventArgs>(Control_SignInButtonClicked);
        }

        void Control_SignInButtonClicked(object sender, LoginModuleControl.SignInEventArgs e)
        {
            LoginRequest login = new LoginRequest();
            login.Password = e.Password;
            login.PlayerName = e.Username;
            login.RequestId = Guid.NewGuid().ToString();

            Host.SendMessage(GameMessageType.Server_ReceivePlayerLoginRequest, login);
        }

        protected override void LoadMessageHandlers()
        {
            base.LoadMessageHandlers();

            MessageHandlers.Add(new LoginResponseHandler(this));
        }
    }
}
