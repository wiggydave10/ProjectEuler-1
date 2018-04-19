using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem002;

namespace UnitTests
{
    [TestClass]
    public class P002EvenFibonacciNumbers
    {
        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(4613732, V1.SumEvenFib(100));
        }
    }
}
