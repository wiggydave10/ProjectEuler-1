using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solutions.Utils;

namespace Solutions.Problem023
{
    public static class V1
    {
        public static int NonAbundantSums()
        {
            var ret = new List<int>();
            var abundants = new SortedSet<int>();
            const int limit = 28123;
            for (var i = 1; i <= limit; i++)
            {
                if (HasNoTwoSum(abundants, i)) ret.Add(i);
                if (i.IsAbundant()) abundants.Add(i);
            }

            return ret.Sum();
        }

        public static bool HasNoTwoSum(SortedSet<int> set, int n)
        {
            var lowerHalf = set.GetViewBetween(0, n/2);
            var upperHalf = set.GetViewBetween(n/2, n);
            return lowerHalf.All(t => !upperHalf.Contains(n - t));
        }

        public static bool IsDeficient(this int n)
        {
            return FactorUtils.GetProperFactors(n).Sum() < n;
        }

        public static bool IsPerfect(this int n)
        {
            return FactorUtils.GetProperFactors(n).Sum() == n;
        }

        public static bool IsAbundant(this int n)
        {
            return FactorUtils.GetProperFactors(n).Sum() > n;
        }
    }
}
