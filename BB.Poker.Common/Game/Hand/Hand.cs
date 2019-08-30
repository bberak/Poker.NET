using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BB.Poker.Common
{
    [JsonConverter(typeof(JsonHandConverter))]
    [Serializable]
    public class Hand : CardCollection
    {
        private Combination m_cmbBestCombination;
        private Card m_cdHighCard;

        public Hand()
        {
            m_cdHighCard = new Card(Rank.Unassigned, Suit.Unassigned);
            m_cmbBestCombination = Combination.Unassigned;
        }
        
        public Hand(CardCollection cards, Combination HandType):base(cards)
        {
            if (cards == null || cards.Count <= 0)
                throw new InvalidOperationException("You cannot add an empty collection of cards to a hand.");
            m_cmbBestCombination = HandType;
            base.Sort();
            m_cdHighCard = base[base.Count - 1];    
        }

        public Combination BestCombination
        {
            get { return m_cmbBestCombination; }
            set { m_cmbBestCombination = value; }
        }

        public Card HighCard
        {
            get { return m_cdHighCard; }
            set { m_cdHighCard = value; }
        }

        public static Hand GetUnassignedPlayerHand()
        {
            Hand emptyHand = new Hand();
            emptyHand.Add(Card.GetUnnassignedCard());
            emptyHand.Add(Card.GetUnnassignedCard());
            emptyHand.HighCard = Card.GetUnnassignedCard();
            emptyHand.BestCombination = Combination.Unassigned;
            return emptyHand;
        }

        public override string ToString()
        {
            //-- Yep, this method is used... The output changes depending on
            //-- whether the HighCard has been assigned or not...

            Card unnassigned = Card.GetUnnassignedCard();
            if (HighCard != null)
            {
                if (HighCard.Equals(unnassigned) == false)
                    return base.ToString() + " (" + HighCard.ToString() + ")";
            }

            return base.ToString();
        }

        public new void Clear()
        {
            m_cmbBestCombination = Combination.Unassigned;
            base.Clear();
        }
    }
}
