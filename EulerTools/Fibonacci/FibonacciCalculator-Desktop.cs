using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Fibonacci
{
    public class FibonacciCalculator
    {
        /// <summary>
        /// Find the fibonacci number that has a digit count of digitCount.
        /// E.g. find the first fibonacci number to contain 1,000 digits.
        /// </summary>
        /// <param name="digitCount"></param>
        /// <returns></returns>
        public BigInteger FindFibonacciToDigitCount(int digitCount)
        {
            BigInteger result = 0;
            BigInteger first = 0;
            BigInteger second = 1;

            var limit = GetBigIntegerOfDigits(digitCount);

            while (result < limit)
                result = ComputeFibonacci(ref first, ref second);
            return result;
        }

        private BigInteger ComputeFibonacci(ref BigInteger first, ref BigInteger second)
        {
            var result = first + second;
            first = second;
            second = result;
            return result;
        }

        /// <summary>
        /// creates a big integer of the smallest number of x digits.
        /// E.g. 4 digits is 1,000.
        /// </summary>
        /// <param name="digitCount"></param>
        /// <returns></returns>
        private BigInteger GetBigIntegerOfDigits(int digitCount)
        {
            var thousandDigitNumberString = GetNumberStringOfDigitCount(digitCount);
            return BigInteger.Parse(thousandDigitNumberString);
        }

        private string GetNumberStringOfDigitCount(int digitCount)
        {
            var builder = new StringBuilder(digitCount);
            builder.Append("1");
            for (int i = 0; i < digitCount - 1; i++)
                builder.Append(0);
            return builder.ToString();
        }
    }
}
