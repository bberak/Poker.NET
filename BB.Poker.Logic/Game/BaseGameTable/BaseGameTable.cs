using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BB.Poker.Common;
using System.Runtime.CompilerServices;

namespace BB.Poker.Logic
{
    public abstract partial class BaseGameTable : IGameTable
    {
        public const int MIN_PLAYERS = 2;     
        public readonly int MAX_PLAYERS;
        public readonly int MAX_DECISION_TIME;

        public double SmallBlind { get; protected set; }
        public double BigBlind { get; protected set; }
        public string TableId { get; protected set; }
        public string Description { get; protected set; }
        public string ServerId { get; protected set; }     
        public bool IsOpen { get; protected set; }
        public bool IsPublic { get; protected set; }
        public bool IsChatEnabled { get; protected set; }
        public double CurrentPotValue { get; protected set; }
        public int DealerChipIndex { get; protected set; }
        public PokerType PokerType { get; protected set; }
        public IPlayerPortal PlayerPortal { get; protected set; }
        public TableState CurrentState { get; protected set; }

        protected DeckFactory DeckFactory;
        protected Deck Deck;
        protected ThreadSafeList<Player> Spectators;
        protected CardCollection TurnRiverOrFlop;
        protected List<IGameRoutine> GameRoutines;
        protected PotManager2 PotManager;
        protected PlayerSlotCollection PlayerSlots;
        protected Thread GameLoopThread;

        public BaseGameTable(double smallBlind, double bigBlind, string tableId, string description, string serverId, PokerType type, 
            int maxPlayers,
            int maxDecisionTime,
            IPlayerPortal playerPortal,
            DeckFactory deckFactory)
        {
            SmallBlind = smallBlind;
            BigBlind = bigBlind;
            TableId = tableId;
            Description = description;
            ServerId = serverId;
            IsOpen = false;
            IsChatEnabled = true;
            CurrentPotValue = 0;
            DealerChipIndex = 0;
            PokerType = type;
            MAX_PLAYERS = maxPlayers;
            MAX_DECISION_TIME = maxDecisionTime;
            CurrentState = TableState.AwaitingPlayers;
            DeckFactory = deckFactory;
            Deck = DeckFactory.GetShuffledDeck();
            Spectators = new ThreadSafeList<Player>();
            TurnRiverOrFlop = new CardCollection();
            GameRoutines = new List<IGameRoutine>();
            PlayerSlots = new PlayerSlotCollection(MAX_PLAYERS);
            PlayerSlots.ImperativelyPlaceDealerButtonAt(0);
            PotManager = new PotManager2();

            PlayerPortal = playerPortal;
            PlayerPortal.JoinTableRequestReceived += new EventHandler<JoinTableEventArgs>(OnJoinTableRequestReceived);
            PlayerPortal.TableLeaveNoticeReceived += new EventHandler<TableLeaveEventArgs>(OnTableLeaveNoticeReceived);

            OnLoad();
        }

        protected abstract void OnLoad();

        protected virtual void StartGameLoop()
        {
            if (GameLoopThread == null || GameLoopThread.IsAlive == false)
            {
                GameLoopThread = new Thread(new ThreadStart(GameLoop));
                GameLoopThread.Name = "BaseGameTable Game Loop Thread - " + TableId;
                GameLoopThread.IsBackground = true;
                GameLoopThread.Start();
            }
        }

        protected virtual void GameLoop()
        {
            while (IsOpen && HasMinimumNumberOfSeatedPlayers())
            {
                foreach (IGameRoutine routine in GameRoutines)
                    routine.Run();
            }

            if (IsOpen == false)
            {
                foreach (Player p in Spectators + PlayerSlots.GetPlayers())
                    PlayerPortal.SendForcedTableDisconnectionNotice(p, "The table you were sitting at has now closed.");

                Spectators.Clear();
                PlayerSlots.RemoveAllPlayers();
            }
            else if (!HasMinimumNumberOfSeatedPlayers())
            {
                //-- Notify any sitting and remaining players of the current state of the table.
                CurrentState = TableState.AwaitingPlayers;
                PlayerPortal.SendTableSummary(Spectators + PlayerSlots.GetPlayers(), GetSummary());
                PlayerPortal.SendPlayerSummaries(Spectators + PlayerSlots.GetPlayers(), PlayerSlots.GetPlayerSummaries().ToArray());
            }
        }

        protected virtual void AddSpectator(JoinTableRequest request, RouteInfo routeInfo)
        {
            JoinTableResponse response = CreateResponse(request);

            if (IsPlayerSittingAtTable(request.PlayerName))
            {
                PlayerSlots.RemovePlayer(request.PlayerName); // Player has stood up..
                PlayerPortal.SendPlayerSummaries(Spectators + PlayerSlots.GetPlayers(), 
                    PlayerSlots.GetPlayerSummaries().ToArray()); // Make all players aware of this..
            }

            if (!IsPlayerSpectating(request.PlayerName))
            {
                response.WasJoinSuccessful = true;
                Player newSpectator = new Player(request.PlayerName, request.AvailableChips, PlayerState.Spectating, routeInfo.GatewayServerId);
                Spectators.Add(newSpectator);

                PlayerPortal.SendJoinTableResponse(newSpectator, response);
                PlayerPortal.SendTableSummary(newSpectator.ToList(), GetSummary());
                PlayerPortal.SendPlayerSummaries(newSpectator.ToList(), PlayerSlots.GetPlayerSummaries().ToArray());
            }
            else
            {
                response.WasJoinSuccessful = false;
                response.ServerMessage = "You are already spectating at this table..";
                PlayerPortal.SendJoinTableResponse(Player.GetTempPlayer(request.PlayerName, routeInfo.GatewayServerId), response);
            }
        }

