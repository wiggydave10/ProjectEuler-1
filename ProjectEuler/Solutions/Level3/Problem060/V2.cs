using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
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

    public static class V2
    {
        public static int Main()
        {
            var links = new HashSet<(long p1, long p2)>();

            var primeSet = new HashSet<long>(PrimeUtils.FilePrimes);

            foreach (var prime in PrimeUtils.FilePrimes)
            {
                links.UnionWith(GetLinks(prime, primeSet));
            }

            var currPrime = primeSet.Max();
            for (var i = 0; i < 1000000; i++)
            {
                currPrime = PrimeUtils.NextPrimeBasic(currPrime);
                links.UnionWith(GetLinks(currPrime, primeSet));
                primeSet.Add(currPrime);
            }

            links = new HashSet<(long p1, long p2)>(CompressLinks(links));

            var conn4 = ConnectedSignatures4(links).OrderBy(x => x.Item1 + x.Item2 + x.Item3 + x.Item4).ToArray();
            var conn5 = ConnectedSignatures5(links, conn4).OrderBy(x => x.Item1 + x.Item2 + x.Item3 + x.Item4 + x.Item5).ToArray();

            return 0;
        }

        public static IEnumerable<(long p1, long p2)> GetLinks(long p, HashSet<long> primeSet)
        {
            var pStr = p.ToString();
            for (var i = 1; i < pStr.Length; i++)
            {
                // leading zeros are not allowed
                if (pStr[i] == '0') continue;

                var p1 = long.Parse(pStr.Substring(0, i));
                var p2 = long.Parse(pStr.Substring(i));

                if (primeSet.Contains(p1) && primeSet.Contains(p2))
                {
                    yield return (p1, p2);
                }
            }
        }

        public static IEnumerable<(long p1, long p2)> CompressLinks(HashSet<(long p1, long p2)> links)
        {
            foreach (var l in links)
            {
                if (links.Contains((l.p2, l.p1)))
                {
                    yield return l.p1 <= l.p2 ? (l.p1, l.p2) : (l.p2, l.p1);
                }
            }
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
            foreach (var g in conn3.GroupBy(x => new { x.p1, x.p2 }))
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

        public static IEnumerable<(long p1, long p2, long p3, long p4, long p5)> ConnectedSignatures5(HashSet<(long p1, long p2)> links, IEnumerable<(long p1, long p2, long p3, long p4)> conn4)
        {
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

    public class Graph
    {
        private Links links = new Links();

        public void AddLink(long p1, long p2)
        {
            links.Add(p1, p2);
            links.ShareNode(p1, p2);
        }
    }

    public class Links
    {
        private Dictionary<long, HashSet<long>> links = new Dictionary<long, HashSet<long>>();

        public void Add(long p1, long p2)
        {
            if (links.ContainsKey(p1))
            {
                links[p1].Add(p2);
            }
            else
            {
                links[p1] = new HashSet<long> { p2 };
            }
        }

        public bool HasLink(long p1, long p2)
        {
            return links.ContainsKey(p1)
                   && links[p1].Contains(p2);
        }

        public bool ShareNode(long p1, long p2)
        {
            if (!links.ContainsKey(p1) || !links.ContainsKey(p2))
                return false;

            return links[p1].Overlaps(links[p2]);
        }
    }
}
