using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem037;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P037TruncatablePrimes
    {
        [TestMethod]
        public void Version1_Practise()
        {
            var primes = new HashSet<long>(PrimeUtils.Primes.TakeWhile(x => x <= 3797));
            V1.IsTruncatablePrime(3797, primes).ShouldBeTrue();
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Get().Sum().ShouldBe(748317);
        }
    }
}
