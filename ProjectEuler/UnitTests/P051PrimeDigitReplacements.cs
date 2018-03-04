using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem051;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P051PrimeDigitReplacements
    {
        [TestMethod]
        public void Version1_Practise()
        {
            V1.Replacements(13).ShouldBeNull();
        }

        [TestMethod]
        public void Version1_Practise_6()
        {
            V1.Main().First(x => x.Length == 6).First().ShouldBe(13);
        }

        [TestMethod]
        public void Version1_Practise_7()
        {
            V1.Main().First(x => x.Length == 7).First().ShouldBe(56003);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Main().First(x => x.Length == 8).First().ShouldBe(56003);
        }
    }
}
