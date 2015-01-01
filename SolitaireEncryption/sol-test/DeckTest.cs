using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ConceptDevelopment.Net.Collections;

namespace soltest
{
    [TestFixture()]
    public class DeckTest
    {
        private Random _rand;

        public DeckTest()
        {
            _rand = new Random();
        }

        [SetUp()]
        public void reset()
        {
            referenceDeck = new Deck();
            variableDeck = new Deck();
        }

        [Test()]
        public void TestDeck_CreatedDeterministically()
        {
            CollectionAssert.AreEqual(referenceDeck, variableDeck);
            // Test this assertion method works
            assertCardMovedFromTo(53, 53);
        }

        [Test()]
        public void TestDeck_BasicCut()
        {
            var bottomCard = variableDeck.PeekBottom(1);
            var secondToBottom = variableDeck.PeekBottom(2);
            var topCard = variableDeck.PeekTop(1);

            variableDeck.BasicCut(53, variableDeck.Count());
            // Original Card 53 must move to place 1
            Assert.AreEqual(bottomCard, variableDeck.PeekTop(1));
            // original Card 1 must move to place 2 
            Assert.AreEqual(variableDeck.PeekTop(2), topCard);
            // original card 52 must move to place 53
            Assert.AreEqual(secondToBottom, variableDeck.PeekBottom(1));
            reset();

            variableDeck.BasicCut(6, 9);

            assertCardMovedFromTo(1, 4);
            assertCardMovedFromTo(2, 5);
            assertCardMovedFromTo(3, 6);
            assertCardMovedFromTo(4, 7);
            assertCardMovedFromTo(5, 8);
            assertCardMovedFromTo(6, 9);
            assertCardMovedFromTo(8, 2);
            assertCardMovedFromTo(9, 3);
            assertCardMovedFromTo(10, 10);
        }

        private void assertCardMovedFromTo(int from, int to)
        {
            Assert.AreEqual(referenceDeck.PeekTop(from), variableDeck.PeekTop(to));
        }

        [Test()]
        public void TestDeck_BasicCutArgumentBoundaries()
        {
            // Passing a toPosition of greater than variableDeck.Count() must throw an exception
            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                referenceDeck.BasicCut(variableDeck.Count(), 55);
            });

            reset();

