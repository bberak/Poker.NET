using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class PlayerSlotCollection
    {
        public object SyncLock { get { return SlotList.SyncLock; } }

        ThreadSafeList<PlayerSlot> SlotList;

        public PlayerSlotCollection(int numSlots)
        {
            SlotList = new ThreadSafeList<PlayerSlot>(numSlots);

            PlayerSlot previous = null;
            PlayerSlot current = null;
            for (int i = 0; i < numSlots; i++)
            {
                current = new PlayerSlot(i, SyncLock);

                if (previous != null)
                    previous.FillNextSlot(current);

                SlotList.Add(current);

                previous = current;
            }

            //-- Link the last slot to the first.
            current.FillNextSlot(SlotList[0]);
        }

        public void PlaceDealerButtonAt(int pos)
        {
            PlayerSlot slot = SlotList[pos];

            slot.ReceiveDealerChip(new object());
        }

        public void ImperativelyPlaceDealerButtonAt(int pos)
        {
            PlayerSlot slot = SlotList[pos];

            slot.ImperativelyReceiveDealerChip(new object());
        }

        public bool IsSeatTaken(int pos)
        {
            lock (SyncLock)
            {
                return SlotList[pos].HasPlayer;
            }
        }

        public bool FillSlot(Player newPlayer, int pos)
        {
            lock (SyncLock)
            {
                PlayerSlot slot = SlotList[pos];

                if (slot.HasPlayer)
                    return false;

                slot.FillWithPlayer(newPlayer);

                return true;
            }
        }

        public void RemoveAllPlayers()
        {
            lock (SyncLock) // Don't think this lock is required, I think the enumerator already does this.
            {
                foreach (PlayerSlot slot in SlotList)
                    slot.RemovePlayer();
            }
        }

        public bool RemovePlayer(string playerName)
        {
            lock (SyncLock)
            {
                PlayerSlot slot = GetSlotContainingPlayer(playerName);

                if (slot != null)
                {
                    slot.RemovePlayer();
                    return true;
                }

                return false;
            }
        }

        public void MoveDealerButton()
        {
            if (GetNumberOfSeatedPlayers() < 2)
                throw new InvalidOperationException("There are not enough seated players to continue. The round should not continue.");

            PlayerSlot slotWithDealerButton = SlotList.Find(x => x.HasDealerButton);

            if (slotWithDealerButton == null)
                throw new InvalidOperationException("The Dealer Chip could not be found. Have you assigned it to a Player Slot?");

            slotWithDealerButton.MoveDealerChipAlong();
        }

        public int GetDealerButtonPosition()
        {
            return GetSlotWithDealerButton().Position;
        }

        public PlayerSlot GetSlotWithDealerButton()
        {
            PlayerSlot slotWithDealerButton = SlotList.Find(x => x.HasDealerButton);

            if (slotWithDealerButton == null)
                throw new InvalidOperationException("The Dealer Chip could not be found. Have you assigned it to a Player Slot?");

            return slotWithDealerButton;
        }

        public PlayerSlot GetSlotContainingPlayer(string playerName)
        {
            return SlotList.Find(x => x.HasPlayer && x.Player.Name.Equals(playerName));
        }

        public List<PlayerSlot> GetEmptySlots()
        {
            return SlotList.FindAll(x => x.HasPlayer == false);
        }

        public void ClearPlayerCards()
        {
            foreach (PlayerSlot ps in SlotList)
            {
                if (ps.HasPlayer)
                    ps.Player.Cards.Clear();
            }
        }

        public void ResetPlayerStates(PlayerState newState)
        {
            foreach (PlayerSlot ps in SlotList)
            {
                if (ps.HasPlayer)
                    ps.Player.State = newState;
            }
        }

        public int GetNumberOfSeatedPlayers()
        {
            return SlotList.Count<PlayerSlot>(x => x.HasPlayer);
        }

        public int GetNumberOfActivePlayers()
        {
            return SlotList.Count<PlayerSlot>(x => x.HasPlayer && x.Player.State == PlayerState.Playing);
        }

        public List<Player> GetActivePlayers()
        {
            return GetPlayers(PlayerState.Playing);
        }

        public List<Player> GetPlayers()
        {
            var players = from slot in SlotList
                       where slot.HasPlayer == true
                       select slot.Player;

            if (players == null)
                return new List<Player>();
            else
                return players.ToList<Player>();
        }

        public List<Player> GetPlayers(PlayerState filter)
        {
            var players = from slot in SlotList
                          where slot.HasPlayer == true && (filter & slot.Player.State) == slot.Player.State
                          select slot.Player;

            if (players == null)
                return new List<Player>();
            else
                return players.ToList<Player>();
        }

        public bool ContainsPlayer(string playerName)
        {
            lock (SyncLock)
            {
                Player sittingPlayer = GetPlayers().Find(x => x.Name.Equals(playerName));

                return sittingPlayer != null;
            }
        }

        public int GetSlotPosition(string playerName)
        {
            PlayerSlot slot = SlotList.Find(x => x.HasPlayer && x.Player.Name.Equals(playerName));

            if (slot == null)
                throw new InvalidOperationException("Player could not be found in the slot list.");
            else
                return slot.Position;
        }

        public List<PlayerSummary> GetPlayerSummaries()
        {
            var summaries = from slot in SlotList
                          where slot.HasPlayer == true
                          select slot.Player.GetSummary(slot.Position);

            if (summaries == null)
                return new List<PlayerSummary>();
            else
                return summaries.ToList<PlayerSummary>();
        }

        public IEnumerator<PlayerSlot> GetEnumerator()
        {
            return SlotList.GetEnumerator();
        }
    }
}
