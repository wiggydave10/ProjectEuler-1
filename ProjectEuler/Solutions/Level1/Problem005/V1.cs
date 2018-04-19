using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem005
{
    public static class V1
    {
        public static long SmallestMultiple(HashSet<int> factors)
        {
            var n = 1;
            while (factors.Any(f => n%f != 0))
            {
                n++;
            }

            return n;
        }
    }
}
