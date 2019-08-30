using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class PlayerSlot
    {
        public Player Player { get; protected set; }

        public bool HasPlayer { get { return Player != null; } }

        public int Position { get; protected set; }

        public object DealerButton { get; protected set; }

        public bool HasDealerButton { get { return DealerButton != null; } }

        public PlayerSlot NextSlot { get; protected set; }

        public object SyncLock { get; protected set; }

        public PlayerSlot(int pos, object syncLock)
        {
            Position = pos;

            SyncLock = syncLock;
        }

        public void FillWithPlayer(Player newPlayer)
        {
            lock (SyncLock)
            {
                if (Player != null)
                    throw new InvalidOperationException("The Player property is already filled.");

                Player = newPlayer;
            }
        }

        public void FillNextSlot(PlayerSlot nextSlot)
        {
            NextSlot = nextSlot;
        }

        public void RemovePlayer()
        {
            lock (SyncLock)
            {
                Player = null;
            }
        }

        public void MoveDealerChipTo(PlayerSlot nextSlot)
        {
            object tempChip = DealerButton;

            DealerButton = null;

            nextSlot.ReceiveDealerChip(tempChip);
        }

        public void MoveDealerChipAlong()
        {
            object tempChip = DealerButton;

            DealerButton = null;

            NextSlot.ReceiveDealerChip(tempChip);
        }

        public void ReceiveDealerChip(object dealerChip)
        {
            if (DealerButton != null)
                throw new InvalidOperationException("The DealerChip property is already filled.");

            if (HasPlayer)
                DealerButton = dealerChip;
            else
                NextSlot.ReceiveDealerChip(dealerChip);
        }

        public void ImperativelyReceiveDealerChip(object dealerChip)
        {
            if (DealerButton != null)
                throw new InvalidOperationException("The DealerChip property is already filled.");

            DealerButton = dealerChip;
        }

        public PlayerSlot GetNextSlotWithActivePlayer()
        {
            if (HasPlayer && Player.State == PlayerState.Playing)
                return this;
            else
                return NextSlot.GetNextSlotWithActivePlayer();
        }

        public Player GetNextActivePlayer()
        {
            return GetNextSlotWithActivePlayer().Player;
        }
    }
}
