using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class TexasHoldemTable : BaseGameTable
    {
        public TexasHoldemTable(double smallBlind, double bigBlind, int maxPlayers, string tableId, string description, 
            string serverId)
            : this(smallBlind, 
                   bigBlind, 
                   maxPlayers,
                   tableId,
                   description,
                   serverId, 
                   ObjectFactory.CreateIPlayerPortalInstance(),
                   ObjectFactory.CreateDeckFactoryInstance())
        {
        }

        public TexasHoldemTable(double smallBlind, double bigBlind, int maxPlayers, string tableId, string description, 
            string serverId, 
            IPlayerPortal playerPortal,
            DeckFactory deckFactory)
            : base(smallBlind,
                   bigBlind,
                   tableId,
                   description,
                   serverId,
                   PokerType.TexasHoldem,
                   maxPlayers,
                   30000,
                   playerPortal,
                   deckFactory)
        {
        }

        protected override void OnLoad()
        {  
            //-- This is where I should setup the routines and various other components of
            //-- a texas holdem game.
            GameRoutines.Add(new ResetTableRoutine(this));
            GameRoutines.Add(new ShuffleDeckRoutine(this));
            GameRoutines.Add(new MoveDealerButtonRoutine(this));
            GameRoutines.Add(new CollectBlindsRoutine(this));
            GameRoutines.Add(new DealCardsRoutine(this));
            GameRoutines.Add(new BettingRoundRoutine(this, TableState.OpeningBets));
            GameRoutines.Add(new TurnRiverOrFlopRoutine(this, TableState.DealingFlop));
            GameRoutines.Add(new BettingRoundRoutine(this, TableState.FlopBets));
            GameRoutines.Add(new TurnRiverOrFlopRoutine(this, TableState.DealingTurn));
            GameRoutines.Add(new BettingRoundRoutine(this, TableState.TurnBets));
            GameRoutines.Add(new TurnRiverOrFlopRoutine(this, TableState.DealingRiver));
            GameRoutines.Add(new BettingRoundRoutine(this, TableState.RiverBets));
            GameRoutines.Add(new EvaluationRoutine(this));
            GameRoutines.Add(new ChillRoutine(this, 10000));
            GameRoutines.Add(new FilterPlayersRoutine(this));
            GameRoutines.Add(new ChillRoutine(this, 5000));
        }
    }
}
