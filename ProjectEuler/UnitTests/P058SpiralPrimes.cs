using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem058;

namespace UnitTests
{
    [TestClass]
    public class P058SpiralPrimes
    {
        [TestMethod]
        public void Version1_Practise()
        {
            V1.Main().ShouldBe(26241);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            var regex = new Regex(@"\s+");
            File.WriteAllText(@"G:\Primes\primes.txt", "");

            for (var i = 1; i < 5; i++)
            {
                var str = File.ReadAllText($@"G:\Primes\primes{i}.txt");
                var clean = regex.Replace(str, ",");
                var remake = clean.Split(',').Where(s => !string.IsNullOrEmpty(s));
                var comma = i != 1 ? "," : string.Empty;
                File.AppendAllText(@"G:\Primes\primes.txt", comma + string.Join(",", remake));
            }

        }
    }
}
