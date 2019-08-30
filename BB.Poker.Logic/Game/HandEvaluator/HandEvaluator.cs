using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public class HandEvaluator
    {
        private CardCollection _cardList;

        public HandEvaluator() { }

        public HandEvaluator(CardCollection cards)
        {
            _cardList = cards;
        }

        public CardCollection Cards
        {
            get { return _cardList; }
            set { _cardList = value; }
        }

        private void checkCardList()
        {
            if (_cardList == null || _cardList.Count <= 0)
                throw new InvalidOperationException("The Cards property must be set before hand evaluation can be performed.");
        }

        public Hand GetBestHand(CardCollection cards)
        {
            Cards = cards;

            return GetBestHand();
        }

        public Hand GetBestHand()
        {
            checkCardList();

            Hand bestPairedHand = new Hand();
            bestPairedHand.BestCombination = Combination.HighCard;

            CardCollection winningCards;

            CheckHighestPairConfiguration(out bestPairedHand);

            if (IsRoyalFlush(out winningCards))
                return new Hand(winningCards, Combination.RoyalFlush);

            if (IsStraightFlush(out winningCards))
                return new Hand(winningCards, Combination.StraightFlush);

            if (bestPairedHand.BestCombination == Combination.FourOfAKind)
                return bestPairedHand;

            if (bestPairedHand.BestCombination == Combination.FullHouse)
                return bestPairedHand;

            if (IsFlush(out winningCards))
                return new Hand(winningCards, Combination.Flush);

            if (IsStraight(out winningCards))
                return new Hand(winningCards, Combination.Straight);

            // three of a kind, two pair, one pair and high card are all covered here
            return bestPairedHand;
        }

        public bool CheckHighestPairConfiguration(out Hand hand)
        {
            checkCardList();

            // make a copy
            //List<Card> cardList = new List<Card>(_cardList);
            CardCollection cardList = new CardCollection(_cardList);
            cardList.Sort();


            // this is a list of cards that match the key value
            Dictionary<int, CardCollection> matches = new Dictionary<int, CardCollection>();

            int numPairs = 0;
            int numThrees = 0;
            int numFours = 0;

            // Construct the dictionary
            foreach (Card card in cardList)
            {
                if (matches.ContainsKey(card.Value))
                    matches[card.Value].Add(card);
                else
                    matches.Add(card.Value, new CardCollection(new Card[] { card }));
                    //matches.Add(card.Value, new List<Card>(new Card[] { card }));
            }

            // Determine the number of pairs, threes, and fours
            //foreach (List<Card> cardPairs in matches.Values)
            foreach (CardCollection cardPairs in matches.Values)
            {
                if (cardPairs.Count == 2)
                    numPairs++;

                if (cardPairs.Count == 3)
                    numThrees++;

                if (cardPairs.Count == 4)
                    numFours++;
            }

            //List<Card> resultCards = new List<Card>();
            CardCollection resultCards = new CardCollection();

            // Okay, here comes the real logic
            // One Pair and One Pair Only
            if (numPairs == 1 && numThrees == 0 && numFours == 0)
            {
                // Continue with the assumption that we'll only find one pair
                foreach (int cardValue in matches.Keys)
                {
                    if (matches[cardValue].Count == 2) // this is our pair
                    {
                        resultCards.AddRange(matches[cardValue]);
                        break;
                    }
                }

                // Also add the next highest card
                for (int highCard = cardList.Count - 1; highCard >= 0; highCard--)
                {
                    if (!resultCards.Contains(cardList[highCard]))
                    {
                        // Add the next highest card from the sorted list and break
                        resultCards.Add(cardList[highCard]);
                        break;
                    }
                }

                // Construct the Best Hand for one pair and return true
                //hand = new BestHand(resultCards, HandType.OnePair);
                hand = new Hand(resultCards, Combination.OnePair);
                return true;
            }

            // Two Pair and two pair only
            else if (numPairs >= 2 && numThrees == 0 && numFours == 0)
            {
                int numPairsFound = 0;

                // Continue with the assumption that we'll only find two pairs
                foreach (int cardValue in new Stack<int>(matches.Keys))
                {
                    if (matches[cardValue].Count == 2) // this is our pair
                    {
                        resultCards.AddRange(matches[cardValue]);
                        numPairs++;
                        if (numPairsFound >= 2)
                            break;
                    }
                }

                // Also add the next highest card
                for (int highCard = cardList.Count - 1; highCard >= 0; highCard--)
                {
                    if (!resultCards.Contains(cardList[highCard]))
                    {
                        // Add the next highest card from the sorted list and break
                        resultCards.Add(cardList[highCard]);
                        break;
                    }
                }

                // Construct the Best Hand for one pair and return true
                //hand = new BestHand(resultCards, HandType.TwoPair);
                hand = new Hand(resultCards, Combination.TwoPair);
                return true;
            }

            // Three of a kind only
            else if (numPairs == 0 && numThrees >= 1 && numFours == 0)
            {
                foreach (int cardValue in new Stack<int>(matches.Keys))
                {
                    if (matches[cardValue].Count == 3) // this is our highest 3
                    {
                        resultCards.AddRange(matches[cardValue]);
                        break;
                    }
                }

                // Also add the next highest card
                for (int highCard = cardList.Count - 1; highCard >= 0; highCard--)
                {
                    if (!resultCards.Contains(cardList[highCard]))
                    {
                        // Add the next highest card from the sorted list and break
                        resultCards.Add(cardList[highCard]);
                        break;
                    }
                }

                // Construct the Best Hand for one pair and return true
                //hand = new BestHand(resultCards, HandType.ThreeOfAKind);
                hand = new Hand(resultCards, Combination.ThreeOfAKind);
                return true;
            }

            // four of a kind only
            else if (numPairs <= 1 && numThrees <= 1 && numFours == 1)
            {
                foreach (int cardValue in new Stack<int>(matches.Keys))
                {
                    if (matches[cardValue].Count == 4) // this is the 4
                    {
                        resultCards.AddRange(matches[cardValue]);
                        break;
                    }
                }

                // Also add the next highest card
                for (int highCard = cardList.Count - 1; highCard >= 0; highCard--)
                {
                    if (!resultCards.Contains(cardList[highCard]))
                    {
                        resultCards.Add(cardList[highCard]);
                        break;
                    }
                }

                // Construct the Best Hand for one pair and return true
                //hand = new BestHand(resultCards, HandType.FourOfAKind);
                hand = new Hand(resultCards, Combination.FourOfAKind);
                return true;
            }

            // Full house only
            else if (numPairs >= 1 && numThrees == 1 && numFours == 0)
            {
                foreach (int cardValue in new Stack<int>(matches.Keys))
                {
                    if (matches[cardValue].Count == 3) // this is the 3 in the full house
                        resultCards.AddRange(matches[cardValue]);

                    if (matches[cardValue].Count == 2) // this is the 2
                        resultCards.AddRange(matches[cardValue]);

                    if (resultCards.Count >= 5)
                        break;
                }

                // Construct the Best Hand for one pair and return true
                //hand = new BestHand(resultCards, HandType.FullHouse);
                hand = new Hand(resultCards, Combination.FullHouse);
                return true;
            }

            else
            {
                // Just return the high card
                //List<Card> highCard = new List<Card>();
                CardCollection highCard = new CardCollection();
                highCard.Add(cardList[cardList.Count - 1]);
                //hand = new BestHand(highCard, HandType.HighCard);
                hand = new Hand(highCard, Combination.HighCard);
                return false;
            }
        }

        public bool IsRoyalFlush(out CardCollection winningCards)
        {
            checkCardList();

            CardCollection straightFlushCards;

            if (IsStraightFlush(out straightFlushCards))
            {
                // Check to make sure the straight flush cards are: 10 J Q K A
                straightFlushCards.Sort();

                if (straightFlushCards[0].Value == (int)Rank.Ten &&
                    straightFlushCards[1].Value == (int)Rank.Jack &&
                    straightFlushCards[2].Value == (int)Rank.Queen &&
                    straightFlushCards[3].Value == (int)Rank.King &&
                    straightFlushCards[4].Value == (int)Rank.Ace)
                {
                    winningCards = straightFlushCards;
                    return true;
                }

                else
                {
                    winningCards = null;
                    return false;
                }
            }
            else
            {
                winningCards = null;
                return false;
            }
        }

        public bool IsStraightFlush(out CardCollection winningCards)
        {
            checkCardList();

            CardCollection straightCards, flushCards;

            if (IsStraight(out straightCards) && IsFlush(out flushCards))
            {
                straightCards.Sort();
                flushCards.Sort();

                if (straightCards.Count != flushCards.Count)
                {
                    winningCards = null;
                    return false;
                }

                for (int i = 0; i < straightCards.Count; i++)
                {
                    if (straightCards[i].Value == flushCards[i].Value)
                    {
                        winningCards = null;
                        return false;
                    }
                }

                winningCards = straightCards;
                return true;
            }
            else
            {
                winningCards = null;
                return false;
            }
        }

        public bool IsFlush(out CardCollection winningCards)
        {
            checkCardList();

            CardCollection cardList = new CardCollection(_cardList);

            CardCollection clubs = new CardCollection();
            CardCollection diamonds = new CardCollection();
            CardCollection hearts = new CardCollection();
            CardCollection spades = new CardCollection();

            foreach (Card card in cardList)
            {
                switch (card.Suit)
                {
                    case Suit.Clubs:
                        clubs.Add(card);
                        break;
                    case Suit.Diamonds:
                        diamonds.Add(card);
                        break;
                    case Suit.Hearts:
                        hearts.Add(card);
                        break;
                    case Suit.Spades:
                        spades.Add(card);
                        break;
                    default:
                        break;
                }
            }

            if (clubs.Count >= 5)
            {
                winningCards = clubs;
                winningCards.Sort();
                return true;
            }

            if (diamonds.Count >= 5)
            {
                winningCards = diamonds;
                winningCards.Sort();
                return true;
            }

            if (hearts.Count >= 5)
            {
                winningCards = hearts;
                winningCards.Sort();
                return true;
            }

            if (spades.Count >= 5)
            {
                winningCards = spades;
                winningCards.Sort();
                return true;
            }

            winningCards = null;
            return false;
        }

        public bool IsStraight(out CardCollection winningCards)
        {
            checkCardList();

            // Get a copy of the card list
            CardCollection cardList = new CardCollection(_cardList);

            winningCards = new CardCollection();

            // Sort the cards by value
            cardList.Sort();

            // if there is an ace in the deck, it got moved to the end by the sort
            // so we need to insert a new "ace" in the sorted deck (with a value of 1) in the beginning position
            foreach (Card card in cardList)
            {
                if (card.Value == (int)Rank.Ace)
                {
                    cardList.Insert(0, new Card(card.Rank, card.Suit));
                    break;
                }
            }

            int cardsInARow = 1;

            // Check each card and the next one
            for (int i = 0; i < cardList.Count; i++)
            {
                // Add the current card to the winning cards index, just in case it's part of a straight
                winningCards.Add(cardList[i]);

                // If this is the last card, check to see if it is part of a straight
                if (i == cardList.Count - 1)
                {
                    if (cardList[i].IsOneGreaterThan(cardList[i - 1]))
                    {
                        cardsInARow++;
                    }
                    else
                        winningCards.Clear();
                }
                else
                {
                    // If this card is the same as the next one, ignore it
                    if (cardList[i].Value == cardList[i + 1].Value)
                    {
                        // remove the card we just added
                        winningCards.Remove(cardList[i]);
                        continue;
                    }

                    // Check to see if this card is exactly one less than the next card
                    if (cardList[i].IsOneLessThan(cardList[i + 1]))
                    {
                        cardsInARow++;
                    }
                    else
                    {
                        // if we already have a straight (5 cards) stop checking for more straights
                        if (cardsInARow >= 5)
                            break;
                        else
                        {
                            cardsInARow = 1;
                            winningCards.Clear();
                        }
                    }
                }
            }

            // Trim off any excess cards that are not the highest straight, and return true
            // Example: if you have A 2 3 4 5 6, the ace will be cut off and 2 3 4 5 6 will be preserved
            if (winningCards.Count >= 5)
            {
                if (winningCards.Count > 5)
                    winningCards.RemoveRange(0, winningCards.Count - 5);

                return true;
            }

            else
            {
                winningCards = null;
                return false;
            }
        }

        public static int GetHighestPairValue(Hand hand)
        {
            Dictionary<int, int> cardCounts = new Dictionary<int, int>();
            foreach (Card card in hand)
            {
                if (!cardCounts.ContainsKey(card.Value))
                    cardCounts.Add(card.Value, 1);
                else
                    cardCounts[card.Value]++;
            }

            int highestPairValue = 0;
            foreach (int pairValue in cardCounts.Keys)
            {
                int realValue = pairValue;

                if (realValue == 1)
                    realValue = Card.ACE_HIGH;

                if (cardCounts[pairValue] > 1 && realValue > highestPairValue) // this is the next highest pair                
                    highestPairValue = realValue;
            }

            return highestPairValue;
        }

        public static int Compare(Hand hand1, Hand hand2)
        {
            if (hand1.BestCombination == hand2.BestCombination)
            {
                switch (hand1.BestCombination)
                {
                    case Combination.HighCard:
                    case Combination.OnePair:
                    case Combination.TwoPair:
                    case Combination.ThreeOfAKind:
                    case Combination.FourOfAKind:
                        {
                            if (GetHighestPairValue(hand1) == GetHighestPairValue(hand2))
                            {
                                // the pair values are the same, check high card
                                if (hand1.HighCard.Value == hand2.HighCard.Value)
                                    return 0;
                                else if (hand1.HighCard > hand2.HighCard)
                                    return 1;
                                else
                                    return -1;
                            }
                            else if (GetHighestPairValue(hand1) > GetHighestPairValue(hand2))
                                return 1;
                            else
                                return -1;
                        }
                    case Combination.Straight:
                        {
                            if (hand1.HighCard.Value == hand2.HighCard.Value)
                                return 0;
                            else if (hand1.HighCard > hand2.HighCard)
                                return 1;
                            else
                                return -1;
                        }
                    case Combination.FullHouse:
                        {
                            return CompareFullHouses(hand1, hand2);
                        }
                    default:
                        return 0;
                }
            }
            else if (hand1.BestCombination > hand2.BestCombination)
                return 1;
            else
                return -1;
        }

        public static int CompareFullHouses(Hand fullHouse1, Hand fullHouse2)
        {
            fullHouse1.Sort();
            fullHouse2.Sort();

            Card fullHouse1ThreeOfAKind = NFIWhatToCallMethod(fullHouse1, Combination.ThreeOfAKind);
            Card fullHouse2ThreeOfAKind = NFIWhatToCallMethod(fullHouse2, Combination.ThreeOfAKind);

            if (fullHouse1ThreeOfAKind == fullHouse2ThreeOfAKind)
            {
                Card fullHouse1Pair = NFIWhatToCallMethod(fullHouse1, Combination.OnePair);
                Card fullHouse2Pair = NFIWhatToCallMethod(fullHouse2, Combination.OnePair);

                if (fullHouse1Pair.Value == fullHouse2Pair.Value)
                    return 0;
                else if (fullHouse1Pair > fullHouse2Pair)
                    return 1;
                else
                    return -1;
            }
            else if (fullHouse1ThreeOfAKind > fullHouse2ThreeOfAKind)
                return 1;
            else
                return -1; 
        }

        public static Card NFIWhatToCallMethod(Hand fullHouse, Combination type)
        {
            // This method is used for finding the highest three-of-a-kind or highest
            // pair of a fullhouse hand. How would I name this method??..NFI? Exactly!

            if (fullHouse.BestCombination != Combination.FullHouse)
                throw new InvalidOperationException("This method is only designed to be used by Full House hands.");

            fullHouse.Sort();

            Card highest = new Card(Rank.Unassigned, Suit.Unassigned);

            switch (type)
            {
                case Combination.ThreeOfAKind:
                    {
                        int count = 0;
                        foreach (Card c in fullHouse)
                        {
                            if (c.Value == highest.Value)
                                count++;
                            else
                            {
                                highest = c;
                                count = 1;
                            }

                            if (count == 3)
                                break;
                        }
                        break;
                    }

                case Combination.OnePair:
                    {
                        int count = 0;
                        Card ignore = NFIWhatToCallMethod(fullHouse, Combination.ThreeOfAKind);
                        foreach (Card c in fullHouse)
                        {
                            if (c.Value == ignore.Value)
                                continue;
                            else if (c.Value == highest.Value)
                                count++;
                            else
                            {
                                highest = c;
                                count = 1;
                            }

                            if (count == 2)
                                break;
                        }
                        break;
                    }

                default:
                    throw new InvalidOperationException("This method only accetps 'type' parameters of Combination.OnePair and Combination.ThreeOfAKind.");
            }

            return highest;
        }

        //public static bool Beats(Hand winningHand, Hand losingHand)
        //{
        //    if (winningHand.BestCombination == losingHand.BestCombination)
        //    {
        //        switch (winningHand.BestCombination)
        //        {
        //            case Combination.HighCard:
        //            case Combination.OnePair:
        //            case Combination.TwoPair:
        //            case Combination.ThreeOfAKind:
        //            case Combination.FourOfAKind:
        //                if (GetHighestPairValue(winningHand) == GetHighestPairValue(losingHand))
        //                    // the pair values are the same, check high card
        //                    return winningHand.HighCard > losingHand.HighCard;

        //                else // the pair values are different
        //                    return GetHighestPairValue(winningHand) > GetHighestPairValue(losingHand);
        //            default:
        //                return false;
        //        }
        //    }

        //    return winningHand.BestCombination > losingHand.BestCombination;
        //}

        //public static bool IsEquivalentTo(Hand hand1, Hand hand2)
        //{
        //    if (hand1.BestCombination == hand2.BestCombination)
        //    {
        //        switch (hand1.BestCombination)
        //        {
        //            case Combination.HighCard:
        //                if (hand1.HighCard.Value == hand2.HighCard.Value)
        //                    return true;
        //                else
        //                    return false;

        //            case Combination.OnePair:
        //            case Combination.TwoPair:
        //            case Combination.ThreeOfAKind:
        //            case Combination.FourOfAKind:
        //                if (GetHighestPairValue(hand1) == GetHighestPairValue(hand2))
        //                {
        //                    // check the high card
        //                    if (hand1.HighCard.Value == hand2.HighCard.Value)
        //                        return true;
        //                    else
        //                        return false;
        //                }
        //                else
        //                    return false;
        //            default:
        //                return false;
        //        }
        //    }

        //    return false;
        //}
    }
}
