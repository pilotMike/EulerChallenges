using System;
using System.Numerics;
using EulerTools.Fibonacci;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FibonacciCalculatorTests
    {
        FibonacciCalculator fib = new FibonacciCalculator();

        [TestMethod]
        public void big_integer_limit_is_proper_digit_length()
        {
            const int limit = 1000;
            var result = fib.GetBigIntegerOfDigits(limit).ToString();
            Assert.AreEqual(result.Length, limit);
        }

        [TestMethod]
        public void properly_computes_fibonacci()
        {
            const int iterations = 12;
            const int expected = 144;

            BigInteger first = 0;
            BigInteger second = 1;
            BigInteger result = 0;
            for (int i = 0; i < iterations - 1; i++)
                result = fib.ComputeFibonacci(ref first, ref second);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void find_fibonacci_count_performs_proper_number_of_iterations()
        {
            const int digitCount = 3;
            const int expected = 144;

            var result = fib.FindFibonacciToDigitCount(digitCount);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void finds_term_of_sequence_with_x_digits()
        {
            const int digitCount = 3;
            const int expected = 12;
            int result = fib.FibonnaciTermToDigitCount(3);
            Assert.AreEqual(expected, result);
        }
    }
}
