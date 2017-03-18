using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem3;

namespace UnitTests
{
    [TestClass]
    public class Problem3Tests
    {
        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(5, V1.LargestPrimeFactor(10));
            Assert.AreEqual(29, V1.LargestPrimeFactor(13195));
            Assert.AreEqual(6857, V1.LargestPrimeFactor(600851475143));
        }
    }
}
