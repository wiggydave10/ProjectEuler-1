using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Utils
{
    public static class TriangleNumberUtils
    {
        public static IEnumerable<long> TriangleNumbers => GetTriangleNumbers();

        private static IEnumerable<long> GetTriangleNumbers()
        {
            var i = 1;
            var prev = 0;

            while (true)
            {
                var curr = prev + i;
                yield return curr;
                i++;
                prev = curr;
            }
        }
    }
}
