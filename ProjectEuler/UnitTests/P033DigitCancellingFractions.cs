using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem033;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P033DigitCancellingFractions
    {
        [TestMethod]
        public void Version1_Get()
        {
            var f = V1.Get().Aggregate((a, b) => a * b); // simplest 1/100
        }
    }
}
