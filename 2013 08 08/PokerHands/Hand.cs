using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
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

        public Card.CardValue HighCard
        {
            get { return _cards.Max(x => x.Value); }
        }
    }
}