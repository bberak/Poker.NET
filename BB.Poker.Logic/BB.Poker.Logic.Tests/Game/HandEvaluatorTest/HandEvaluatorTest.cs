using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    /// <summary>
    /// Summary description for HandEvaluatorTest
    /// </summary>
    [TestClass]
    public class HandEvaluatorTest
    {
        public HandEvaluatorTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_GetBestHand_StraightHighCardIsEight()
        {
            CardCollection cards = new CardCollection();
            cards.Add(new Card(Rank.Six, Suit.Spades));
            cards.Add(new Card(Rank.Three, Suit.Hearts));
            cards.Add(new Card(Rank.Four, Suit.Diamonds));
            cards.Add(new Card(Rank.Eight, Suit.Hearts));
            cards.Add(new Card(Rank.Seven, Suit.Diamonds));
            cards.Add(new Card(Rank.Ace, Suit.Diamonds));
            cards.Add(new Card(Rank.Five, Suit.Diamonds));

            HandEvaluator eval = new HandEvaluator(cards);

            Hand bestHand = eval.GetBestHand();

            Assert.IsTrue(bestHand.BestCombination == Combination.Straight && bestHand.HighCard.Rank == Rank.Eight);
        }

        [TestMethod]
        public void Test_DetermineWinner_FullHouse_OneWinner()
        {
            Player winner = new Player("Winner", 1000);
            winner.Cards.Add(new Card(Rank.King, Suit.Diamonds));
            winner.Cards.Add(new Card(Rank.Eight, Suit.Hearts));

            Player loser = new Player("Loser", 1000);
            loser.Cards.Add(new Card(Rank.Two, Suit.Spades));
            loser.Cards.Add(new Card(Rank.Seven, Suit.Hearts));

            CardCollection communityCards = new CardCollection();
            communityCards.Add(new Card(Rank.Two, Suit.Hearts));
            communityCards.Add(new Card(Rank.Two, Suit.Clubs));
            communityCards.Add(new Card(Rank.King, Suit.Hearts));
            communityCards.Add(new Card(Rank.King, Suit.Spades));
            communityCards.Add(new Card(Rank.Queen, Suit.Diamonds));

            HandEvaluator eval = new HandEvaluator();

            Hand winnersHand = eval.GetBestHand(winner.Cards + communityCards);

            Hand losersHand = eval.GetBestHand(loser.Cards + communityCards);

            Assert.AreEqual(1, HandEvaluator.Compare(winnersHand, losersHand));
        }

        [TestMethod]
        public void Test_DetermineWinners_FullHouse_TwoWinners()
        {
            Player winner1 = new Player("Winner1", 1000);
            winner1.Cards.Add(new Card(Rank.Two, Suit.Spades));
            winner1.Cards.Add(new Card(Rank.Two, Suit.Hearts));

            Player winner2 = new Player("Winner2", 1000);
            winner2.Cards.Add(new Card(Rank.Two, Suit.Diamonds));
            winner2.Cards.Add(new Card(Rank.Two, Suit.Clubs));

            CardCollection communityCards = new CardCollection();
            communityCards.Add(new Card(Rank.Three, Suit.Hearts));
            communityCards.Add(new Card(Rank.Six, Suit.Clubs));
            communityCards.Add(new Card(Rank.King, Suit.Hearts));
            communityCards.Add(new Card(Rank.King, Suit.Spades));
            communityCards.Add(new Card(Rank.King, Suit.Diamonds));

            HandEvaluator eval = new HandEvaluator();

            Hand hand1 = eval.GetBestHand(winner1.Cards + communityCards);

            Hand hand2 = eval.GetBestHand(winner2.Cards + communityCards);

            Assert.AreEqual(0, HandEvaluator.Compare(hand1, hand2));
        }

        [TestMethod]
        public void Test_DetermineWinners_OnePair_OneWinner()
        {
            Player winner = new Player("Winner", 1000);
            winner.Cards.Add(new Card(Rank.Four, Suit.Diamonds));
            winner.Cards.Add(new Card(Rank.Five, Suit.Spades));

            Player loser = new Player("Loser", 1000);
            loser.Cards.Add(new Card(Rank.Two, Suit.Clubs));
            loser.Cards.Add(new Card(Rank.Queen, Suit.Spades));

            CardCollection communityCards = new CardCollection();
            communityCards.Add(new Card(Rank.Two, Suit.Hearts));
            communityCards.Add(new Card(Rank.Nine, Suit.Clubs));
            communityCards.Add(new Card(Rank.Four, Suit.Spades));
            communityCards.Add(new Card(Rank.Ten, Suit.Diamonds));
            communityCards.Add(new Card(Rank.Jack, Suit.Diamonds));

            HandEvaluator eval = new HandEvaluator();

            Hand winnersHand = eval.GetBestHand(winner.Cards + communityCards);

            Hand losersHand = eval.GetBestHand(loser.Cards + communityCards);

            Assert.AreEqual(1, HandEvaluator.Compare(winnersHand, losersHand));
        }


        [TestMethod]
        public void Test_DetermineWinners_OnePairKicker_OneWinner()
        {
            Player winner = new Player("Winner", 1000);
            winner.Cards.Add(new Card(Rank.Four, Suit.Clubs));
            winner.Cards.Add(new Card(Rank.Queen, Suit.Spades));

            Player loser = new Player("Loser", 1000);
            loser.Cards.Add(new Card(Rank.Four, Suit.Diamonds));
            loser.Cards.Add(new Card(Rank.Five, Suit.Spades));

            CardCollection communityCards = new CardCollection();
            communityCards.Add(new Card(Rank.Two, Suit.Hearts));
            communityCards.Add(new Card(Rank.Nine, Suit.Clubs));
            communityCards.Add(new Card(Rank.Four, Suit.Spades));
            communityCards.Add(new Card(Rank.Ten, Suit.Diamonds));
            communityCards.Add(new Card(Rank.Jack, Suit.Diamonds));

            HandEvaluator eval = new HandEvaluator();

            Hand winnersHand = eval.GetBestHand(winner.Cards + communityCards);

            Hand losersHand = eval.GetBestHand(loser.Cards + communityCards);

            Assert.AreEqual(true, HandEvaluator.Compare(winnersHand, losersHand) == 1 && winnersHand.HighCard.Rank == Rank.Queen);
        }

        [TestMethod]
        public void Test_DetermineWinners_TwoStraights_OneWinner()
        {
            Player winner = new Player("Winner", 1000);
            winner.Cards.Add(new Card(Rank.King, Suit.Diamonds));
            winner.Cards.Add(new Card(Rank.Three, Suit.Spades));

            Player loser = new Player("Loser", 1000);
            loser.Cards.Add(new Card(Rank.Eight, Suit.Clubs));
            loser.Cards.Add(new Card(Rank.Two, Suit.Spades));

            CardCollection communityCards = new CardCollection();
            communityCards.Add(new Card(Rank.Nine, Suit.Hearts));
            communityCards.Add(new Card(Rank.Ten, Suit.Clubs));
            communityCards.Add(new Card(Rank.Jack, Suit.Spades));
            communityCards.Add(new Card(Rank.Queen, Suit.Diamonds));
            communityCards.Add(new Card(Rank.Five, Suit.Diamonds));

            HandEvaluator eval = new HandEvaluator();

            Hand winnersHand = eval.GetBestHand(winner.Cards + communityCards);

            Hand losersHand = eval.GetBestHand(loser.Cards + communityCards);

            Assert.AreEqual(1, HandEvaluator.Compare(winnersHand, losersHand));
        }
    }
}
