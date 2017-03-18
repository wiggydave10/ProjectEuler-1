using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem3;

namespace UnitTests
{
    [TestClass]
    public class Problem3Tests
    {
        [TestMethod]
        public void UtilsTests()
        {
            Assert.AreEqual("2,2,5", string.Join(",",Utils.PrimeFactors(20)));
            Assert.AreEqual("2,2,2,3,3,5,7", string.Join(",",Utils.PrimeFactors(2520)));
        }

        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(5, V1.LargestPrimeFactor(10));
            Assert.AreEqual(29, V1.LargestPrimeFactor(13195));
            Assert.AreEqual(6857, V1.LargestPrimeFactor(600851475143));
        }
    }
}
