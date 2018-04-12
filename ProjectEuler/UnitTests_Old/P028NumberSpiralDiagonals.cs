using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem028;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P028NumberSpiralDiagonals
    {
        [TestMethod]
        public void Version1_NumberSpiralDiagonalsSum_3()
        {
            Assert.AreEqual(25, V1.NumberSpiralDiagonalsSum(3));
        }

        [TestMethod]
        public void Version1_NumberSpiralDiagonalsSum_5()
        {
            Assert.AreEqual(101, V1.NumberSpiralDiagonalsSum(5));
        }

        [TestMethod]
        public void Version1_NumberSpiralDiagonalsSum_Answer()
        {
            Assert.AreEqual(669171001, V1.NumberSpiralDiagonalsSum(1001));
        }

        [TestMethod]
        public void Version2_NumberSpiralDiagonalsSum_Answer()
        {
            Assert.AreEqual(669171001, V2.NumberSpiralDiagonalsSum(1001));
        }

        [TestMethod]
        public void Version3_NumberSpiralDiagonalsSum_Answer()
        {
            Assert.AreEqual(669171001, V3.NumberSpiralDiagonalsSum(1001));
        }
    }
}
