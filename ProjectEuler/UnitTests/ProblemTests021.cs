using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem021;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class ProblemTests021
    {
        [TestMethod]
        public void Version1_FactorialDigitCount_10()
        {
            Assert.AreEqual(31626, V1.AmicableSumUnderN(10000));
        }
    }
}
