using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DigitFifthPowersTest
    {
        [TestMethod]
        public void properly_sums_4th_digit_powers()
        {
            const int expectedSum = 19316;
            const int digits = 4;
            int result = DigitFifthPowers.Program.Process(digits);

            Assert.AreEqual(expectedSum, result);
        }
    }
}
