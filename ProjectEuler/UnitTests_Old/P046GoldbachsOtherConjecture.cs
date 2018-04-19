using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem046;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P046GoldbachsOtherConjecture
    {
        [TestMethod]
        public void Version1_Practise()
        {
            V1.SatisfiesConjecture(9, new SortedSet<long>(), new SortedSet<long>()).ShouldBeTrue();
            V1.SatisfiesConjecture(15, new SortedSet<long>(), new SortedSet<long>()).ShouldBeTrue();
            V1.SatisfiesConjecture(21, new SortedSet<long>(), new SortedSet<long>()).ShouldBeTrue();
            V1.SatisfiesConjecture(25, new SortedSet<long>(), new SortedSet<long>()).ShouldBeTrue();
            V1.SatisfiesConjecture(27, new SortedSet<long>(), new SortedSet<long>()).ShouldBeTrue();
            V1.SatisfiesConjecture(33, new SortedSet<long>(), new SortedSet<long>()).ShouldBeTrue();
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Main().ShouldBe(5777);
        }
    }
}
