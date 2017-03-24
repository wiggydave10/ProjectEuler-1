using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem016;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P016PowerDigitSum
    {
        [TestMethod]
        public void Version1_Sum2PowDigits_15()
        {
            Assert.AreEqual(26, V1.Sum2PowDigits(15));
        }

        [TestMethod]
        public void Version1_Sum2PowDigits_1000()
        {
            Assert.AreEqual(1366, V1.Sum2PowDigits(1000));
        }


    }
}
