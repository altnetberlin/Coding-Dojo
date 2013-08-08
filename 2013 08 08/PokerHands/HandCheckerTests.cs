using NUnit.Framework;

namespace PokerHands
{
    [TestFixture]
    public class HandCheckerTests
    {
        [Test]
        public void CompareHands()
        {
            var black = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Three, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.Five, Card.CardSuit.Spades),
                new Card(Card.CardValue.Nine, Card.CardSuit.Clubs),
                new Card(Card.CardValue.King, Card.CardSuit.Diamonds));

            var white = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Three, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Four, Card.CardSuit.Spades),
                new Card(Card.CardValue.Eight, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Ace, Card.CardSuit.Hearts));

            var checker = new HandChecker();

            var result = checker.Compare(black, white);

            Assert.AreEqual(white, result);
        }

        [Test]
        public void CompareHandsOtherWayAround()
        {
            var white = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Three, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.Five, Card.CardSuit.Spades),
                new Card(Card.CardValue.Nine, Card.CardSuit.Clubs),
                new Card(Card.CardValue.King, Card.CardSuit.Diamonds));

            var black = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Three, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Four, Card.CardSuit.Spades),
                new Card(Card.CardValue.Eight, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Ace, Card.CardSuit.Hearts));

            var checker = new HandChecker();

            var result = checker.Compare(black, white);

            Assert.AreEqual(black, result);
        }

        [Test]
        public void CompareSameHands()
        {
            var white = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Three, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.Five, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.Nine, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.King, Card.CardSuit.Diamonds));

            var black = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Three, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Five, Card.CardSuit.Spades),
                new Card(Card.CardValue.Nine, Card.CardSuit.Clubs),
                new Card(Card.CardValue.King, Card.CardSuit.Hearts));

            var checker = new HandChecker();

            var result = checker.Compare(black, white);

            Assert.AreEqual(null, result);
        }

        [Test]
        public void CompareFlushWinsOverHighCard()
        {
            var white = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.Three, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.Five, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.Nine, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.King, Card.CardSuit.Diamonds));

            var black = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Three, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Five, Card.CardSuit.Spades),
                new Card(Card.CardValue.Nine, Card.CardSuit.Clubs),
                new Card(Card.CardValue.King, Card.CardSuit.Hearts));

            var checker = new HandChecker();

            var result = checker.Compare(black, white);

            Assert.AreEqual(white, result);
        }

        [Test]
        public void CompareFlushWinsOverPair()
        {
            var black = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.Three, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.Five, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.Nine, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.King, Card.CardSuit.Diamonds));

            var white = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Three, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Three, Card.CardSuit.Spades),
                new Card(Card.CardValue.Nine, Card.CardSuit.Clubs),
                new Card(Card.CardValue.King, Card.CardSuit.Hearts));

            var checker = new HandChecker();

            var result = checker.Compare(black, white);

            Assert.AreEqual(black, result);
        }
    }

    public class HandChecker
    {
        public Hand Compare(Hand black, Hand white)
        {
            if (black.Rank > white.Rank)
                return black;
            if (black.Rank < white.Rank)
                return white;
            if (black.HighCard > white.HighCard)
                return black;
            if (black.HighCard < white.HighCard)
                return white;
            return null;
        }
    }
}