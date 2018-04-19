using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem021
{
    public static class V1
    {
        public static long AmicableSumUnderN(int n)
        {
            var factorSumDict = Enumerable.Range(2, n - 2).Select(i => new {i, FactorSum = (int)FactorUtils.GetProperFactors(i).Sum() })
                .Where(p => p.FactorSum > 1).ToDictionary(a => a.i, a => a.FactorSum);

            var amicableNumbers = factorSumDict
                .Where(d => factorSumDict.ContainsKey(d.Value) && d.Key == factorSumDict[d.Value] && d.Key != d.Value)
                .SelectMany(i => new[] {i.Key, i.Value}).Distinct().ToList();

            return amicableNumbers.Sum();
        }
    }
}
