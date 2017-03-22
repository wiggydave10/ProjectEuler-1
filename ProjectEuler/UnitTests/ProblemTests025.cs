using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem025;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class ProblemTests025
    {
        [TestMethod]
        public void Version1_FibIndexWithGreaterThanNDigits()
        {
            Assert.AreEqual(4782, V1.FibIndexWithGreaterThanNDigits(1000));
        }
    }
}