            // Passing a fromPosition of greater than variableDeck.Count() must throw an exception
            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                referenceDeck.BasicCut(55, 56);
            });

            reset();

            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                referenceDeck.BasicCut(0, 1);
            });

            reset();
        }

        [Test()]
        public void TestDeck_CutTop()
        {
            for (int i = 0; i < variableDeck.Count(); i++)
            {
                var random = _rand.Next(1, variableDeck.Count());
                variableDeck.CutTop(random);

                int j = random + 1, k = 1;
                for (; j <= variableDeck.Count(); j++, k++)
                {
                    assertCardMovedFromTo(j, k);
                }

                j = 1;
                for (; j <= random; j++)
                {
                    assertCardMovedFromTo(j, j + (variableDeck.Count() - random));
                }
                referenceDeck.CutTop(random);
            }
        }

        [Test()]
        public void TestDeck_CutBottom()
        {
            for (int i = 0; i < variableDeck.Count(); i++)
            {
                var random = _rand.Next(1, variableDeck.Count());
                variableDeck.CutBottom(random);
                referenceDeck.CutTop(variableDeck.Count() - random);
                CollectionAssert.AreEqual(referenceDeck, variableDeck);
            }
        }

        [Test()]
        public void TestDeck_FindBottom()
        {
            Assert.AreEqual(1, referenceDeck.FindBottom(new Card(CardSuit.Joker, CardFace.Two)));
            Assert.AreEqual(3, referenceDeck.FindBottom(new Card(3, 13)));
            Assert.AreEqual(54, referenceDeck.FindBottom(new Card(0, 1)));
        }

        [Test()]
        public void TestDeck_FindTop()
        {
            Assert.AreEqual(1, referenceDeck.FindTop(new Card(0, 1)));
            Assert.AreEqual(3, referenceDeck.FindTop(new Card(0, 3)));
            Assert.AreEqual(54, referenceDeck.FindTop(new Card(CardSuit.Joker, CardFace.Two)));
        }

        [Test()]
        public void TestDeck_FindTopAndBottomAreInverses()
        {
            for (int i = 0; i < referenceDeck.Count(); i++)
            {
                int suit = rand.Next(0, 4), face = rand.Next(1, 14);
                int distanceFromTop = referenceDeck.FindTop(new Card(suit, face));
                int distanceFromBottom = referenceDeck.FindBottom(new Card(suit, face));
                Assert.AreEqual(55, distanceFromTop + distanceFromBottom);
            }
        }

        [Test()]
        public void TestDeck_MoveDown()
        {
            variableDeck.MoveDown(1);
            assertCardMovedFromTo(1, 2);
            assertCardMovedFromTo(2, 1);
            for (int i = 3; i <= 54; i++)
            {
                assertCardMovedFromTo(i, i);
            }

            reset();
            variableDeck.MoveDown(54);
            for (int i = 1; i <= 54; i++)
            {
                switch (i)
                {
                    case 1:
                        assertCardMovedFromTo(i, i);
                        break;
                    case 54:
                        assertCardMovedFromTo(i, 2);
                        break;
                    default:
                        assertCardMovedFromTo(i, i + 1);
                        break;
                }
            }
        }

        [Test()]
        public void TestDeck_MoveDownMultiple()
        {
            variableDeck.MoveDown(1, 2);
            assertCardMovedFromTo(1, 3);
            assertCardMovedFromTo(2, 1);
            assertCardMovedFromTo(3, 2);

            reset();
            variableDeck.MoveDown(53, 3);
            assertCardMovedFromTo(54, 54);
            assertCardMovedFromTo(53, 3);
            assertCardMovedFromTo(2, 2);
            assertCardMovedFromTo(1, 1);

            for (int i = 3; i <= 52; i++)
            {
                assertCardMovedFromTo(i, i + 1);
            }
        }

        [Test()]
        public void TestDeck_MoveNext()
        {
            for (int i = 0; i < variableDeck.Count(); i++)
            {
                Assert.IsTrue(variableDeck.MoveNext());
            }
            Assert.IsFalse(variableDeck.MoveNext());
        }

        [Test()]
        public void TestDeck_Shuffle()
        {
            variableDeck.Shuffle();
            CollectionAssert.AreNotEqual(referenceDeck, variableDeck);
        }

        [Test()]
        public void TestDeck_TripleCut()
        {
            for (int i = 0; i < 100; i++) {
                reset();
                variableDeck.Shuffle();
                var oneJoker = variableDeck.FindTop(new Card(CardSuit.Joker, CardFace.Ace));
                var twoJoker = variableDeck.FindTop(new Card(CardSuit.Joker, CardFace.Two));
                var firstJoker = Math.Min(oneJoker, twoJoker);
                var secondJoker = Math.Max(oneJoker, twoJoker);
                var cards = variableDeck.Cast<Card>().ToList();
                variableDeck.Reset();

                List<Card> firstStack = cards.Take(firstJoker - 1).ToList();
                List<Card> lastStack = cards.Skip(secondJoker).ToList();
                List<Card> middleStack = cards.Skip(firstJoker - 1).Take(cards.Count() - firstStack.Count() - lastStack.Count()).ToList();
                List<Card> output = lastStack.Concat(middleStack).Concat(firstStack).ToList();
                variableDeck.TripleCut(firstJoker, secondJoker);
                CollectionAssert.AreEqual(output, variableDeck.Cast<Card>().ToList());
            }
        }

        public Deck referenceDeck { get; set; }

        public Deck variableDeck { get; set; }

        public Random rand
        {
            get { return _rand; }
        }
    }
}