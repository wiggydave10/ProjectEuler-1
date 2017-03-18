using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem004;

namespace UnitTests
{
    [TestClass]
    public class ProblemTests004
    {
        [TestMethod]
        public void RangeTests()
        {
            Assert.AreEqual(3, Enumerable.Range(0,3).Count());
        }

        [TestMethod]
        public void GetDigitsTests()
        {
            Assert.AreEqual("4321", string.Join("",Utils.GetDigits(1234)), "1234");
        }

        [TestMethod]
        public void IsPalendromeTests()
        {
            Assert.AreEqual(true, Utils.IsPalendrome(2), "2");
            Assert.AreEqual(false, Utils.IsPalendrome(11121), "11121");
            Assert.AreEqual(true, Utils.IsPalendrome(11), "11");
            Assert.AreEqual(false, Utils.IsPalendrome(12), "12");
            Assert.AreEqual(true, Utils.IsPalendrome(121), "121");
            Assert.AreEqual(true, Utils.IsPalendrome(99), "99");
            Assert.AreEqual(true, Utils.IsPalendrome(9009), "9009");
        }

        [TestMethod]
        public void Version1Tests()
        {
            Assert.AreEqual(9009, V1.LargestPalindrome(2));
            Assert.AreEqual(906609, V1.LargestPalindrome(3));
        }
    }
}
