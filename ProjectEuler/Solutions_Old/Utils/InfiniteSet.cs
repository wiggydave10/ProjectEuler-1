using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
