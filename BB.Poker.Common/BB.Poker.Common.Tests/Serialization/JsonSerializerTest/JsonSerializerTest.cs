using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BB.Poker.Common
{
    /// <summary>
    /// Summary description for JsonSerializerTest
    /// </summary>
    [TestClass]
    public class JsonSerializerTest
    {
        private ISerialize serializer;

        public JsonSerializerTest()
        {
            serializer = new JsonSerializer();
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
        public void Test_CardArraySerialization_IsCorrect()
        {
            Card[] arr = new Card[] { new Card(Rank.Eight, Suit.Clubs), new Card(Rank.Jack, Suit.Hearts) };

            byte[] jsonBytes = serializer.GetBytes(arr);

            Card[] arr2 = serializer.GetObject<Card[]>(jsonBytes);

            Assert.IsTrue(arr2.Length == 2 && arr2[0].Rank == Rank.Eight && arr2[1].Rank == Rank.Jack);


        //Rank[] r = new Rank[]{Rank.Jack, Rank.Queen};

        //byte[] jsonBytes = serializer.GetBytes(r);

        //Rank[] r2 = serializer.GetObject<Rank[]>(jsonBytes);

        //Assert.IsTrue(r2[0] == Rank.Jack && r2[1] == Rank.Queen);

            //Suit[] r = new Suit[] { Suit.Diamonds, Suit.Spades };

            //byte[] jsonBytes = serializer.GetBytes(r);

            //Suit[] r2 = serializer.GetObject<Suit[]>(jsonBytes);

            //Assert.IsTrue(r2[0] == Suit.Diamonds && r2[1] == Suit.Spades);

            //Card c = new Card(Rank.Queen, Suit.Spades);

            //byte[] jsonBytes = serializer.GetBytes(c);

            //Card c2 = serializer.GetObject<Card>(jsonBytes);

            //Assert.IsTrue(c2.Rank == Rank.Queen && c2.Suit == Suit.Spades);
        }
    }
}
