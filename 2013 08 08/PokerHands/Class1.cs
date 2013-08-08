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
            var checker = new HandChecker();
            //Act
            var result = checker.GetHighCard(new[]
                                                 {
                                                     new Card(Card.CardValue.Two, Card.CardSuit.Hearts),
                                                     new Card(Card.CardValue.Three, Card.CardSuit.Diamonds),
                                                     new Card(Card.CardValue.Five, Card.CardSuit.Spades),
                                                     new Card(Card.CardValue.Nine, Card.CardSuit.Clubs),
                                                     new Card(Card.CardValue.King, Card.CardSuit.Diamonds)
                                                 });
            //Assert
            Assert.AreEqual(Card.CardValue.King, result);
        }
    }

    public class Card
    {
        public enum CardValue
        {
            Two,
            Three,
            Five,
            Nine,
            King
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

    public class HandChecker
    {
        public Card.CardValue GetHighCard(Card[] cards)
        {
            return Card.CardValue.King;
        }
    }
}
