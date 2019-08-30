using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Common.WinForms;

namespace BB.Poker.Common
{
    public abstract class BaseModuleHost : ClientNetworkManager, IModuleHost
    {
        public Account UserAccount { get; set; } 
        public Client Client { get; protected set; }   
        public Logger Log { get; protected set; }
        
        protected List<BaseModule> Modules;
        
        public BaseModuleHost(string appId, string host, int port, Logger log)
            : base(appId, host, port)
        {
            Log = log;
            Modules = new List<BaseModule>();
        
            LoadClientInfo();
            LoadModules();
        }

        public BaseModuleHost(string appId, string host, int port)
            : this (appId, host, port, new Logger(Path.Combine(Application.StartupPath, appId + "_Log.txt")))
        {
            
        }

        protected abstract void LoadModules();

        protected abstract void LoadClientInfo();

        protected virtual void FocusOnModule(Control window, BaseModule module)
        {
            module.Focus(window);
        }

        protected virtual void FocusOnModule(Control window, string moduleName)
        {
            BaseModule currentlyFocused = Modules.Find(x => x.HasFocus);

            if (currentlyFocused != null)
                currentlyFocused.LostFocus();

            BaseModule module = Modules.Find(x => x.Name.Equals(moduleName));

            if (module == null)
                throw new InvalidOperationException("Module by the name of " + moduleName + " could not be found.");

            FocusOnModule(window, module);
        }

        public virtual void Connect()
        {
            Start();
        }

        public virtual void Exit()
        {
            Shutdown();

            Application.Exit();
        }

        public void SendMessage(GameMessageType opcode, object dataObject)
        {
            OutgoingMessage message = MessageFormatter.CreateOutgoingMessage((int)opcode, 
                Serializer.GetBytes(dataObject));

            SendMessage(message);
        }

        public override void Disconnected(System.Net.IPEndPoint fromEndPoint)
        {
            this.ClientDisconnected.Fire(this, new EventArgs());
        }

        public override void MessageReceived(IncomingMessage msg, int fromConnectToPort)
        {
            //-- Fire generic message-received event.
            ClientReceivedMessage.Fire<MessageReceivedEventArgs>(this, new MessageReceivedEventArgs(msg));

            //-- Fire specfic game events.
            FireSpecificGameEvents(msg);

            //-- Run message handlers belonging to the host.
            foreach (IMessageHandler<GameMessageType> handler in MessageHandlers)
                handler.Run(msg);
  
            //-- Check if any component has actually handled this event.
            if (!msg.WasMessageHandled)
                throw new InvalidOperationException("Message was not handled: " + BaseMessageHandler<GameMessageType>.ReadMessageType(msg));
        }

