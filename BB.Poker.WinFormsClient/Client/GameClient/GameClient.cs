using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Lidgren.Network;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public class GameClient : BaseNetworkManager<GameMessageType>, IClientNetworkManager
    {
        public IUserInterface UI { get; protected set; }
        public string ExpectedResponseId { get; protected set; }
        public string ExpectedTableListingResponseId { get; protected set; }
        public IClientNetworkInterface NetworkInterface { get; protected set; }
        public List<TableSummary> TableList { get; protected set; }
        public ThreadController GameFlow { get; protected set; }
        public ClientLogicUnit ClientLogicUnit { get; protected set; }

        public static Hand PlayerHand { get; protected set; }
        public static TableSummary CurrentTable { get; set; }
        public static PlayerSummary Player { get; set; }

        public GameClient(string appId, string host, int hostPort, ISerialize serializer, IUserInterface iUI) : base (appId, serializer)
        {
            UI = iUI;
            UI.UserExit += new EventHandler(ui_UserExit);
            UI.JoinTable += new JoinTableEventHandler(ui_JoinTable);
            UI.UserLoginLogout += new EventHandler(ui_UserLoginLogout);
            UI.RefreshTableListing += new EventHandler(ui_RefreshTableListing);
            UI.LeaveTable += new EventHandler(ui_LeaveTable);

            PlayerHand = Hand.GetUnassignedPlayerHand();

            NetworkInterface = new ClientNetworkInterface(appId, host, hostPort, this);

            GameFlow = new ThreadController(false);

            ClientLogicUnit = new ClientLogicUnit();
            ClientLogicUnit.GameClient = this;

            TableList = new List<TableSummary>();
        }

        protected override void LoadMessageHandlers()
        {
            //MessageHandlers.Add(..);
        }

        private void ui_RefreshTableListing(object sender, EventArgs e)
        {
            if (NetworkInterface.IsConnected)
            {
                TableList.Clear();
                UI.Display(TableList);
                SendTableListingRequest();
            }
            else
            {
                UI.ShowMessageBox("Your client has not connected to the server. A retry will be attempted.");
                NetworkInterface.Start();
            }
        }

        private void ui_UserLoginLogout(object sender, EventArgs e)
        {
            if (Player != null)
            {
                PlayerLogoutNotice pln = new PlayerLogoutNotice();
                pln.PlayerName = Player.Name;

                SendMessage((int)GameMessageType.Server_ReceivePlayerLogoutNotice, pln);

                Player = null;

                UI.SetLoginButtonText("Login");

                UI.SetFormText("Poker Reloaded Client");

                UI.ShowTab(FormsUserInterface.TABLE_LIST_TAB_INDEX);

                TableList.Clear();
                UI.Display(TableList);
            }
            else
            {
                login();
            }        
        }

        private void ui_JoinTable(object sender, JoinTableEventArgs e)
        {
            if (Player == null || string.IsNullOrEmpty(Player.Name))
            {
                login();
            }

            if (Player != null && string.IsNullOrEmpty(Player.Name) == false)
            {
                if (CurrentTable == null || CurrentTable.TableId.Equals(e.TargetTable.TableId) == false)
                    sendJoinTableRequest(e.TargetTable, e.AtPosition);
            }
            else
                UI.ShowMessageBox("You must provide a valid login before joining a table");
        }

        private void ui_UserExit(object sender, EventArgs e)
        {
            Shutdown();
        }

        private void ui_LeaveTable(object sender, EventArgs e)
        {
            sendTableLeaveNotice();
            UI.ShowTab(FormsUserInterface.TABLE_LIST_TAB_INDEX);
        }

        public override void Start()
        {
            NetworkInterface.Start();
            UI.Show();
            UI.ShowGreeting();
        }

        public override void Shutdown()
        {
            Shutdown(AppId + " Client is shutting down. Bye!");
            UI.Hide();
            Application.Exit();
        }

        public void Shutdown(string message)
        {
            NetworkInterface.Shutdown();
        }

        private string sendLoginRequest(Account user)
        {
            if (user == null)
                return string.Empty;

            ExpectedResponseId = Guid.NewGuid().ToString("N");

            LoginRequest login = new LoginRequest();
            login.Password = "123";
            login.PlayerName = user.PlayerName;
            login.RequestId = ExpectedResponseId;

            SendMessage((int)GameMessageType.Server_ReceivePlayerLoginRequest, login);

            return ExpectedResponseId;
        }

        public void SendTableListingRequest()
        {
            if (Player == null || string.IsNullOrEmpty(Player.Name))
            {
                login();
                return;
            }

            ExpectedTableListingResponseId = Guid.NewGuid().ToString();

            TableListingRequest tlr = new TableListingRequest();
            tlr.PlayerName = Player.Name;
            tlr.RequestId = ExpectedTableListingResponseId;

            SendMessage((int)GameMessageType.Server_ReceiveTableListingRequest, tlr);
        }

        private void sendJoinTableRequest(TableSummary targetTable, int position)
        {
            ExpectedResponseId = Guid.NewGuid().ToString();

            JoinTableRequest jtr = new JoinTableRequest();
            jtr.AvailableChips = Player.Chips;
            jtr.PlayerName = Player.Name;
            jtr.RequestId = ExpectedResponseId;
            jtr.SeatNumber = position;
            jtr.TableToJoin = targetTable.TableId;

            SendMessage((int)GameMessageType.Server_ReceiveJoinTableRequest, jtr);
        }

        private void sendTableLeaveNotice()
        {
            if (Player != null && CurrentTable != null)
            {
                TableLeaveNotice tln = new TableLeaveNotice();
                tln.PlayerName = Player.Name;

                SendMessage((int)GameMessageType.Server_ReceiveTableLeaveNotice, tln);
            }

            CurrentTable = null;  
        }

        private void login()
        {
            if (NetworkInterface.IsConnected == false)
            {
                UI.ShowMessageBox("Your client has not connected to the server. A retry will be attempted.");
                NetworkInterface.Start();
            }

            Account user = UI.GetUserAccount();
            if (user == null || string.IsNullOrEmpty(user.PlayerName))
            {
                UI.ShowMessageBox("You must fill in all details before logging in.");
                return;
            }

            sendLoginRequest(user);
        }

        public void SendMessage(int opcode, object dataObject)
        {
            OutgoingMessage com = MessageFormatter.CreateOutgoingMessage(opcode, 
                Serializer.GetBytes(dataObject));

            NetworkInterface.SendMessage(com);
        }

        public void Disconnected(System.Net.IPEndPoint fromEndPoint)
        {
            UI.ShowMessageBox("Your client has been disconnected from the server.");

            //-- Release player credentials and table details..
            CurrentTable = null;
            Player = null;
            if (PlayerHand != null)
                PlayerHand.Clear();

            TableList.Clear();
            UI.Display(TableList);

            UI.SetLoginButtonText("Login");
            UI.SetFormText("Poker Reloaded Client");
            UI.ShowTab(FormsUserInterface.TABLE_LIST_TAB_INDEX);
        }

        public void MessageReceived(IncomingMessage msg, int fromConnectToPort)
        {
            ClientLogicUnit.ProcessIncomingMessage(msg);
        }

        public void FailedToConnect(Exception ex)
        {
            UI.ShowMessageBox("Your client failed to connect to the server. Please check your network setup.");
        }

        public void Connected()
        {
            login();
        }
    }
}
