using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using BB.Poker.WinFormsClient.Properties;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public class GameClientModuleHost : BaseModuleHost
    {
        public IMetroClientUserInterface UI { get; protected set; }

        public GameClientModuleHost(MetroClientForm ui, Logger log)
            : base(Settings.Default.AppId, Settings.Default.Host, Settings.Default.HostPort, log)
        {
            UI = ui;
            UI.ExitButtonClicked += new EventHandler(UI_ExitButtonClicked);
            UI.SignOutButtonClicked += new EventHandler(UI_SignOutButtonClicked);
            UI.Show();

            FocusOnModule(UI.FlowMenu, "ConnectionModule");

            base.LoginResponseReceived += new GameMessageReceivedEventHandler<LoginResponse>(GameClientModuleHost_LoginResponseReceived);
            base.ForcedPlayerLogoutNoticeReceived += new GameMessageReceivedEventHandler<ForcedPlayerLogoutNotice>(GameClientModuleHost_ForcedPlayerLogoutNoticeReceived);
        }

        protected override void LoadModules()
        {
            Modules.Add(new ConnectionModule(this, "ConnectionModule"));
            Modules.Add(new VerifyClientModule(this, "VerifyClientModule"));
            Modules.Add(new LoginModule(this, "LoginModule"));
            Modules.Add(new LobbyModule(this, "LobbyModule"));
            Modules.Add(new TableModule(this, "TableModule"));

            foreach (BaseModule module in Modules)
                module.ModuleTaskCompleted += new EventHandler(Module_ModuleTaskCompleted);
        }

        protected override void LoadMessageHandlers()
        {
            //-- None at the moment.
        }

        protected override void LoadClientInfo()
        {
            Client = new Client();
            Client.Type = ClientType.Windows;
            Client.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        protected void SignOut()
        {
            UserAccount = null;
            UI.ShowTitleLabel();
            FocusOnModule(UI.FlowMenu, "LoginModule");
        }

        void Module_ModuleTaskCompleted(object sender, EventArgs e)
        {
            BaseModule source = sender as BaseModule;

            switch (source.Name)
            {
                case "ConnectionModule":
                    FocusOnModule(UI.FlowMenu, "VerifyClientModule");
                    break;

                case "VerifyClientModule":
                    FocusOnModule(UI.FlowMenu, "LoginModule");
                    break;

                case "LoginModule":
                    FocusOnModule(UI.FlowMenu, "LobbyModule");
                    break;

                case "LobbyModule":
                    FocusOnModule(UI.FlowMenu, "TableModule");
                    break;

                default:
                    break;
            }
        }

        void GameClientModuleHost_ForcedPlayerLogoutNoticeReceived(object sender, GameMessageReceivedEventArgs<ForcedPlayerLogoutNotice> e)
        {
            MetroMessageBox.Show(e.DataObject.Message);

            SignOut();

            e.WasMessageHandled = true;
        }

        void GameClientModuleHost_LoginResponseReceived(object sender, GameMessageReceivedEventArgs<LoginResponse> e)
        {
            if (e.DataObject.HasLoginSucceeded)
            {
                UI.ShowSignOutButton(e.DataObject.PlayerName);
            }
        }

        void UI_SignOutButtonClicked(object sender, EventArgs e)
        {
            PlayerLogoutNotice logoutNotice = new PlayerLogoutNotice();
            logoutNotice.PlayerName = base.UserAccount.PlayerName;

            SendMessage(GameMessageType.Server_ReceivePlayerLogoutNotice, logoutNotice);

            SignOut();
        }

        void UI_ExitButtonClicked(object sender, EventArgs e)
        {
            Exit();
        }
    }
}
