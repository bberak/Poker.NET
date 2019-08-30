using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class DeckFactory
    {
        private IShuffle m_isShuffler;

        public DeckFactory(IShuffle shuffler)
        {
            m_isShuffler = shuffler;
        }

        public Deck GetFreshDeck()
        {
            Deck freshDeck = new Deck();
            // nice way to initialize the Deck, using
            // builtin functionality of Enum
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                    if (r != Rank.Unassigned && s != Suit.Unassigned)
                        freshDeck.Add(new Card(r, s));

            return freshDeck;
        }

        public Deck GetShuffledDeck()
        {
            Deck deckToShuffle = GetFreshDeck();

            m_isShuffler.ResetSeed();

            m_isShuffler.Shuffle(deckToShuffle);

            return deckToShuffle;
        } 
    }
}
