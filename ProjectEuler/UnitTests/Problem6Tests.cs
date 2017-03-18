using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem6;

namespace UnitTests
{
    [TestClass]
    public class Problem6Tests
    {
        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(2640, V1.SumSquareSumDifference(10));
            Assert.AreEqual(25164150, V1.SumSquareSumDifference(100));
        }
    }
}