        protected virtual void AddPlayer(JoinTableRequest request, RouteInfo routeInfo)
        {
            JoinTableResponse response = CreateResponse(request);
            Player candidate = Player.GetTempPlayer(request.PlayerName, routeInfo.GatewayServerId);
            
            if (IsPlayerSittingAtTable(request.PlayerName))
            {
                response.WasJoinSuccessful = false;
                response.ServerMessage = "You are already sitting at this table..";
            }
            else if (request.AvailableChips < BigBlind)
            {
                response.WasJoinSuccessful = false;
                response.ServerMessage = "You do not have enough chips to sit at this table..";
            }
            else if (request.SeatNumber < 0 || request.SeatNumber >= MAX_PLAYERS)
            {
                response.WasJoinSuccessful = false;
                response.ServerMessage = "The seat you chose does not exist..";
            }
            else if (PlayerSlots.IsSeatTaken(request.SeatNumber))
            {
                response.WasJoinSuccessful = false;
                response.ServerMessage = "The seat you selected is already occupied..";
            }
            else if (PlayerSlots.FillSlot(candidate = new Player(request.PlayerName, 
                request.AvailableChips, 
                PlayerState.JustSatDown, 
                routeInfo.GatewayServerId),
                request.SeatNumber))
            {
                response.WasJoinSuccessful = true;
                response.ServerMessage = "You have joined the table. Please wait for the next game to start..";
            }
            else
            {
                response.WasJoinSuccessful = false;
                response.ServerMessage = "The seat you selected has been taken..";
            }

            PlayerPortal.SendJoinTableResponse(candidate, response);

            if (response.WasJoinSuccessful)
            {
                Spectators.RemoveAll(x => x.Name.Equals(request.PlayerName));
                PlayerPortal.SendPlayerSummaries(Spectators + PlayerSlots.GetPlayers(),
                    PlayerSlots.GetPlayerSummaries().ToArray()); // Make all players aware of new player..
            }
        }

        protected virtual void OnJoinTableRequestReceived(object sender, JoinTableEventArgs e)
        {
            if (e.Request.JoinAsSpectator)
                AddSpectator(e.Request, e.RouteInfo);
            else
                AddPlayer(e.Request, e.RouteInfo);
        }

        protected virtual void OnTableLeaveNoticeReceived(object sender, TableLeaveEventArgs e)
        {
            Spectators.RemoveAll(x => x.Name.Equals(e.PlayerName));

            if (PlayerSlots.RemovePlayer(e.PlayerName))
                PlayerPortal.SendPlayerSummaries(Spectators + PlayerSlots.GetPlayers(),
                    PlayerSlots.GetPlayerSummaries().ToArray()); // Make all players aware that a player has left..
        }

        protected virtual JoinTableResponse CreateResponse(JoinTableRequest request)
        {
            JoinTableResponse response = new JoinTableResponse();
            response.ResponseId = request.RequestId;
            response.GameServerId = ServerId;
            response.PlayerName = request.PlayerName;
            response.TableToJoin = request.TableToJoin;

            return response;
        }

        public virtual bool HasMinimumNumberOfSeatedPlayers()
        {
            if (PlayerSlots.GetNumberOfSeatedPlayers() < MIN_PLAYERS)
                return false;
            else
                return true;
        }

        public virtual bool HasMinimumNumberOfActivePlayers()
        {
            if (PlayerSlots.GetNumberOfActivePlayers() < MIN_PLAYERS)
                return false;
            else
                return true;
        }

        public virtual bool IsPlayerSpectating(string playerName)
        {
            Player spectator = Spectators.Find(x => x.Name.Equals(playerName));

            return spectator != null;
        }

        public virtual bool IsPlayerSittingAtTable(string playerName)
        {
            return PlayerSlots.ContainsPlayer(playerName);
        }

        public List<Player> GetAllPlayers()
        {
            return Spectators + PlayerSlots.GetPlayers();
        }

        public void OpenTable()
        {
            IsOpen = true;
            PlayerPortal.Start(this);
        }

        public void CloseTable()
        {
            IsOpen = false;
            PlayerPortal.Shutdown();
        }

        public TableSummary GetSummary()
        {
            TableSummary ts = new TableSummary();
            ts.TableId = TableId;
            ts.DealerButtonPosition = PlayerSlots.GetSlotWithDealerButton().Position;
            ts.PotValue = PotManager.GetTotal();
            ts.State = CurrentState;
            ts.TurnRiverOrFlop = TurnRiverOrFlop;
            ts.SmallBlind = SmallBlind;
            ts.BigBlind = BigBlind;
            ts.PlayerCount = PlayerSlots.GetNumberOfSeatedPlayers();
            ts.MaxPlayers = MAX_PLAYERS;
            ts.MaxDecisionTime = MAX_DECISION_TIME;
            ts.IsChatEnabled = IsChatEnabled;
            ts.Description = Description;

             List<int> availableSeats = new List<int>(MAX_PLAYERS);

             foreach (PlayerSlot ps in PlayerSlots.GetEmptySlots())
                 availableSeats.Add(ps.Position);

            ts.AvailableSeats = availableSeats.ToArray();

            return ts;
        }

        public override bool Equals(object obj)
        {
            if (obj is BaseGameTable)
            {
                BaseGameTable other = (BaseGameTable)obj;

                if (TableId.Equals(other.TableId))
                    return true;
                else
                    return false;
            }

            throw new ArgumentException("Object is not a BaseGameTable"); ;
        }

        public override int GetHashCode()
        {
            return TableId.GetHashCode();
        }
    }
}
