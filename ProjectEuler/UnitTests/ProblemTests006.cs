using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem006;

namespace UnitTests
{
    [TestClass]
    public class ProblemTests006
    {
        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(2640, V1.SumSquareSumDifference(10));
            Assert.AreEqual(25164150, V1.SumSquareSumDifference(100));
        }
    }
}
