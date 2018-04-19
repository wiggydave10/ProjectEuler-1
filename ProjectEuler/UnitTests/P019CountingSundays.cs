using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem019;

namespace UnitTests
{
    [TestClass]
    public class P019CountingSundays
    {
        [TestMethod]
        public void Version1_CountingSundays_local()
        {
            Assert.AreEqual(0, V1.CountingSundays(DateTime.Parse("04/03/2017"), DateTime.Parse("20/03/2017")));
        }

        [TestMethod]
        public void Version1_CountingFirstSundays_local()
        {
            Assert.AreEqual(2, V1.CountingFirstSundays(DateTime.Parse("01/01/2017"), DateTime.Parse("31/12/2017")));
        }

        [TestMethod]
        public void Version1_CountingFirstSundays_Answer()
        {
            Assert.AreEqual(171, V1.CountingFirstSundays(DateTime.Parse("01/01/1901"), DateTime.Parse("31/12/2000")));
        }
    }
}
