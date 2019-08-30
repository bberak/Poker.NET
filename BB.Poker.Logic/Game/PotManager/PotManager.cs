using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class PotManager
    {
        private PotCollection m_pcPotCollection;
        private int m_intPotIndex;

        public PotManager()
        {
            m_pcPotCollection = new PotCollection();
            m_intPotIndex = 0;
        }

        public PotManager(PotCollection pc)
        {
            m_pcPotCollection = pc;
            m_intPotIndex = 0;
        }

        private void reducePotCap(double newCap, int potIndex)
        {
            List<Bet> betsToStayInPot = new List<Bet>();
            List<Bet> betsToShiftToNextPot = new List<Bet>();
            PotType original = m_pcPotCollection[potIndex].Type;

            foreach (Bet b in m_pcPotCollection[potIndex].CurrentBets)
            {
                if (b.Value > newCap)
                {
                    double firstBet = newCap;
                    double secondBet = newCap - firstBet;

                    betsToStayInPot.Add(new Bet(b.Player, firstBet, b.TableState));
                    betsToShiftToNextPot.Add(new Bet(b.Player, secondBet, b.TableState));
                }
                else
                    betsToStayInPot.Add(b);
            }

            m_pcPotCollection[potIndex] = CreatePotFrom(betsToStayInPot, original);

            // Must handle the bets in betsToShiftToNextPot eg, add them to the next pot one by one...
            // have a HandleBet overload that takes the pot to add the bet to...

        }

        private void incrementPotIndex()
        {
            m_intPotIndex++;
        }

        public static Pot CreatePotFrom(List<Bet> bets, PotType pType)
        {
            Pot p = new Pot(pType, bets);

            return p;
        }

        public void AddToPot(Player p, double amount, TableState tState)
        {
            //m_pcPotCollection[potIndex].AddToCurrentPot(new Bet(p, amount, tState));
            if (p.State == PlayerState.AllIn)
            {
                if (this.CurrentPot.Cap == -1)
                    this.CurrentPot.Cap = amount;
                else if (this.CurrentPot.Cap > amount)
                {
                    this.CurrentPot.Cap = amount;
                    //Cap has been reduced, must shift the pots right.
                    this.reducePotCap(amount, m_intPotIndex);
                }
            }

            if (this.CurrentPot.IsCapped && amount > this.CurrentPot.Cap)
            {
                double firstBet = this.CurrentPot.Cap;
                double secondBet = amount - firstBet;

                this.CurrentPot.AddToCurrentPot(new Bet(p, firstBet, tState));
                this.nextPot.AddToCurrentPot(new Bet(p, secondBet, tState));
            }
            else if (this.CurrentPot.IsCapped && amount < this.CurrentPot.Cap)
                throw new InvalidOperationException("The Player can only bet less than the Pot Cap if she/he is AllIn.");
            else
            {
                //The Pot is not capped, bet whatever you wish
                this.CurrentPot.AddToCurrentPot(new Bet(p, amount, tState));
                //this.CurrentPot.AddToCurrentPot(new Bet(p, firstBet, tState));
            }
        }

        public Pot CurrentPot
        {
            get { return m_pcPotCollection[m_intPotIndex]; }
        }

        private Pot nextPot
        {
            get 
            {
                int nextIdx = m_intPotIndex + 1;
                if (nextIdx > (m_pcPotCollection.Count - 1))
                    m_pcPotCollection.Add(new Pot(PotType.SidePot));

                    return m_pcPotCollection[nextIdx]; 
            }
        }

        private Pot previoustPot
        {
            get 
            {
                int prevIdx = m_intPotIndex - 1;
                if (prevIdx < 0)
                    throw new IndexOutOfRangeException("The first Pot in the collection has already been reached. There are no more previous Pots.");
                return m_pcPotCollection[m_intPotIndex - 1]; 
            }
        }

        private void swap(int x, int y)
        {
            Pot temp = m_pcPotCollection[x];
            m_pcPotCollection[x] = m_pcPotCollection[y];
            m_pcPotCollection[y] = temp;
        }
    }
}
