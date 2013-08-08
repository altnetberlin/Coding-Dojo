using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PokerHands
{
    [TestFixture]
    public class Class1
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

    public class Hand
    {
        public enum HandRank
        {
            HighCard,
            TwoPairs,
            ThreeOfAKind,
            Pair,
            Straight,
            StraightFlush,
            FullHouse,
            Flush,
            FourOfAKind
        }

        private readonly Card[] _cards;
        public HandRank Rank { get; private set; }

        public Hand(Card one, Card two, Card three, Card four, Card five)
        {
            _cards = new[] { one, two, three, four, five };            
            Rank = GetRank();
        }

        private HandRank GetRank()
        {
            var suitGroups = _cards.GroupBy(card => card.Suit);
            var valueGroups = _cards.GroupBy(card => card.Value);
            if (HasStraight(valueGroups) && HasFlush(suitGroups))
                return HandRank.StraightFlush;
            if (IsFourOfAKind(valueGroups))
                return HandRank.FourOfAKind;
            if (HasThreeOfAKind(valueGroups) && HasPair(valueGroups))
                return HandRank.FullHouse;
            if (HasFlush(suitGroups))
                return HandRank.Flush;
            if (HasStraight(valueGroups))
                return HandRank.Straight;
            if (HasThreeOfAKind(valueGroups))
                return HandRank.ThreeOfAKind;
            if (IsTwoPairs(valueGroups))
                return HandRank.TwoPairs;
            if (HasPair(valueGroups))
                return HandRank.Pair;
            return HandRank.HighCard;
        }

        private bool IsFourOfAKind(IEnumerable<IGrouping<Card.CardValue, Card>> valueGroups)
        {
            return valueGroups.Count(grouping => grouping.Count() == 4) == 1;
        }

        private static bool HasPair(IEnumerable<IGrouping<Card.CardValue, Card>> valueGroups)
        {
            return valueGroups.Count(grouping => grouping.Count() == 2) == 1;
        }

        private static bool IsTwoPairs(IEnumerable<IGrouping<Card.CardValue, Card>> valueGroups)
        {
            return valueGroups.Count(grouping => grouping.Count() == 2) == 2;
        }

        private static bool HasThreeOfAKind(IEnumerable<IGrouping<Card.CardValue, Card>> valueGroups)
        {
            return valueGroups.Count(grouping => grouping.Count() == 3) == 1;
        }

        private static bool HasFlush(IEnumerable<IGrouping<Card.CardSuit, Card>> suitGroups)
        {
            return suitGroups.Count() == 1;
        }

        private bool HasStraight(IEnumerable<IGrouping<Card.CardValue, Card>> valueGroups)
        {
            return valueGroups.Count()==5 && 
                   (_cards.Max(x=>x.Value) - _cards.Min(x=>x.Value) == 4);
        }

        public Card.CardValue GetHighCard()
        {
            return _cards.Max(x => x.Value);
        }
    }
    
    public class Card
    {
        public enum CardValue
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            King,
            Ace,
            Jack,
            Queen
        }

        public enum CardSuit
        {
            Hearts,
            Diamonds,
            Spades,
            Clubs
        }

        public Card(CardValue cardValue, CardSuit cardSuit)
        {
            Value = cardValue;
            Suit = cardSuit;
        }

        public CardSuit Suit { get; private set; }

        public CardValue Value { get; private set; }
    }
}
