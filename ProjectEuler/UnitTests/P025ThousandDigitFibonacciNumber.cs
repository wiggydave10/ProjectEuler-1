using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem025;

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