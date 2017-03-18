using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public static class V1
    {
        public static int SumMultiples(int n)
        {
            return GetMultiples(n).Sum();
        }

        private static IEnumerable<int> GetMultiples(int n)
        {
            for (var i = 1; i < n; i++)
            {
                if (i%3 == 0 || i%5 == 0) yield return i;
            }
        }
    }
}
