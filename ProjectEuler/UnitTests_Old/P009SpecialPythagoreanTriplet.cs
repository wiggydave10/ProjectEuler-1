using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem009;

namespace UnitTests
{
    [TestClass]
    public class P009SpecialPythagoreanTriplet
    {
        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(31875000, V1.Answer());
        }
    }
}
