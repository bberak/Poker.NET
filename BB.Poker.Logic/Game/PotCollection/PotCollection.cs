using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Logic
{
    public class PotCollection : ICollection<Pot>
    {
        private List<Pot> m_plPotList;

        public PotCollection()
        {
            m_plPotList = new List<Pot>();
            m_plPotList.Add(new Pot(PotType.MainPot));
        }

        public Pot MainPot
        {
            get { return m_plPotList[0]; }
        }

        public Pot this[int index]
        {
            get { return m_plPotList[index]; }

            set { m_plPotList[index] = value; }
        }

        public void Reset()
        {
            this.Clear();
            m_plPotList.Add(new Pot(PotType.MainPot));
        }

        public double GetCurrentTotal(PotType type)
        {
            var potList = this.GetSubset(type);

            double total = 0;

            foreach (Pot pot in potList)
                total += pot.GetCurrentTotal();

            return total;
        }

        public double GetCurrentTotal()
        {
            double total = 0;

            foreach (Pot pot in m_plPotList)
                total += pot.GetCurrentTotal();

            return total;
        }

        public double GetPlayerTotal(Player player)
        {
            double total = 0;
            foreach (Pot pot in m_plPotList)
                total += pot.GetPlayerTotal(player);

            return total;
        }

        public double GetPlayerTotal(Player player, PotType type)
        {
            double total = 0;
            foreach (Pot pot in m_plPotList)
            {
                if (pot.Type == type)
                    total += pot.GetPlayerTotal(player);
            }

            return total;
        }

        public int GetCountBy(PotType type)
        {
            return this.GetSubset(type).Count<Pot>();
        }

        public IEnumerable<Pot> GetSubset(PotType type)
        {
            var subset = from p in m_plPotList
                          where p.Type == type
                          select p;

            return subset;
        }

        #region ICollection<Pot> Members

        public void Add(Pot item)
        {
            m_plPotList.Add(item);
        }

        public void Clear()
        {
            m_plPotList.Clear();
        }

        public bool Contains(Pot item)
        {
            return m_plPotList.Contains(item);
        }

        public void CopyTo(Pot[] array, int arrayIndex)
        {
            m_plPotList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return m_plPotList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Pot item)
        {
            return m_plPotList.Remove(item);
        }

        #endregion

        #region IEnumerable<Pot> Members

        public IEnumerator<Pot> GetEnumerator()
        {
            return m_plPotList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_plPotList.GetEnumerator();
        }

        #endregion
    }
}
