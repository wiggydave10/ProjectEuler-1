using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem031
{
    /*
        In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

        1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
        It is possible to make £2 in the following way:

        1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
        How many different ways can £2 be made using any number of coins?
    */
    public static class V2
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

        public static int TreeBuilding(int n)
        {
            var inital = Enumerable.Repeat(1, n);
        }

        public static int[][] Branch(int[] combination)
        {
            var dict = combination.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var res = new List<int[]>();
            foreach (var coin in CoinChildren)
            {
                var valuesDict = coin.Value.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                if (!new HashSet<int>(valuesDict.Keys).Overlaps(dict.Keys)) continue;
                if (valuesDict.Keys.Any(k => valuesDict[k] > dict[k])) continue;

                var copy = new List<int>();
                copy.AddRange(combination);
                foreach (var value in coin.Value)
                {
                    copy.Remove(value);
                }

                copy.Add(coin.Key);
                res.Add(copy.ToArray());
            }

            return res.ToArray();
        }
    }
}
