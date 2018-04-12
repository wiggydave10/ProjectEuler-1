using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem050;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P050ConsecutivePrimeSum
    {
        [TestMethod]
        public void Version1_Practise_Under100()
        {
            V1.MaxConsecutivePrimeSum(PrimeUtils.Primes.TakeWhile(x => x < 100)).ShouldBe(41);
        }

        [TestMethod]
        public void Version1_Practise_Under1000()
        {
            V1.MaxConsecutivePrimeSum(PrimeUtils.Primes.TakeWhile(x => x < 1000)).ShouldBe(953);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.MaxConsecutivePrimeSum(PrimeUtils.Primes.TakeWhile(x => x < 1000000)).ShouldBe(997651L);
        }
    }
}
