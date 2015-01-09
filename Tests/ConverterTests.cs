using System;
using EulerTools.Numbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void properly_converts_base10_to_binary()
        {
            var converter = new Converter();
            int input = 585;
            string expected = "1001001001";
            var result = converter.ToBinaryString(input);
            Assert.AreEqual(expected, result);
        }
    }
}
