using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public interface IShuffle
    {
        void ResetSeed();

        void ResetSeed(int newSeed);

        void Shuffle();

        void Shuffle(int howManyTimes);

        void Shuffle(Deck deckToShuffle);

        void Shuffle(Deck deckToShuffle, int howManyTimes);
    }
}
