using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem054
{
    public struct Card
    {
        public Card(int rank, Suite suite)
        {
            Rank = rank;
            Suite = suite;
        }

        public int Rank { get; }
        public Suite Suite { get; }

        public override string ToString()
        {
            return $"{Rank}{Suite.ToString()[0]}";
        }
    }

    public enum Suite
    {
        Heart,
        Diamond,
        Spade,
        Clover
    }

    public class Hand
    {
        public Hand(IEnumerable<Card> cards)
        {
            Cards = cards.Take(5).ToArray();
            if (Cards.Length != 5) throw new Exception("Hand must be 5 cards");
        }

        public Card[] Cards { get; }

        public override string ToString()
        {
            return string.Join(" ", Cards);
        }
    }

    public enum PokerHandType
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }
}
