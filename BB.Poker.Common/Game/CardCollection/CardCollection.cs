using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class CardCollection : ICollection<Card>
    {
        private List<Card> m_clCardList;
        private bool isFrozen;

        public CardCollection()
        {
            m_clCardList = new List<Card>();
            isFrozen = false;
        }

        public CardCollection(IEnumerable<Card> coll)
        {
            m_clCardList = new List<Card>(coll);
            isFrozen = false;
        }

        public void Freeze()
        {
            isFrozen = true;
        }

        public void Sort()
        {
            m_clCardList.Sort();
        }

        public void AddRange(IEnumerable<Card> coll)
        {
            m_clCardList.AddRange(coll);
        }

        public void Insert(int index, Card card)
        {
            m_clCardList.Insert(index, card);
        }

        public void RemoveRange(int index, int count)
        {
            m_clCardList.RemoveRange(index, count);
        }

        public Card this[int index]
        {
            get
            {
                return m_clCardList[index];
            }

            set
            {
                if (isFrozen == false)
                     m_clCardList[index] = value;

            }
        }

        #region ICollection<Card> Members

        public void Add(Card item)
        {
            if (isFrozen == false)
                m_clCardList.Add(item);
        }

        public void Clear()
        {
            if (isFrozen == false)
                m_clCardList.Clear();
        }

        public bool Contains(Card item)
        {
            return m_clCardList.Contains(item);
        }

        public void CopyTo(Card[] array, int arrayIndex)
        {
            m_clCardList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return m_clCardList.Count; }
        }

        public bool IsReadOnly
        {
            get { return isFrozen; }
        }

        public bool Remove(Card item)
        {
            if (isFrozen == false)
                return m_clCardList.Remove(item);
            else
                return false;
        }

        #endregion

        #region IEnumerable<Card> Members

        public IEnumerator<Card> GetEnumerator()
        {
            return m_clCardList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_clCardList.GetEnumerator();
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Card c in this)
                sb.Append(c.ToString() + ", ");

            return sb.ToString().TrimEnd(new Char[]{',', ' '});
        }

        public static CardCollection operator +(CardCollection coll1, CardCollection coll2)
        {
            CardCollection sumCollection = new CardCollection();

            if (coll1 != null)
            {
                foreach (Card c in coll1)
                    sumCollection.Add(c);
            }

            if (coll2 != null)
            {
                foreach (Card c in coll2)
                    sumCollection.Add(c);
            }

            return sumCollection;
        }

        public static implicit operator Card[](CardCollection coll)
        {
            return coll.ToArray<Card>();
        }
    }
}
