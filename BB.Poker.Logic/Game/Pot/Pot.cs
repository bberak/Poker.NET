using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BB.Poker.Logic
{
    public class Pot
    {
        private List<Bet> m_blBetList;
        private PotType m_ptType;
        private double m_dblCap;
        private bool m_bCapped;

        public Pot() : this(PotType.MainPot, new List<Bet>())
        {
        }

        public Pot(PotType type) : this(type, new List<Bet>())
        {
        }

        public Pot(PotType type, List<Bet> bets)
        {
            m_blBetList = bets;
            m_ptType = type;
            m_dblCap = -1;
            m_bCapped = false;
        }

        public void Reset()
        {
            m_blBetList.Clear();
        }

        public void AddToCurrentPot(Bet betToAdd)
        {
            if (betToAdd != null && betToAdd.Player != null && betToAdd.Value > 0)
                m_blBetList.Add(betToAdd);
            else
                throw new InvalidOperationException("A bet must be valid before it is added to the pot.");
        }

        public double GetCurrentTotal()
        {
            double value = 0;

            foreach (Bet bet in m_blBetList)
                value += bet.Value;

            return value;
        }

        public ReadOnlyCollection<Bet> CurrentBets
        {
            get { return m_blBetList.AsReadOnly(); }
        }

        public double GetPlayerTotal(Player p)
        {
            var playerBets = from b in m_blBetList
                             where b.Player.Name == p.Name
                             select b;

            double total = 0;
            foreach (Bet bet in playerBets)
                total += bet.Value;

            return total;
        }

        public double Cap
        {
            get { return m_dblCap; }
            set { m_dblCap = value; m_bCapped = true; }
        }

        public PotType Type
        {
            get { return m_ptType; }
        }

        public bool IsCapped
        {
            get { return m_bCapped; }
        }

        public override string ToString()
        {
            return this.GetCurrentTotal().ToString();
        }
    }
}
