using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem026;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P026RecipricalCycles
    {
        [TestMethod]
        public void Utils_Decimals_8()
        {
            Assert.AreEqual("", string.Join("",V1.UnitFractionCycle(8)));
        }

        [TestMethod]
        public void Utils_Decimals_7()
        {
            Assert.AreEqual("142857", string.Join("", V1.UnitFractionCycle(7)));
        }

        [TestMethod]
        public void Version1_UnitFractionBase10LongestCycle_10()
        {
            Assert.AreEqual(7, V1.UnitFractionBase10LongestCycle(10));
        }

        [TestMethod]
        public void Version1_UnitFractionBase10LongestCycle_Answer()
        {
            Assert.AreEqual(983, V1.UnitFractionBase10LongestCycle(1000));
        }
    }
}
