using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public interface IPlayerPortal
    {
        void Start(BaseGameTable table);

        void Reset();

        void Shutdown();

        void ReadIncomingQueue();

        void SendDealerButtonMoved(List<Player> recipients, int index);

        void SendPostingBlinds(List<Player> recipients, BlindFeeNotice bfn);

        void SendPlayerHands(List<Player> recipients);

        void SendPlayerSummaries(List<Player> recipients, PlayerSummary[] summaries);

        void SendTableSummary(List<Player> recipients, TableSummary tsummary);

        PlayerDecisionResponse GetPlayerDecision(Player player, double minimumBet, DecisionType[] availableOptions);

        void SendPlayerMakingDecision(List<Player> recipients, string decisionMaker);

        void SendPlayerDecisionNotification(List<Player> recipients, PlayerDecisionNotification pdn);

        void SendTurnRiverOrFlop(List<Player> recipients, CardCollection cards);

        void SendGameOutcome(List<Player> recipients, GameOutcome2 go2);

        void SendJoinTableResponse(Player recipient, JoinTableResponse jtres);

        void SendForcedTableDisconnectionNotice(Player recipient, string reason);

        void SendPersonalAnnouncement(Player recipient, string message);

        void SendTableAnnouncement(List<Player> recipients, string message);

        void AddToOutgoingMessageQueue(GameMessageType opcode, object dataObject, List<Player> recipients);

        void RemovePlayer(string playerName);

        IMessageQueue<IncomingGameMessageQueueItem> IncomingQueue { get; }

        IMessageQueue<OutgoingGameMessageQueueItem> OutgoingQueue { get; }

        BaseGameTable Table { get; }

        event EventHandler<TableLeaveEventArgs> TableLeaveNoticeReceived;

        event EventHandler<JoinTableEventArgs> JoinTableRequestReceived;
    }
}
