using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EulerTools.Numbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DigitHelperTests
    {
        private DigitHelper dHelper;
        private int number;

        public DigitHelperTests()
        {
            dHelper = new DigitHelper();
            number = 1234;
        }

        [TestMethod]
        public void parses_correct_digit()
        {
            int position = 2;
            int expected = 2;
            int result = dHelper.GetDigit(number, position);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void gets_correct_digit_count()
        {
            int expected = 4;
            int result = dHelper.GetDigitCount(number);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void correctly_splits_digits()
        {
            int[] expected = new[] {1, 2, 3, 4};
            int[] result = dHelper.SplitDigits(number).ToArray();
            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], result[i]);
        }

        [TestMethod]
        public void rotator_rotates_digits()
        {
            int input = 197;
            var expectedList = new List<int> {197, 971, 719};
            var results = dHelper.RotateDigits(input).ToList();
            for (int i = 0; i < expectedList.Count; i++)
                Assert.AreEqual(expectedList[i], results[i]);
        }

        [TestMethod]
        public void rotator_rotates_single_digit_number()
        {
            int input = 3;
            var expected = dHelper.RotateNumber(input);
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void rotator_works_with_zeros()
        {
            int input = 100;
            int expectedCount = 3;
            var list = dHelper.RotateDigits(input);
            int result = list.Count();
            Assert.AreEqual(expectedCount, result);
        }

        [TestMethod]
        public void concatenates_single_digit_numbers()
        {
            const int a = 1;
            const int b = 2;
            const int expected = 12;
            int result = dHelper.Concat(a, b);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void concatenates_multi_digit_numbers()
        {
            const int a = 10;
            const int b = 12;
            const int expected = 1012;
            int result = dHelper.Concat(a, b);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void removes_left_most_digit()
        {
            const int input = 1234;
            const int expected = 234;
            int result = dHelper.RemoveLeftMostDigit(input);
            Assert.AreEqual(expected,result);
        }
    }
}
