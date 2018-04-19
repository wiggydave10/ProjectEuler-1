using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem029;

namespace UnitTests
{
    [TestClass]
    public class P029DistinctPowers
    {
        [TestMethod]
        public void Version1_DistinctPowers_Practise()
        {
            var range = Enumerable.Range(2, 4).ToArray();
            Assert.AreEqual(15, V1.CountDistinctPowers(range, range));
        }

        [TestMethod]
        public void Version1_DistinctPowers_PatternFinding()
        {
            var range = Enumerable.Range(2, 29).ToArray();
            V1.CountIndistinctPowers(range, range);
        }

        [TestMethod]
        public void Version1_DistinctPowers_Answer()
        {
            var range = Enumerable.Range(2, 99).ToArray();
            Assert.AreEqual(9183, V1.CountDistinctPowers(range, range));
        }
    }
}
