using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem034;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P034DigitFactorials
    {
        [TestMethod]
        public void Version1_Answer()
        {
            V1.Get().Sum().ShouldBe(40730);
        }
    }
}
