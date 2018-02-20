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
            var frontierStates = new List<int[]>{ Enumerable.Repeat(1, n).ToArray() };
            var allStates = new List<int[]>(frontierStates);

            while (frontierStates.Any())
            {
                var newFrontier = new List<int[]>();
                var smallestGreatest = int.MaxValue;
                foreach (var state in frontierStates.OrderByDescending(x => x.Max()))
                {
                    var maxCoin = state.Max();
                    var choices = CoinChildren.OrderBy(x => x.Key).Where(x => x.Key < smallestGreatest).TakeWhile(x => x.Value.Max() <= maxCoin).Select(x => x.Key);
                    var options = Branch(state, choices);

                    newFrontier.AddRange(options);
                    smallestGreatest = maxCoin;
                }

                frontierStates = newFrontier;
                allStates.AddRange(frontierStates);
            }

            return allStates.Count();
        }

        public static int[][] Branch(int[] combination, IEnumerable<int> choices)
        {
            var dict = combination.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var res = new List<int[]>();
            foreach (var coinKey in choices)
            {
                var children = CoinChildren[coinKey];
                var valuesDict = children.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                if (!new HashSet<int>(valuesDict.Keys).IsSubsetOf(dict.Keys)) continue;
                if (valuesDict.Keys.Any(k => valuesDict[k] > dict[k])) continue;

                var copy = new List<int>();
                copy.AddRange(combination);
                foreach (var value in children)
                {
                    copy.Remove(value);
                }

                copy.Add(coinKey);
                res.Add(copy.ToArray());
            }

            return res.ToArray();
        }
    }
}
