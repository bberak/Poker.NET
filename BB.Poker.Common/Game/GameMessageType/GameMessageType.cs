using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public enum GameMessageType
    {
        Server_ReceiveTableListingRequest,
        Server_ReceiveJoinTableRequest,
        Server_ReceivePlayerDecision,
        Server_ReceiveTableLeaveNotice,
        Server_ReceivePlayerLogoutNotice,
        Server_ReceivePlayerLoginRequest,
        Server_ReceiveVerifyClientRequest, 
        Server_ReceiveChatMessage,
        Client_ReceiveTableListingResponse,   
        Client_ReceiveJoinTableResponse, 
        Client_ReceivePlayerSummaries, 
        Client_ReceiveDealerButtonPosition, 
        Client_ReceiveBlindFeeNotice, 
        Client_ReceivePlayerCards, 
        Client_ReceiveTableSummary,
        Client_ReceivePlayerDecisionRequest,  
        Client_ReceivePlayerDecisionNotification, 
        Client_ReceiveTurnRiverOrFlop, 
        Client_ReceiveGameOutcome, 
        Client_ReceiveMakingDecisionNotice, 
        Client_ReceiveForcedTableLeaveNotice, 
        Client_ReceiveForcedPlayerLogoutNotice,        
        Client_ReceivePlayerLoginResponse,  
        Client_ReceiveVerifyClientResponse, 
        Client_ReceiveTableAnnouncement,
        Client_ReceivePersonalAnnouncement,
        Client_ReceivePlayerChatMessage
    }
}