        private void FireSpecificGameEvents(IncomingMessage msg)
        {
            switch ((GameMessageType)msg.OperationCode)
            {
                case GameMessageType.Client_ReceiveTableListingResponse:
                    TableListingResponseReceived.Fire<TableListingResponse>(this,
                        new GameMessageReceivedEventArgs<TableListingResponse>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceiveJoinTableResponse:
                    JoinTableResponseReceived.Fire<JoinTableResponse>(this,
                        new GameMessageReceivedEventArgs<JoinTableResponse>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceivePlayerSummaries:
                    PlayerSummariesReceived.Fire<PlayerSummary[]>(this,
                        new GameMessageReceivedEventArgs<PlayerSummary[]>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceiveDealerButtonPosition:
                    DealerButtonPositionReceived.Fire<int>(this,
                        new GameMessageReceivedEventArgs<int>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceiveBlindFeeNotice:
                    BlindFeeNoticeReceived.Fire<BlindFeeNotice>(this,
                        new GameMessageReceivedEventArgs<BlindFeeNotice>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceivePlayerCards:
                    PlayerCardsReceived.Fire<Card[]>(this,
                        new GameMessageReceivedEventArgs<Card[]>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceiveTableSummary:
                    TableSummaryReceived.Fire<TableSummary>(this,
                        new GameMessageReceivedEventArgs<TableSummary>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceivePlayerDecisionRequest:
                    PlayerDecisionRequestReceived.Fire<PlayerDecisionRequest>(this,
                        new GameMessageReceivedEventArgs<PlayerDecisionRequest>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceivePlayerDecisionNotification:
                    PlayerDecisionNotificationReceived.Fire<PlayerDecisionNotification>(this,
                        new GameMessageReceivedEventArgs<PlayerDecisionNotification>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceiveTurnRiverOrFlop:
                    TurnRiverOrFlopReceived.Fire<Card[]>(this,
                        new GameMessageReceivedEventArgs<Card[]>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceiveGameOutcome:
                    GameOutcomeReceived.Fire<GameOutcome2>(this,
                        new GameMessageReceivedEventArgs<GameOutcome2>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceiveMakingDecisionNotice:
                    MakingDecisionNoticeReceived.Fire<string>(this,
                        new GameMessageReceivedEventArgs<string>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceiveForcedTableLeaveNotice:
                    ForceTableLeaveNoticeReceived.Fire<ForcedTableLeaveNotice>(this,
                        new GameMessageReceivedEventArgs<ForcedTableLeaveNotice>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceiveForcedPlayerLogoutNotice:
                    ForcedPlayerLogoutNoticeReceived.Fire<ForcedPlayerLogoutNotice>(this,
                        new GameMessageReceivedEventArgs<ForcedPlayerLogoutNotice>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceivePlayerLoginResponse:
                    LoginResponseReceived.Fire<LoginResponse>(this,
                        new GameMessageReceivedEventArgs<LoginResponse>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceiveVerifyClientResponse:
                    VerifyClientResponseReceived.Fire<VerifyClientResponse>(this,
                        new GameMessageReceivedEventArgs<VerifyClientResponse>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceiveTableAnnouncement:
                    TableAnnouncementReceived.Fire<ChatMessage>(this,
                        new GameMessageReceivedEventArgs<ChatMessage>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceivePersonalAnnouncement:
                    PersonalAnnouncementReceived.Fire<ChatMessage>(this,
                        new GameMessageReceivedEventArgs<ChatMessage>(msg, Serializer));
                    break;

                case GameMessageType.Client_ReceivePlayerChatMessage:
                    PlayerChatMessageReceived.Fire<ChatMessage>(this,
                        new GameMessageReceivedEventArgs<ChatMessage>(msg, Serializer));
                    break;

                default:
                    break;
            }
        }

        public override void FailedToConnect(Exception ex)
        {
            this.ClientFailedToConnect.Fire(this, new EventArgs());
        }

        public override void Connected()
        {
            this.ClientConnected.Fire(this, new EventArgs());
        }

        public event EventHandler ClientConnected;

        public event EventHandler ClientDisconnected;

        public event EventHandler ClientFailedToConnect; 

        public event EventHandler<MessageReceivedEventArgs> ClientReceivedMessage;

        public event GameMessageReceivedEventHandler<TableListingResponse> TableListingResponseReceived;

        public event GameMessageReceivedEventHandler<JoinTableResponse> JoinTableResponseReceived;

        public event GameMessageReceivedEventHandler<PlayerSummary[]> PlayerSummariesReceived;

        public event GameMessageReceivedEventHandler<int> DealerButtonPositionReceived;

        public event GameMessageReceivedEventHandler<BlindFeeNotice> BlindFeeNoticeReceived;

        public event GameMessageReceivedEventHandler<Card[]> PlayerCardsReceived;

        public event GameMessageReceivedEventHandler<TableSummary> TableSummaryReceived;

        public event GameMessageReceivedEventHandler<PlayerDecisionRequest> PlayerDecisionRequestReceived;

        public event GameMessageReceivedEventHandler<PlayerDecisionNotification> PlayerDecisionNotificationReceived;

        public event GameMessageReceivedEventHandler<Card[]> TurnRiverOrFlopReceived;

        public event GameMessageReceivedEventHandler<GameOutcome2> GameOutcomeReceived;

        public event GameMessageReceivedEventHandler<string> MakingDecisionNoticeReceived;

        public event GameMessageReceivedEventHandler<ForcedTableLeaveNotice> ForceTableLeaveNoticeReceived;

        public event GameMessageReceivedEventHandler<ForcedPlayerLogoutNotice> ForcedPlayerLogoutNoticeReceived;

        public event GameMessageReceivedEventHandler<LoginResponse> LoginResponseReceived;

        public event GameMessageReceivedEventHandler<VerifyClientResponse> VerifyClientResponseReceived;

        public event GameMessageReceivedEventHandler<ChatMessage> TableAnnouncementReceived;

        public event GameMessageReceivedEventHandler<ChatMessage> PersonalAnnouncementReceived;

        public event GameMessageReceivedEventHandler<ChatMessage> PlayerChatMessageReceived;
    }
}
