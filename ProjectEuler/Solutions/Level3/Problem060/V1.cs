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

            var primes = PrimeUtils.Primes.TakeWhile(x => x <= 673).ToArray();
            for (var i = 0; i < primes.Length; i++)
            {
                for (var j = i+1; j < primes.Length; j++)
                {
                    var p1 = primes[i];
                    var p2 = primes[j];

                    var p1p2 = int.Parse(p1.ToString() + p2.ToString());
                    var p2p1 = int.Parse(p2.ToString() + p1.ToString());


                }
            }
        }
    }
}
