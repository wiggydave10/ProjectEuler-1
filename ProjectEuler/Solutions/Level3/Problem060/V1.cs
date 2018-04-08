using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
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

    public static class V1
    {
        public static int Main()
        {
            var links = new List<(long p1, long p2)>();

            var primeSet = new HashSet<long>(PrimeUtils.FilePrimes.TakeWhile(x => x <= 999999));
            var primes = PrimeUtils.FilePrimes.TakeWhile(x => x <= 999).ToArray();
            for (var i = 0; i < primes.Length; i++)
            {
                for (var j = i+1; j < primes.Length; j++)
                {
                    var p1 = primes[i];
                    var p2 = primes[j];

                    var p1p2 = long.Parse(p1.ToString() + p2.ToString());
                    var p2p1 = long.Parse(p2.ToString() + p1.ToString());

                    if (primeSet.Contains(p1p2) && primeSet.Contains(p2p1))
                    {
                        links.Add((p1, p2));
                    }
                }
            }

            var conn3 = ConnectedSignatures3(links).ToArray();
            var conn4 = ConnectedSignatures4(links).ToArray();
            var conn5 = ConnectedSignatures5(links).ToArray();
            return 0;
        }

        public static IEnumerable<(long p1, long p2, long p3)> ConnectedSignatures3(List<(long p1, long p2)> links)
        {
            foreach (var g in links.GroupBy(x => x.p1))
            {
                var p2Pairs = g.Select(x => x.p2).Choose(2);
                foreach (var pair in p2Pairs)
                {
                    var l = (pair.Min(), pair.Max());
                    if (links.Contains(l))
                    {
                        yield return (g.Key, l.Item1, l.Item2);
                    }
                }
            }
        }

        public static IEnumerable<(long p1, long p2, long p3, long p4)> ConnectedSignatures4(List<(long p1, long p2)> links)
        {
            var conn3 = ConnectedSignatures3(links);
            foreach (var g in conn3.GroupBy(x => new {x.p1, x.p2}))
            {
                var p2Pairs = g.Select(x => x.p3).Choose(2);
                foreach (var pair in p2Pairs)
                {
                    var l = (pair.Min(), pair.Max());
                    if (links.Contains(l))
                    {
                        yield return (g.Key.p1, g.Key.p2, l.Item1, l.Item2);
                    }
                }
            }
        }

        public static IEnumerable<(long p1, long p2, long p3, long p4, long p5)> ConnectedSignatures5(List<(long p1, long p2)> links)
        {
            var conn3 = ConnectedSignatures4(links);
            foreach (var g in conn3.GroupBy(x => new { x.p1, x.p2, x.p3 }))
            {
                var p2Pairs = g.Select(x => x.p4).Choose(2);
                foreach (var pair in p2Pairs)
                {
                    var l = (pair.Min(), pair.Max());
                    if (links.Contains(l))
                    {
                        yield return (g.Key.p1, g.Key.p2, g.Key.p3, l.Item1, l.Item2);
                    }
                }
            }
        }
    }
}
