using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem005;

namespace UnitTests
{
    [TestClass]
    public class P005SmallestMultiple
    {
        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(2520, V1.SmallestMultiple(new HashSet<int>(Enumerable.Range(1, 9))));
            Assert.AreEqual(232792560, V1.SmallestMultiple(new HashSet<int>(Enumerable.Range(1, 19))));
        }

        [TestMethod]
        public void Version2Tests()
        {
            Assert.AreEqual(2520, V2.SmallestMultiple(new HashSet<int>(Enumerable.Range(1, 9))));
            Assert.AreEqual(232792560, V2.SmallestMultiple(new HashSet<int>(Enumerable.Range(1, 19))));
        }
    }
}
