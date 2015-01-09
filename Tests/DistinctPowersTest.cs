using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistinctPowers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DistinctPowersTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int lower = 2;
            int upper = 5;
            int expected = 15;
            var result = Program.DistinctPowers(lower, upper, lower, upper);

            Assert.AreEqual(expected, result);
        }
    }
}
