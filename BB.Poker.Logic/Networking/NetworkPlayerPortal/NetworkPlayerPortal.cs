using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class NetworkPlayerPortal : IPlayerPortal
    {
        private IMessageQueue<OutgoingGameMessageQueueItem> m_qOutgoingQueue;
        private IMessageQueue<IncomingGameMessageQueueItem> m_qIncomingQueue;
        private bool m_bIsRunning;
        private ISerialize m_slrSerializer;
        private ThreadController m_tcGameFlow;
        private Dictionary<string, object> m_dicStorage;
        private BaseGameTable m_gtTable;

        public NetworkPlayerPortal(IMessageQueue<IncomingGameMessageQueueItem> inQ, IMessageQueue<OutgoingGameMessageQueueItem> outQ, ISerialize iSerializer)
        {
            m_qIncomingQueue = inQ;
            m_qOutgoingQueue = outQ;
            m_bIsRunning = false;
            m_slrSerializer = iSerializer;
            m_tcGameFlow = new ThreadController(false);
            m_dicStorage = new Dictionary<string, object>();
        }

        public void ReadIncomingQueue()
        {
            if (m_bIsRunning)
            {
                IncomingGameMessageQueueItem item = (IncomingGameMessageQueueItem)m_qIncomingQueue.Read();
                if (item != null)
                {
                    switch (item.OperationCode)
                    {
                        case GameMessageType.Server_ReceiveChatMessage:
                            ForwardChatMessage(m_slrSerializer.GetObject<ChatMessage>(item.Data));
                            break;

                        case GameMessageType.Server_ReceivePlayerDecision:
                            PlayerDecisionResponse pd = m_slrSerializer.GetObject<PlayerDecisionResponse>(item.Data);
                            m_dicStorage.Add(pd.ResponseId, pd);
                            break;

                        case GameMessageType.Server_ReceiveJoinTableRequest:
                            JoinTableRequest jtr = m_slrSerializer.GetObject<JoinTableRequest>(item.Data);
                            OnJoinTableRequestReceived(jtr, item.RouteInfo);
                            break;

                        case GameMessageType.Server_ReceiveTableLeaveNotice:
                        case GameMessageType.Server_ReceivePlayerLogoutNotice:   
                            BaseClientMessageObject baseMessage = m_slrSerializer.GetObject<BaseClientMessageObject>(item.Data);
                            OnTableLeaveNoticeReceived(baseMessage.PlayerName);
                            break;
                            
                        default:
                            throw new InvalidOperationException("GameMessageType of " + item.OperationCode + " was not handled."); 
                    }  
                }   
            }
        }

        protected void OnJoinTableRequestReceived(JoinTableRequest jtr, RouteInfo routeInfo)
        {
            var myEvent = JoinTableRequestReceived;

            if (myEvent != null)
            {
                myEvent(this, new JoinTableEventArgs(jtr, routeInfo));
            }
        }

        protected void OnTableLeaveNoticeReceived(string playerName)
        {
            var myEvent = TableLeaveNoticeReceived;

            if (myEvent != null)
            {
                myEvent(this, new TableLeaveEventArgs(playerName));
            }
        }

        protected void ForwardChatMessage(ChatMessage message)
        {
            if (Table.IsChatEnabled)
            {
                List<Player> recipients = Table.GetAllPlayers();
                recipients.Remove(Player.GetTempPlayer(message.PlayerName));

                AddToOutgoingMessageQueue(GameMessageType.Client_ReceivePlayerChatMessage, message, recipients);
            }
        }

        #region IPlayerPortal Members

        public void Start(BaseGameTable table)
        {
            m_gtTable = table;
            m_bIsRunning = true;
            m_dicStorage.Clear();
        }

        public void Reset()
        {
            //-- I believe that the dictionary is thread-safe, hence does not require a lock.
            m_dicStorage.Clear();
        }

        public void Shutdown()
        {
            m_bIsRunning = false;
        }

        public void SendDealerButtonMoved(List<Player> recipients, int newPos)
        {
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceiveDealerButtonPosition, newPos, recipients);
        }

        public void SendPostingBlinds(List<Player> recipients, BlindFeeNotice bfn)
        {
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceiveBlindFeeNotice, bfn, recipients);
        }

        public void SendPlayerHands(List<Player> recipients)
        {
            foreach (Player p in recipients)
            {
                Card[] cards = p.Cards;
                AddToOutgoingMessageQueue(GameMessageType.Client_ReceivePlayerCards, cards, p.ToList());
            }
        }

        public void SendPlayerSummaries(List<Player> recipients, PlayerSummary[] summaries)
        {
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceivePlayerSummaries, summaries, recipients);
        }

        public void SendTableSummary(List<Player> recipients, TableSummary tsummary)
        {
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceiveTableSummary, tsummary, recipients);
        }

        public PlayerDecisionResponse GetPlayerDecision(Player player, double minimumBet, DecisionType[] availableOptions)
        {
            PlayerDecisionResponse pd = new PlayerDecisionResponse();
            pd.Type = DecisionType.TimeOutAndFold;

            PlayerDecisionRequest pdr = new PlayerDecisionRequest();
            pdr.RequestId = Guid.NewGuid().ToString();
            pdr.MinimumBet = minimumBet;
            pdr.AvailableOptions = availableOptions;

            AddToOutgoingMessageQueue(GameMessageType.Client_ReceivePlayerDecisionRequest, pdr, player.ToList());

            int waitingFor = 0;
            while (waitingFor < Table.MAX_DECISION_TIME)
            {
                if (m_dicStorage.ContainsKey(pdr.RequestId))
                {
                    pd = (PlayerDecisionResponse)m_dicStorage[pdr.RequestId];
                    break;
                }

                //-- Perhaps the player has disconnected from the table
                if (Table.IsPlayerSittingAtTable(player.Name) == false)
                {
                    pd.Type = DecisionType.DisconnectAndFold;
                    break;
                }

                m_tcGameFlow.WaitHereFor(100);
                waitingFor += 100;
            }

            return pd;
        }

        public void SendPlayerMakingDecision(List<Player> recipients, string decisionMaker)
        {
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceiveMakingDecisionNotice, decisionMaker, recipients);
        }

        public void SendPlayerDecisionNotification(List<Player> recipients, PlayerDecisionNotification pdn)
        {
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceivePlayerDecisionNotification, pdn, recipients);
        }

        public void SendTurnRiverOrFlop(List<Player> recipients, CardCollection cards)
        {
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceiveTurnRiverOrFlop, cards.ToArray(), recipients);
        }

        public void SendGameOutcome(List<Player> recipients, GameOutcome2 go2)
        {
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceiveGameOutcome, go2, recipients);
        }

        public void SendJoinTableResponse(Player recipient, JoinTableResponse jtres)
        {
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceiveJoinTableResponse, jtres, recipient.ToList());
        }

        public void SendForcedTableDisconnectionNotice(Player recipient, string reason)
        {
            ForcedTableLeaveNotice fln = new ForcedTableLeaveNotice();
            fln.TableId = Table.TableId;
            fln.Message = reason;
            fln.PlayerName = recipient.Name;
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceiveForcedTableLeaveNotice, fln, recipient.ToList());
        }

        public void SendPersonalAnnouncement(Player recipient, string message)
        {
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceivePersonalAnnouncement, message, recipient.ToList());
        }

        public void SendTableAnnouncement(List<Player> recipients, string message)
        {
            AddToOutgoingMessageQueue(GameMessageType.Client_ReceiveTableAnnouncement, message, recipients);
        }

        public void AddToOutgoingMessageQueue(GameMessageType opcode, object dataObject, List<Player> recipients)
        {
            if (recipients.Count > 0)
            {
                OutgoingGameMessageQueueItem item = new OutgoingGameMessageQueueItem();
                item.OperationCode = opcode;
                item.Data = m_slrSerializer.GetBytes(dataObject);
                //-- Disconnected list doesn't exist anymore
                //-- Filter from the disconnected list
                //item.Recipients = recipients - Table.DisconnectedPlayers;

                item.Recipients = recipients;
                m_qOutgoingQueue.Add(item);
            }
        }

        public void RemovePlayer(string playerName)
        {
            OnTableLeaveNoticeReceived(playerName);
        }

        public IMessageQueue<IncomingGameMessageQueueItem> IncomingQueue
        {
            get { return m_qIncomingQueue; }
        }

        public IMessageQueue<OutgoingGameMessageQueueItem> OutgoingQueue
        {
            get { return m_qOutgoingQueue; }
        }

        public BaseGameTable Table
        {
            get
            {
                if (m_gtTable == null)
                    throw new InvalidOperationException("The Table property has not been set. Have you called the Start() method?");
                else
                    return m_gtTable;
            }
        }

        public event EventHandler<TableLeaveEventArgs> TableLeaveNoticeReceived;

        public event EventHandler<JoinTableEventArgs> JoinTableRequestReceived;

        #endregion
    }
}
