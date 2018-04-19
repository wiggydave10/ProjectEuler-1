using System;
using System.Collections.Generic;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem008
{
    public static class V1
    {
        public static long GreatestProduct(int length, IEnumerable<int> ns)
        {
            return ns.Select(Convert.ToInt64).GetWindows(length).Select(w => w.Aggregate((a, b) => a*b)).Max();
        }
    }
}
