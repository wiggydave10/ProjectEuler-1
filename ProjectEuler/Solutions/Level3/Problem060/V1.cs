using System;
using System.Collections.Generic;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem060
{
    /*
        Prime pair sets
        Problem 60 

        The primes 3, 7, 109, and 673, are quite remarkable. 
        By taking any two primes and concatenating them in any order the result will always be prime. 
        For example, taking 7 and 109, both 7109 and 1097 are prime. The sum of these four primes, 792, 
        represents the lowest sum for a set of four primes with this property.

        Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.
    */

    public static class V1
    {
        public static int Main()
        {
            var links = new List<(long p1, long p2)>();

            var primeSet = new HashSet<long>(PrimeUtils.FilePrimes);
            var maxPrime = primeSet.Last();
            var primes = PrimeUtils.FilePrimes.ToArray();
            for (var i = 0; i < primes.Length; i++)
            {
                var p1 = primes[i];
                if (p1 == 2 || p1 == 5) continue;

                for (var j = i+1; j < primes.Length; j++)
                {
                    var p2 = primes[j];
                    if (p2 == 2 || p2 == 5) continue;

                    var p1Str = p1.ToString();
                    var p2Str = p2.ToString();

                    var p1p2 = long.Parse(p1Str + p2Str);
                    var p2p1 = long.Parse(p2Str + p1Str);

                    if (p1p2 < maxPrime)
                    {
                        if (primeSet.Contains(p1p2) && primeSet.Contains(p2p1))
                        {
                            links.Add((p1, p2));
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }

            //var conn3 = ConnectedSignatures3(new HashSet<ValueTuple<long, long>>(links)).ToArray();
            var conn4 = ConnectedSignatures4(new HashSet<ValueTuple<long, long>>(links)).OrderBy(x => x.Item1 + x.Item2 + x.Item3 + x.Item4).ToArray();
            //var conn5 = ConnectedSignatures5(new HashSet<ValueTuple<long, long>>(links)).ToArray();
            return 0;
        }

        public static IEnumerable<(long p1, long p2, long p3)> ConnectedSignatures3(HashSet<(long p1, long p2)> links)
        {
            foreach (var g in links.GroupBy(x => x.p1))
            {
                var pairs = Choose2(g.Select(x => x.p2));
                foreach (var pair in pairs)
                {
                    if (links.Contains(pair) || links.Contains((pair.b, pair.a)))
                    {
                        yield return (g.Key, pair.a, pair.b);
                    }
                }
            }
        }

        private static IEnumerable<(T a, T b)> Choose2<T>(IEnumerable<T> ts)
        {
            var tsArr = ts.ToArray();
            for (var i = 0; i < tsArr.Length; i++)
            {
                for (var j = i + 1; j < tsArr.Length; j++)
                {
                    yield return (tsArr[i], tsArr[j]);
                }
            }
        }

        public static IEnumerable<(long p1, long p2, long p3, long p4)> ConnectedSignatures4(HashSet<(long p1, long p2)> links)
        {
            var conn3 = ConnectedSignatures3(links);
            foreach (var g in conn3.GroupBy(x => new {x.p1, x.p2}))
            {
                var pairs = Choose2(g.Select(x => x.p3));
                foreach (var pair in pairs)
                {
                    if (links.Contains(pair) || links.Contains((pair.b, pair.a)))
                    {
                        yield return (g.Key.p1, g.Key.p2, pair.a, pair.b);
                    }
                }
            }
        }

        public static IEnumerable<(long p1, long p2, long p3, long p4, long p5)> ConnectedSignatures5(HashSet<(long p1, long p2)> links)
        {
            var conn4 = ConnectedSignatures4(links);
            foreach (var g in conn4.GroupBy(x => new { x.p1, x.p2, x.p3 }))
            {
                var pairs = Choose2(g.Select(x => x.p4));
                foreach (var pair in pairs)
                {
                    if (links.Contains(pair) || links.Contains((pair.b, pair.a)))
                    {
                        yield return (g.Key.p1, g.Key.p2, g.Key.p3, pair.a, pair.b);
                    }
                }
            }
        }
    }
}
