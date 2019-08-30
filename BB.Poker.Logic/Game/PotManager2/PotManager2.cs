using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class PotManager2
    {
        private Dictionary<string, double> m_dicPlayerBets;

        public PotManager2()
        {
            m_dicPlayerBets = new Dictionary<string, double>();
        }

        public void AddToPot(Player player, double amount)
        {
            string pName = player.Name;

            if (m_dicPlayerBets.ContainsKey(pName))
                m_dicPlayerBets[pName] += amount;
            else
                m_dicPlayerBets.Add(pName, amount);
        }

        public double GetTotal()
        {
            double total = 0;

            foreach (double amount in m_dicPlayerBets.Values)
                total += amount;

            return total;
        }

        public double GetPlayerTotal(Player p)
        {
            double amount = 0;
            string name = p.Name;

            if (m_dicPlayerBets.ContainsKey(name))
            {
                amount = m_dicPlayerBets[name];

                if (amount <= 0)
                    m_dicPlayerBets.Remove(name);
            }

            return amount;
        }

        public double GetHighestPlayerTotal()
        {
            double amount = 0;

            foreach (double value in m_dicPlayerBets.Values)
            {
                if (value > amount)
                    amount = value;
            }

            return amount;
        }

        public double GetAmountPlayerRequiresToCall(Player p)
        {
            return this.GetHighestPlayerTotal() - this.GetPlayerTotal(p);
        }

        public void Reset()
        {
            m_dicPlayerBets.Clear();
        }

        public bool HaveAllPlayersBetTheSameAmount(List<Player> players)
        {
            double highestbet = GetHighestPlayerTotal();

            foreach (var player in players)
            {
                if (GetPlayerTotal(player) < highestbet)
                {
                    return false;
                }
            }

            return true;
        }

        public void AwardPot(List<Player> winners, List<Player> losers, List<Player> all)
        {
            this.splitPotBetween(winners);
            this.splitPotBetween(losers);
            this.splitPotBetween(all);
        }

        private void splitPotBetween(List<Player> players)
        {
            List<Player> validPlayers = new List<Player>();

            foreach (Player player in players)
            {
                if (this.GetPlayerTotal(player) > 0)
                    validPlayers.Add(player);
            }

            if (validPlayers.Count <= 0)
                return;

            double[] bets = this.getRemainingBets();

            if (bets.Length <= 0)
                return;

            double lowest = bets[0];
            double pool = lowest * m_dicPlayerBets.Keys.Count;
            double split = pool / validPlayers.Count;

            this.removeFromEachKey(lowest);

            foreach (Player player in validPlayers)
                player.PocketWinnings(split);

            this.splitPotBetween(validPlayers);
        }

        private void removeFromEachKey(double amount)
        {
            Dictionary<string, double> changes = new Dictionary<string, double>();

            foreach (string playerName in m_dicPlayerBets.Keys)
            {
                double value = m_dicPlayerBets[playerName];
                double leftover = value - amount;
                changes.Add(playerName, leftover);
            }

            foreach (string key in changes.Keys)
            {
                double newValue = changes[key];
                if (newValue > 0)
                    m_dicPlayerBets[key] = newValue;
                else
                    m_dicPlayerBets.Remove(key);
            }

        }

        private double[] getRemainingBets()
        {
            double[] totals = new double[m_dicPlayerBets.Count];

            int index = 0;
            foreach (double value in m_dicPlayerBets.Values)
            {
                totals[index] = value;
                index++;
            }

            Array.Sort(totals);

            return totals;
        }
    }
}
