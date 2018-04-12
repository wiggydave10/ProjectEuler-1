using System;
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
    public static class V1
    {
        public static int GetCombinations(int n, ISet<int> set)
        {
            var history = new HashSet<long>();
            Helper(n, set, new int[0], history);
            return history.Count;
        }

        private static void Helper(int n, ISet<int> choices, int[] combinations, HashSet<long> history)
        {
            var hash = Hash(choices, combinations);
            if (history.Contains(hash)) return;

            var sum = combinations.Sum();
            if (sum > n) return;
            if (sum == n)
            {
                history.Add(hash);
                return;
            }

            foreach (var choice in choices)
            {
                Helper(n, choices, combinations.Concat(new[] {choice}).ToArray(), history);
            }
        }

        public static bool Equal(int[] c1, int[] c2)
        {
            if (c1.Length != c2.Length) return false;
            if (!new HashSet<int>(c1).Overlaps(new HashSet<int>(c2))) return false;

            var dict1 = c1.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            var dict2 = c2.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            return dict1.Keys.All(k => dict1[k] == dict2[k]);
        }

        public static long Hash(ISet<int> choices, int[] combinations)
        {
            var maxCounts = 500;
            var dict = choices.ToDictionary(x => x, x => 0);
            combinations.GroupBy(x => x).ToList().ForEach(g => dict[g.Key] = g.Count());
            var sum = 0L;
            var i = 0;
            foreach (var choice in choices)
            {
                sum += dict[choice] * (long)Math.Pow(maxCounts, i);
                i++;
            }

            return sum;
        }
    }
}
