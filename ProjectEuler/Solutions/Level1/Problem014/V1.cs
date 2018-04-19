using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem014
{
    public static class V1
    {

        public static ulong FindLongestChainWithStartingNumberLessThanN(uint n)
        {
            // dictionary of starting N and length of chain
            var visited = new Dictionary<ulong, int>();
            for (uint i = 1; i < n; i++)
            {
                var visitedChainLength = 0;
                var previousCollatzs = new List<ulong>();
                foreach (var c in CollatzSequence(i))
                {
                    if (visited.ContainsKey(c))
                    {
                        visitedChainLength = visited[c];
                        break;
                    }
                    previousCollatzs.Add(c);
                }

                previousCollatzs.Reverse();
                for (var j = 0; j < previousCollatzs.Count; j++)
                {
                    visited.Add(previousCollatzs[j], visitedChainLength + j + 1);
                }
            }

            return visited.OrderByDescending(v => v.Value).First().Key;
        }

        public static IEnumerable<ulong> CollatzSequence(uint n)
        {
            while (n != 1)
            {
                yield return n;
                if (n%2 == 0) n /= 2;
                else n = 3*n + 1;
            }

            yield return 1;
        }
    }
}
