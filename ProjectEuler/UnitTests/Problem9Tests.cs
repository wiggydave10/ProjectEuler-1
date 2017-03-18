using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem9;

namespace UnitTests
{
    [TestClass]
    public class Problem9Tests
    {
        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(31875000, V1.Answer());
        }
    }
}
