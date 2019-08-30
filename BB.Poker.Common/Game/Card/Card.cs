using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BB.Poker.Common
{
    [JsonConverter(typeof(JsonCardConverter))]
    [Serializable]
    public class Card : IComparable
    {
        public const int ACE_HIGH = (int)Rank.King + 1;
        private Rank _rank;
        private Suit _suit;

        public Card(Rank rank, Suit suit)
        {
            this._rank = rank;
            this._suit = suit;
        }

        public Card()
            : this(Rank.Unassigned, Suit.Unassigned)
        {
        }

        public static Card GetUnnassignedCard()
        {
            return new Card(Rank.Unassigned, Suit.Unassigned);
        }

        public override string ToString()
        {
            return this._rank + "-" + this._suit;
        }

        public Rank Rank
        {
            get { return _rank; }
        }

        public int Value
        {
            get { return (int)_rank; }
        }

        public Suit Suit
        {
            get { return _suit; }
        }

        public bool IsOneGreaterThan(Card otherCard)
        {
            //-- If this card is an ace, and the other card is a king, return true.
            if (this.Rank == Rank.Ace && otherCard.Rank == Rank.King)
                return true;

            return (this.Value == otherCard.Value + 1);
        }

        public bool IsOneLessThan(Card otherCard)
        {
            //-- If this card is a King and the other is an Ace, return true.
            if (this.Rank == Rank.King && otherCard.Rank == Rank.Ace)
                return true;

            return (this.Value == otherCard.Value - 1);
        }

        public static CardCollection operator +(Card c1, Card c2)
        {
            CardCollection summCollection = new CardCollection();

            if (c1 != null)
                summCollection.Add(c1);

            if (c2 != null)
                summCollection.Add(c2);

            return summCollection;
        }

        public static bool operator >(Card x, Card y)
        {
            int realXValue = x.Value;
            int realYValue = y.Value;

            //-- Aces have the highest value but are set to 1 for sequential purposes
            //-- so temporarily assign the value to 14 (King + 1).
            if (realXValue == 1)
                realXValue = Card.ACE_HIGH;

            if (realYValue == 1)
                realYValue = Card.ACE_HIGH;

            return (realXValue > realYValue);
        }

        public static bool operator <(Card x, Card y)
        {
            //-- Take advantage of the already implemented > logic above.
            return !(x > y);
        }

        //public static bool operator ==(Card x, Card y)
        //{
        //    if (x.Value == y.Value)
        //        return true;
        //    else
        //        return false;
        //}

        //public static bool operator !=(Card x, Card y)
        //{
        //    return !(x == y);
        //}

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is Card)
            {
                Card card = (Card)obj;
                if (this < card)
                    return -1;
                else if (this.Value == card.Value)
                    return 0;
                else
                    return 1;
            }
            throw new InvalidCastException("The parameter 'obj' is not a card.");
        }

        public override bool Equals(object obj)
        {
            if (obj is Card)
            {
                Card c = (Card)obj;

                if (this.Rank == c.Rank && this.Suit == c.Suit)
                    return true;
                else
                    return false;
            }
            else 
                throw new InvalidCastException("The parameter 'obj' is not a card.");
        }

        public override int GetHashCode()
        {
            int result = 17;
            result = 37 * result + this.Rank.GetHashCode();
            result = 37 * result + this.Suit.GetHashCode();
            result = 37 * result + this.Value.GetHashCode();
            return result;
        }

        #endregion
    }
}
