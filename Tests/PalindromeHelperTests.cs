using System;
using EulerTools.Numbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PalindromeHelperTests
    {
        [TestMethod]
        public void odd_digit_palindromes_return_true()
        {
            const int input = 585;
            const bool expected = true;

            var pHelper = new PalindromeHelper();
            bool result = pHelper.IsPalindrome(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void even_digit_palindromes_return_true()
        {
            const int input = 2222;
            const bool expected = true;

            var pHelper = new PalindromeHelper();
            bool result = pHelper.IsPalindrome(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void odd_digit_non_palindromes_return_false()
        {
            const int input = 123;
            const bool expected = false;

            var pHelper = new PalindromeHelper();
            bool result = pHelper.IsPalindrome(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void even_digit_non_palindromes_return_false()
        {
            const int input = 1234;
            const bool expected = false;

            var pHelper = new PalindromeHelper();
            bool result = pHelper.IsPalindrome(input);
            Assert.AreEqual(expected, result);
        }
    }
}
