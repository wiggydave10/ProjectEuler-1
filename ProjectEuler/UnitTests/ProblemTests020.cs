using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem020;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class ProblemTests020
    {
        [TestMethod]
        public void Version1_FactorialDigitCount_10()
        {
            Assert.AreEqual(27, V1.FactorialDigitCount(10));
        }

        [TestMethod]
        public void Version1_FactorialDigitCount_100()
        {
            Assert.AreEqual(648, V1.FactorialDigitCount(100));
        }
    }
}
