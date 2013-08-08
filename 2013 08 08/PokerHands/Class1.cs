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
            var result = hand.IsPair();
            //Assert
            Assert.AreEqual(false, result);
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
            var result = hand.IsPair();
            //Assert
            Assert.AreEqual(true, result);
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
            var result = hand.IsPair();
            //Assert
            Assert.AreEqual(false, result);
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
            var result = hand.IsTwoPairs();
            //Assert
            Assert.AreEqual(true, result);
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
            var result = hand.IsTwoPairs();
            //Assert
            Assert.AreEqual(false, result);
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
        }
    }

    public class Hand
    {
        public enum HandRank
        {
            None,
            ThreeOfAKind,
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
            var groups = _cards.GroupBy(card => card.Value);
            if ((groups.Count(grouping => grouping.Count() == 3) == 1) &&
                (groups.Count() == 3))
                return HandRank.ThreeOfAKind;
            return HandRank.None;
        }

        public Card.CardValue GetHighCard()
        {
            return _cards.Max(x => x.Value);
        }

        public bool IsPair()
        {
            return _cards.GroupBy(card => card.Value).Count() == 4;
        }

        public bool IsTwoPairs()
        {
            return _cards
                       .GroupBy(card => card.Value)
                       .Count(grouping => grouping.Count() == 2) == 2;
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
            Eight,
            Nine,
            King,
            Ace
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
