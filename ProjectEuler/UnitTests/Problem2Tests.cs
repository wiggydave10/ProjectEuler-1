using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem2;

namespace UnitTests
{
    [TestClass]
    public class Problem2Tests
    {
        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(4613732, V1.SumEvenFib(100));
        }
    }
}
