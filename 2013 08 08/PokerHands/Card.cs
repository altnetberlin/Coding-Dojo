namespace PokerHands
{
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