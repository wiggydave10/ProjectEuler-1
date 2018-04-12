using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem044;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P044PentagonNumbers
    {
        [TestMethod]
        public void Version1_Answer()
        {
            V1.Get().ShouldBe(5482660L);
        }
    }
}
