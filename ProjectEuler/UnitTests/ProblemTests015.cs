using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem015;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class ProblemTests015
    {
        [TestMethod]
        public void Version1_LatticePathCount_2()
        {
            Assert.AreEqual((ulong)6, V1.LatticePathCount(2));
        }

        [TestMethod]
        public void Version1_LatticePathCount_3()
        {
            Assert.AreEqual((ulong)20, V1.LatticePathCount(3));
        }

        [TestMethod]
        public void Version1_LatticePathCount_20()
        {
            Assert.AreEqual((ulong)137846528820, V1.LatticePathCount(20));
        }

        [TestMethod]
        public void Version2_LatticePathCount_2()
        {
            Assert.AreEqual((ulong)6, V2.LatticePathCount(2));
        }

        [TestMethod]
        public void Version2_LatticePathCount_3()
        {
            Assert.AreEqual((ulong)20, V2.LatticePathCount(3));
        }

        [TestMethod]
        public void Version2_LatticePathCount_20()
        {
            Assert.AreEqual((ulong)137846528820, V2.LatticePathCount(20));
        }
    }
}
