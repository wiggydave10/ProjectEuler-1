using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solutions.Utils;

namespace Solutions.Problem021
{
    public static class V2
    {
        public static long AmicableSumUnderN(int n)
        {
            var factorSumDict = GetFactorSumDict(n);

            var amicableNumbers = factorSumDict
                .Where(d => IsAmicable(d, factorSumDict))
                .SelectMany(i => new[] {i.Key, i.Value}).Distinct();

            return amicableNumbers.Sum();
        }

        private static Dictionary<int, int> GetFactorSumDict(int n)
        {
            return Enumerable.Range(2, n - 2)
                .Select(i => new { i, FactorSum = (int)FactorUtils.GetProperFactors(i).Sum() })
                .ToDictionary(a => a.i, a => a.FactorSum);
        }

        private static bool IsAmicable(KeyValuePair<int,int> p, Dictionary<int, int> factorSumDict)
        {
            return p.Value > 1
                && p.Key != p.Value
                && factorSumDict.ContainsKey(p.Value)
                && p.Key == factorSumDict[p.Value];
        }
    }
}
