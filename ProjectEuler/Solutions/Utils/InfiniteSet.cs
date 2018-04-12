using System.Collections.Generic;

namespace Solutions.Utils
{
    public static class InfiniteSet
    {
        public static IEnumerable<long> NaturalNumbers(bool zeroStart)
        {
            for (var i = (zeroStart) ? 0 : 1; true; i++) yield return i;
        }
    }
}
