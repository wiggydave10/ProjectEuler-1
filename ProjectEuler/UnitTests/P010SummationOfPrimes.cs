using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P010SummationOfPrimes
    {
        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(17, PrimeUtils.Primes.TakeWhile(p => p < 10).Sum());
            Assert.AreEqual(142913828922, PrimeUtils.Primes.TakeWhile(p => p < 2000000).Sum());
        }
    }
}
