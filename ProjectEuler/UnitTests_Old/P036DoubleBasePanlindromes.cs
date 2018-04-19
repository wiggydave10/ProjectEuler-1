using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem036;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P036DoubleBasePalindromes
    {
        [TestMethod]
        public void Version1_Practise()
        {
            var decimalPalindrome = new[] {5, 8, 5};
            var binaryPalindrome = new[] {1, 0, 0, 1, 0, 0, 1, 0, 0, 1};
            V1.IsPalindromic(decimalPalindrome).ShouldBeTrue();
            V1.IsPalindromic(binaryPalindrome).ShouldBeTrue();
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Get(1000000).Sum().ShouldBe(872187);
        }
    }
}
