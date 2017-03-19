using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem014;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class ProblemTests014
    {
        [TestMethod]
        public void Version1_FindLongestChainWithStartingNumberLessThanN()
        {
            Assert.AreEqual((uint)9, V1.FindLongestChainWithStartingNumberLessThanN(14));
            Assert.AreEqual((uint)837799, V1.FindLongestChainWithStartingNumberLessThanN(1000000));
        }
    }
}
