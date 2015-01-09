using System;
using EulerTools.Primes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PrimeCalculatorTests
    {
        PrimeCalculator pC = new PrimeCalculator();

        [TestMethod]
        public void prime_number_is_prime_compared_to_itself()
        {
            int prime = 23;
            bool result = pC.IsPrime(prime);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void non_prime_number_is_false()
        {
            int num = 9;
            bool result = pC.IsPrime(num);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void one_is_not_prime()
        {
            int num = 1;
            bool result = pC.IsPrime(num);
            Assert.AreEqual(false,result);
        }
    }
}
