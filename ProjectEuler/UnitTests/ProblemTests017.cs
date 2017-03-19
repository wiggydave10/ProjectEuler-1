using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem017;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class ProblemTests017
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
