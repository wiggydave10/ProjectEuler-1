using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem015
{
    public static class V2
    {
        public static ulong LatticePathCount(int n)
        {
            var pascalLine = Pascal(n*2);
            return pascalLine.Skip(pascalLine.Count/ 2).First();
        }

        public static IList<ulong> Pascal(int n)
        {
            var line = new List<ulong> { 1 };
            Enumerable.Range(0, n).ToList().ForEach(i => line.Add(line[i] * (ulong)(n - i) / (ulong)(i + 1)));
            return line;
        }
    }
}
