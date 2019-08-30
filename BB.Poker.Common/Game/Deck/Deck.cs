using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public class Deck : CardCollection
    {
        public const int TOP_CARD_INDEX = 0;

        public Deck()
        {
        }

        public Card PullCard()
        {
            if (this.Count > 0)
            {
                Card topCard = this[TOP_CARD_INDEX];

                this.Remove(topCard);

                return topCard;
            }
            else
                throw new InvalidOperationException("This card collection is empty.");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Card c in this)
                sb.Append(c.ToString() + " ");

            return sb.ToString();
        }
    }
}
