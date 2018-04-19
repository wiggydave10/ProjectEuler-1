using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem043;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P043SubstringDivisibility
    {
        [TestMethod]
        public void Version1_Practise()
        {
            V1.HasSubstringDivisibility(MiscUtils.GetDigits(1406357289).Select(x => (long)x)).ShouldBeTrue();
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Get().Sum().ShouldBe(16695334890L);
        }
    }
}
