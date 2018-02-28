using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem025;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P025ThousandDigitFibonacciNumber
    {
        [TestMethod]
        public void Version1_FibIndexWithGreaterThanNDigits()
        {
            V1.FibIndexWithGreaterThanNDigits(1000).ShouldBe(4782);
        }
    }
}
