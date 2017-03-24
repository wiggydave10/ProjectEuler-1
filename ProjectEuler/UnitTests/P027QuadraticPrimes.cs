using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem027;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P027QuadraticPrimes
    {
        [TestMethod]
        public void Utils_QuadraticPrimeCount_40()
        {
            Assert.AreEqual(40, V1.QuadraticPrimeCount(1, 41));
        }

        [TestMethod]
        public void Utils_QuadraticPrimeCount_80()
        {
            Assert.AreEqual(80, V1.QuadraticPrimeCount(-79, 1601));
        }

        [TestMethod]
        public void Utils_QuadraticPrimes_Answer()
        {
            Assert.AreEqual(-59231, V1.QuadraticPrimes(1000));
        }
    }
}
