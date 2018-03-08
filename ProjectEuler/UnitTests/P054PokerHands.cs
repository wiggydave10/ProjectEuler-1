using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem054;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P054PokerHands
    {
        private const string PokerHandsFile = "../../Resources/Problem054/PokerHands.txt";
        private static Dictionary<char, int> RankMapping = new Dictionary<char, int>
        {
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'T', 10 },
            { 'J', 11 },
            { 'Q', 12 },
            { 'K', 13 },
            { 'A', 14 },
        };

        private static Dictionary<char, Suite> SuiteMapping = new Dictionary<char, Suite>
        {
            {'H', Suite.Heart},
            {'D', Suite.Diamond},
            {'S', Suite.Spade},
            {'C', Suite.Clover},
        };

        private static Card GetCard(string cardStr)
        {
            return new Card(RankMapping[cardStr[0]], SuiteMapping[cardStr[1]]);
        }

        private static Hand GetHand(string handStr)
        {
            return new Hand(handStr.Split(' ').Select(GetCard));
        }

        private static Tuple<Hand, Hand> GetHands(string line)
        {
            var cards = line.Split(' ').Select(GetCard).ToArray();
            return Tuple.Create(new Hand(cards.Take(5)), new Hand(cards.Skip(5)));
        }

        [TestMethod]
        public void Version1_Practise_1()
        {
            var hands = GetHands("5H 5C 6S 7S KD 2C 3S 8S 8D TD");
            var h1 = new V1Hand(hands.Item1);
            var h2 = new V1Hand(hands.Item2);

            (h2 > h1).ShouldBeTrue();
        }

        [TestMethod]
        public void Version1_Practise_2()
        {
            var hands = GetHands("5D 8C 9S JS AC 2C 5C 7D 8S QH");
            var h1 = new V1Hand(hands.Item1);
            var h2 = new V1Hand(hands.Item2);

            (h1 > h2).ShouldBeTrue();
        }

        [TestMethod]
        public void Version1_Practise_3()
        {
            var hands = GetHands("2D 9C AS AH AC 3D 6D 7D TD QD");
            var h1 = new V1Hand(hands.Item1);
            var h2 = new V1Hand(hands.Item2);

            (h2 > h1).ShouldBeTrue();
        }

        [TestMethod]
        public void Version1_Practise_4()
        {
            var hands = GetHands("4D 6S 9H QH QC 3D 6D 7H QD QS");
            var h1 = new V1Hand(hands.Item1);
            var h2 = new V1Hand(hands.Item2);

            (h1 > h2).ShouldBeTrue();
        }

        [TestMethod]
        public void Version1_Practise_5()
        {
            var hands = GetHands("2H 2D 4C 4D 4S 3C 3D 3S 9S 9D");
            var h1 = new V1Hand(hands.Item1);
            var h2 = new V1Hand(hands.Item2);

            (h1 > h2).ShouldBeTrue();
        }

        [TestMethod]
        public void Version1_Practise_RoyalFlush()
        {
            new V1Hand(GetHand("AH KH QH JH TH")).HandType.ShouldBe(PokerHandType.RoyalFlush);
        }

        [TestMethod]
        public void Version1_Practise_StraightFlush()
        {
            new V1Hand(GetHand("9H KH QH JH TH")).HandType.ShouldBe(PokerHandType.StraightFlush);
        }

        [TestMethod]
        public void Version1_Practise_Straight()
        {
            new V1Hand(GetHand("9D KH QH JH TH")).HandType.ShouldBe(PokerHandType.Straight);
        }

        [TestMethod]
        public void Version1_Practise_Flush()
        {
            new V1Hand(GetHand("2H KH QH JH TH")).HandType.ShouldBe(PokerHandType.Flush);
        }

        [TestMethod]
        public void Version1_Practise_4Kind()
        {
            new V1Hand(GetHand("AH AD AS AC 2C")).HandType.ShouldBe(PokerHandType.FourOfAKind);
        }

        [TestMethod]
        public void Version1_Practise_FullHouse()
        {
            new V1Hand(GetHand("AH AD AS 2D 2C")).HandType.ShouldBe(PokerHandType.FullHouse);
        }

        [TestMethod]
        public void Version1_Practise_3Kind()
        {
            new V1Hand(GetHand("AH AD AS 3D 2C")).HandType.ShouldBe(PokerHandType.ThreeOfAKind);
        }

        [TestMethod]
        public void Version1_Practise_2Pair()
        {
            new V1Hand(GetHand("AH AD 3S 3D 2C")).HandType.ShouldBe(PokerHandType.TwoPair);
        }

        [TestMethod]
        public void Version1_Practise_Pair()
        {
            new V1Hand(GetHand("AH AD 4S 3D 2C")).HandType.ShouldBe(PokerHandType.Pair);
        }

        [TestMethod]
        public void Version1_Practise_HighCard()
        {
            new V1Hand(GetHand("AH 8D 4S 3D 2C")).HandType.ShouldBe(PokerHandType.HighCard);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            File.ReadAllLines(PokerHandsFile)
                .Select(GetHands)
                .Select(p => new {H1 = new V1Hand(p.Item1), H2 = new V1Hand(p.Item2)})
                .Count(p => p.H1 > p.H2)
                .ShouldBe(0);
        }
    }
}
