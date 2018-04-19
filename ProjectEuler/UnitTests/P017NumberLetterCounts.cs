using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem017;

namespace UnitTests
{
    [TestClass]
    public class P017NumberLetterCounts
    {
        [TestMethod]
        public void Version1_Wordify_DoubleDigits()
        {
            Assert.AreEqual("thirty-five", V1.Wordify(35));
        }

        [TestMethod]
        public void Version1_Wordify_TrippleDigits()
        {
            Assert.AreEqual("three hundred and thirty-two", V1.Wordify(332));
            Assert.AreEqual("one hundred and fifteen", V1.Wordify(115));
        }

        [TestMethod]
        public void Version1_NumberWordStringLength_To5()
        {
            Assert.AreEqual(19, V1.NumberWordStringLength(5));
        }

        [TestMethod]
        public void Version1_NumberWordStringLength_To1000()
        {
            Assert.AreEqual(21124, V1.NumberWordStringLength(1000));
        }
    }
}
