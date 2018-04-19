using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem015
{
    public static class V2
    {
        public static ulong LatticePathCount(int n)
        {
            return Pascal(n * 2)[n];
        }

        public static IList<ulong> Pascal(int n)
        {
            var line = new List<ulong> { 1 };
            Enumerable.Range(0, n).ToList().ForEach(i => line.Add(line[i] * (ulong)(n - i) / (ulong)(i + 1)));
            return line;
        }
    }
}
