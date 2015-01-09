using System;
using EulerTools.Numbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FactorialHelperTests
    {
        private FactorialHelper fHelper;

        public FactorialHelperTests()
        {
            fHelper = new FactorialHelper();
        }

        [TestMethod]
        public void properly_computes_factorials()
        {
            int test = 4;
            int expected = 24;
            int result = fHelper.GetFactorial(test);
            Assert.AreEqual(expected, result);
        }
    }
}
