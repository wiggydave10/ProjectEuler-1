using System.Collections.Generic;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem054
{
    /*
        Poker hands
        Problem 54 
        In the card game poker, a hand consists of five cards and are ranked, from lowest to highest, in the following way:

        High Card: Highest value card.
        One Pair: Two cards of the same value.
        Two Pairs: Two different pairs.
        Three of a Kind: Three cards of the same value.
        Straight: All cards are consecutive values.
        Flush: All cards of the same suit.
        Full House: Three of a kind and a pair.
        Four of a Kind: Four cards of the same value.
        Straight Flush: All cards are consecutive values of same suit.
        Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.
        The cards are valued in the order:
        2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace.

        If two players have the same ranked hands then the rank made up of the highest value wins; 
        for example, a pair of eights beats a pair of fives (see example 1 below). But if two ranks tie, 
        for example, both players have a pair of queens, then highest cards in each hand are compared (see example 4 below); 
        if the highest cards tie then the next highest cards are compared, and so on.

        Consider the following five hands dealt to two players:

        Hand	 	Player 1	 	Player 2	 	Winner
        1	 	5H 5C 6S 7S KD   2C 3S 8S 8D TD    Player 2
                 Pair of Fives    Pair of Eights

        2	 	2C 5C 7D 8S QH   2C 3S 8S 8D TD    Player 1
                 Highest card Ace    Highest card Queen

        3	 	2D 9C AS AH AC   3D 6D 7D TD QD    Player 2
                 Three Aces     Flush with Diamonds

        4	 	4D 6S 9H QH QC  4D 6S 9H QH QC    Player 1
                 Pair of Queens    Pair of Eights

        5	 	5H 5C 6S 7S KD   3C 3D 3S 9S 9D    Player 1
                 Full House        Full House
               With Three Fours  with Three Threes
        
        The file, poker.txt, contains one-thousand random hands dealt to two players. 
        Each line of the file contains ten cards (separated by a single space): 
        the first five are Player 1's cards and the last five are Player 2's cards. 
        You can assume that all hands are valid (no invalid characters or repeated cards), 
        each player's hand is in no specific order, and in each hand there is a clear winner.

        How many hands does Player 1 win?
    */

    public class V1Hand : Hand
    {
        public V1Hand(Hand hand) : base(hand.Cards)
        {
        }

        public V1Hand(IEnumerable<Card> cards) : base(cards)
        {
        }

        public PokerHandType HandType => GetPokerHandType(this);

        public static PokerHandType GetPokerHandType(V1Hand hand)
        {
            var isFlush = IsFlush(hand);
            var isStraight = IsStraight(hand);

            if (isStraight && isFlush)
            {
                return hand.Cards.Min(x => x.Rank) == 10 ? PokerHandType.RoyalFlush : PokerHandType.StraightFlush;
            }

            var rankDic = hand.Cards.GroupBy(x => x.Rank).ToDictionary(x => x.Key, x => x.Count());
            var uniqueRankCount = rankDic.Keys.Count;
            var mostOfRank = rankDic.Max(x => x.Value);

            if (uniqueRankCount == 2)
            {
                return mostOfRank == 4 ? PokerHandType.FourOfAKind : PokerHandType.FullHouse;
            }

            if (isFlush)
                return PokerHandType.Flush;

            if (isStraight)
                return PokerHandType.Straight;

            if (mostOfRank == 3)
                return PokerHandType.ThreeOfAKind;

            var pairCount = rankDic.Values.Count(x => x == 2);

            if (pairCount == 2)
                return PokerHandType.TwoPair;
            else if (pairCount == 1)
                return PokerHandType.Pair;
            
            return PokerHandType.HighCard;
        }

        private static bool IsFlush(V1Hand hand)
        {
            return hand.Cards.All(x => x.Suite == hand.Cards[0].Suite);
        }

        private static bool IsStraight(V1Hand hand)
        {
            return hand.Cards.Select(x => x.Rank).OrderBy(x => x).IsConsecutive();
        }

        public static bool operator <(V1Hand h1, V1Hand h2)
        {
            return h2 > h1;
        }

        public static bool operator >(V1Hand h1, V1Hand h2)
        {
            if (h1.HandType != h2.HandType) return h1.HandType > h2.HandType;

            var h1Ranks = h1.Cards.GroupBy(x => x.Rank).OrderByDescending(x => x.Count()).ThenByDescending(x => x.Key).Select(x => x.Key);
            var h2Ranks = h2.Cards.GroupBy(x => x.Rank).OrderByDescending(x => x.Count()).ThenByDescending(x => x.Key).Select(x => x.Key);

            var fstDiff = h1Ranks.Zip(h2Ranks, (a, b) => new { Rank1 = a, Rank2 = b }).FirstOrDefault(x => x.Rank1 != x.Rank2);
            return fstDiff != null && fstDiff.Rank1 > fstDiff.Rank2;
        }
    }
}
