using System.Collections.Generic;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem013
{
    public static class V1
    {
        public static IEnumerable<int> FirstNDigitsOfLargeSum(int n, int[][] xs)
        {
            return xs.Aggregate(MiscUtils.Add).Take(n);
        }
    }
}
