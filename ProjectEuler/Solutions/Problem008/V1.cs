using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem008
{
    public static class V1
    {
        public static long GreatestProduct(int length, IEnumerable<int> ns)
        {
            return GetWindows(length, ns.Select(Convert.ToInt64)).Select(w => w.Aggregate((a, b) => a*b)).Max();
        }

        private static IEnumerable<T[]> GetWindows<T>(int length, IEnumerable<T> xs)
        {
            var list = xs.ToList();
            var offset = 0;
            while (offset + length <= list.Count)
            {
                yield return list.Skip(offset).Take(length).ToArray();
                offset++;
            }
        }
    }
}
