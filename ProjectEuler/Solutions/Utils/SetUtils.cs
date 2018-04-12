using System.Collections.Generic;
using System.Linq;

namespace Solutions.Utils
{
    public static class SetUtils
    {
        public static T[][] Choose<T>(this IEnumerable<T> set, int n)
        {
            var xs = set.ToArray();
            if (n == 1) return xs.Select(x => new []{x}).ToArray();

            var res = new List<T[]>();

            for (var i = 0; i < xs.Length - 1; i++)
            {
                var xI = new []{xs[i]};
                var r = Choose(xs.Skip(i + 1).ToArray(), n - 1).Select(x => xI.Concat(x).ToArray());
                res.AddRange(r);
            }

            return res.ToArray();
        }

        public static IEnumerable<T[]> LexicographicPermutations<T>(IEnumerable<T> set)
        {
            return Helper(new SortedSet<T>(set).ToArray(), new T[0]);
        }

        public static IEnumerable<T[]> Permutations<T>(IEnumerable<T> set)
        {
            return Helper(set.ToArray(), new T[0]);
        }

        private static T[][] Helper<T>(T[] xs, T[] ys)
        {
            if (!xs.Any()) return new[] { ys };

            return Enumerable.Range(0, xs.Length).SelectMany(i =>
                        Helper(xs.Take(i).Concat(xs.Skip(i + 1)).ToArray(),
                        ys.Concat(new[] { xs.ElementAt(i) }).ToArray())).ToArray();
        }

        private static T[][] Helper<T>(T[] xs, T[] ys, int size)
        {
            if (ys.Length == size) return new[] { ys };

            return Enumerable.Range(0, xs.Length).SelectMany(i =>
                        Helper(xs.Take(i).Concat(xs.Skip(i + 1)).ToArray(),
                        ys.Concat(new[] { xs.ElementAt(i) }).ToArray())).ToArray();
        }
    }
}
