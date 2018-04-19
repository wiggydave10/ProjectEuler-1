using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem031
{
    /*
        In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

        1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
        It is possible to make £2 in the following way:

        1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
        How many different ways can £2 be made using any number of coins?
    */
    public static class V3
    {
        private static Dictionary<int, int[]> CoinChildren = new Dictionary<int, int[]>
        {
            { 2, new []{ 1, 1 } },
            { 5, new []{ 1, 2, 2 } },
            { 10, new []{ 5, 5 } },
            { 20, new []{10, 10} },
            { 50, new[] {10, 20, 20} },
            { 100, new[] {50, 50} },
            { 200, new []{100, 100} }
        };

        public static void Main(int coin)
        {
            var coinTree = CoinTree(new CoinNode {CoinValue = coin});


        }

        //public static int[][] PrintTree(CoinNode node)
        //{
        //    if (!node.Children.Any()) return new[] {new[] {node.CoinValue}};

        //    node.
        //}

        public static CoinNode CoinTree(CoinNode node)
        {
            if (!CoinChildren.ContainsKey(node.CoinValue)) return node;

            node.Children = CoinChildren[node.CoinValue].Select(x => CoinTree(new CoinNode {CoinValue = x})).ToArray();
            return node;
        }
    }

    public class CoinNode
    {
        public int CoinValue { get; set; }
        public CoinNode[] Children { get; set; }
    }
}
