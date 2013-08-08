using NUnit.Framework;

namespace PokerHands
{
    [TestFixture]
    public class HandTests
    {
        [Test]
        public void GetHighCard()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Three, Card.CardSuit.Diamonds),
                new Card(Card.CardValue.Five, Card.CardSuit.Spades),
                new Card(Card.CardValue.Nine, Card.CardSuit.Clubs),
                new Card(Card.CardValue.King, Card.CardSuit.Diamonds));
            //Act
            var result = hand.GetHighCard();
            //Assert
            Assert.AreEqual(Card.CardValue.King, result);
        }

        [Test]
        public void GetHighCardAce()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs), 
                new Card(Card.CardValue.Three, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Four, Card.CardSuit.Spades), 
                new Card(Card.CardValue.Eight, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Ace, Card.CardSuit.Hearts));
            //Act
            var result = hand.GetHighCard();
            //Assert
            Assert.AreEqual(Card.CardValue.Ace, result);
        }

        [Test]
        public void IsPair()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Three, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Four, Card.CardSuit.Spades),
                new Card(Card.CardValue.Eight, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Ace, Card.CardSuit.Hearts));
            //Act
            //Assert
            Assert.AreEqual(false, hand.Rank == Hand.HandRank.Pair);
        }

        [Test]
        public void IsPairWithTwoTwosShouldReturnTrue()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Two, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Four, Card.CardSuit.Spades),
                new Card(Card.CardValue.Eight, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Ace, Card.CardSuit.Hearts));
            //Act
            //Assert
            Assert.AreEqual(true, hand.Rank == Hand.HandRank.Pair);
        }

        [Test]
        public void IsPairWithThreeTwosShouldReturnFalse()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Two, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Two, Card.CardSuit.Spades),
                new Card(Card.CardValue.Eight, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Ace, Card.CardSuit.Hearts));
            //Act
            //Assert
            Assert.AreEqual(false, hand.Rank == Hand.HandRank.Pair);
        }

        [Test]
        public void IsTwoPairsWithTwoTwosAndTwoThreesShouldReturnTrue()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Two, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Three, Card.CardSuit.Spades),
                new Card(Card.CardValue.Three, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Ace, Card.CardSuit.Hearts));
            //Act
            //Assert
            Assert.AreEqual(true, hand.Rank == Hand.HandRank.TwoPairs);
        }

        [Test]
        public void IsTwoPairsWithThreeTwosAndNoOtherMatchShouldReturnFalse()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Two, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Two, Card.CardSuit.Spades),
                new Card(Card.CardValue.Three, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Ace, Card.CardSuit.Hearts));
            //Act
            //Assert
            Assert.AreEqual(false, hand.Rank == Hand.HandRank.TwoPairs);
        }

        [Test]
        public void RankOfThreeTwosAndNoOtherMatchIsThreeOfAKind()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Two, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Two, Card.CardSuit.Spades),
                new Card(Card.CardValue.Three, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Ace, Card.CardSuit.Hearts));
            //Act
            //Assert
            Assert.AreEqual(Hand.HandRank.ThreeOfAKind, hand.Rank);
        }

        [Test]
        public void RankOfFullhouseIsNotThreeOfAKind()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Two, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Two, Card.CardSuit.Spades),
                new Card(Card.CardValue.Three, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Three, Card.CardSuit.Hearts));
            //Act
            //Assert
            Assert.AreNotEqual(Hand.HandRank.ThreeOfAKind, hand.Rank);
            Assert.AreEqual(Hand.HandRank.FullHouse, hand.Rank);
        }

        [Test]
        public void RankOfStraightIsStraight()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Three, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Four, Card.CardSuit.Spades),
                new Card(Card.CardValue.Five, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Six, Card.CardSuit.Hearts));
            //Act
            //Assert
            Assert.AreEqual(Hand.HandRank.Straight, hand.Rank);
        }

        [Test]
        public void RankOfHighCardIsNotStraight()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Three, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Four, Card.CardSuit.Spades),
                new Card(Card.CardValue.Five, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Seven, Card.CardSuit.Hearts));
            //Act
            //Assert
            Assert.AreNotEqual(Hand.HandRank.Straight, hand.Rank);
        }

        [Test]
        public void RankOfStraightFlushIsNotStraight()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Three, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Four, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Five, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Six, Card.CardSuit.Clubs));
            //Act
            //Assert
            Assert.AreEqual(Hand.HandRank.StraightFlush, hand.Rank);
        }

        [Test]
        public void RankOfFlushIsNotStraight()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Three, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Four, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Five, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Jack, Card.CardSuit.Clubs));
            //Act
            //Assert
            Assert.AreEqual(Hand.HandRank.Flush, hand.Rank);
        }

        [Test]
        public void RankOfFourOfAKindIsNotStraight()
        {
            //Arrange
            var hand = new Hand(
                new Card(Card.CardValue.Two, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Queen, Card.CardSuit.Hearts),
                new Card(Card.CardValue.Queen, Card.CardSuit.Spades),
                new Card(Card.CardValue.Queen, Card.CardSuit.Clubs),
                new Card(Card.CardValue.Queen, Card.CardSuit.Diamonds));
            //Act
            //Assert
            Assert.AreEqual(Hand.HandRank.FourOfAKind, hand.Rank);
        }
    }
}