using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem001;

namespace UnitTests
{
    [TestClass]
    public class P001Multiples
    {
        [TestMethod]
        public void Version1()
        {
            Assert.AreEqual(23, V1.SumMultiples(10));
            Assert.AreEqual(233168, V1.SumMultiples(1000));
        }

        [TestMethod]
        public void Version1Large()
        {
            Assert.AreEqual(1076060070465310994, V1.SumMultiples(Int32.MaxValue));
        }

        [TestMethod]
        public void Version2()
        {
            Assert.AreEqual(23, V2.SumMultiples(10));
            Assert.AreEqual(233168, V2.SumMultiples(1000));
        }

        [TestMethod]
        public void Version2Large()
        {
            Assert.AreEqual(1076060070465310994, V2.SumMultiples(Int32.MaxValue));
        }
    }
}
