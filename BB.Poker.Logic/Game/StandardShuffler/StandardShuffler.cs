using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class StandardShuffler : IShuffle
    {
        private const int DEFAULT_SHUFFLE_COUNT = 5;
        private Random rand;
        private Deck deck;

        public StandardShuffler()
        {
            ResetSeed();
        }

        public StandardShuffler(Deck d):this()
        {
            deck = d;
        }

        private void swapCards(int i, int j)
        {
            Card tmp = deck[i];
            deck[i] = deck[j];
            deck[j] = tmp;
        }

        #region IShuffle Members

        public void ResetSeed(int newSeed)
        {
            rand = new Random(newSeed);
        }

        public void ResetSeed()
        {
            ResetSeed(Environment.TickCount);
        }

        public void Shuffle(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                /*for (int j = 0; j < deck.Count; ++j)
                {
                    int idx = rand.Next(deck.Count);
                    swapCards(j, idx);
                }*/

                //-- See http://www.codinghorror.com/blog/2007/12/the-danger-of-naivete.html for explanation of algorithm below
                for (int j = deck.Count - 1; j > 0; j--)
                {
                    int idx = rand.Next(j + 1);
                    swapCards(j, idx);
                }
            }
        }

        public void Shuffle()
        {
            this.Shuffle(DEFAULT_SHUFFLE_COUNT);
        }

        public void Shuffle(Deck deckToShuffle)
        {
            deck = deckToShuffle;
            this.Shuffle();
        }

        public void Shuffle(Deck deckToShuffle, int howManyTimes)
        {
            deck = deckToShuffle;
            this.Shuffle(howManyTimes);
        }

        #endregion

    }
}
