using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Numbers
{
    public class DigitHelper
    {
        /// <summary>
        /// Returns the number in a digit at a particular index position,
        /// starting with 0.
        /// </summary>
        /// <param name="number">One's place is zero</param>
        /// <param name="position"></param>
        /// <example>
        /// <code>
        /// int number = 1234;
        /// int position = 0;
        /// int result = GetDigit(number, digit);
        /// result = 4
        /// </code>
        /// </example>
        /// <returns></returns>
        public int GetDigit(int number, int position)
        {
            // example: number = 1234, position = 2
            // parsenumber /= (int)Math.Pow(10,2)
            // parsenumber = 12
            // result = parseNumber%10
            // result = 2

            int parseNumber = number;
            // reduce the number so that the starting digit is in the first position
            parseNumber /= (int)Math.Pow(10,position); 
            int result = parseNumber%10;
            return result;
        }

        /// <summary>
        /// Returns a collection of each digit separately.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IEnumerable<int> SplitDigits(int number)
        {
            int length = GetDigitCount(number);
            int[] digits = new int[length];
            int parseNu = number;
            for (int i = 0; i < length; i++)
            {
                digits[length - i - 1] = parseNu%10;
                parseNu /= 10;
            }
            return digits;
        }

        /// <summary>
        /// Creates an integer by appending
        /// b to a, such that a = 1, b = 2
        /// results in 12.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Concat(int a, int b)
        {
            int bCount = GetDigitCount(b);
            int result = a*(int) Math.Pow(10, bCount) + b;
            return result;
        }

        ///// <summary>
        ///// Creates a long by appending
        ///// b to a, such that a = 1, b = 2
        ///// results in 12.
        ///// </summary>
        ///// <param name="a"></param>
        ///// <param name="b"></param>
        ///// <returns></returns>
        //public long Concat(long a, int b)
        //{
        //    int bCount = GetDigitCount(b);
        //    long result = a * (long) Math.Pow(10, bCount) + b;
        //    return result;
        //}

        /// <summary>
        /// Returns the number of digits in a number. 
        /// e.g. 1,000 = 4
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int GetDigitCount(int number)
        {
            return (int) Math.Ceiling(Math.Log10(number));
        }

        public int GetDigitCount(long number)
        {
            return (int) Math.Ceiling(Math.Log10(number));
        }

        /// <summary>
        /// Returns all rotations of the digit, including itself.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IEnumerable<int> RotateDigits(int number)
        {
            var numbers = new List<int> {number};
            int digitCount = GetDigitCount(number);

            string current = number.ToString();
            for (int i = 0; i < digitCount; i++)
            {
                current = RotateNumber(current);
                numbers.Add(int.Parse(current));
            }
            return numbers;
        }

        /// <summary>
        /// Takes the leftmost digit and moves it to the right most side. 
        /// 197 -> 971
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        //public int RotateNumber(int number)
        //{
        //    string num = number.ToString();
        //    string output = num.Substring(1) + num[0];
        //    return int.Parse(output);
        //}

        // This method is >2x faster than the string manipulation method.
        /// <summary>
        /// Takes the leftmost digit and moves it to the right most side. 
        /// 197 -> 971
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int RotateNumber(int number)
        {
            if (number < 10) return number;
            int dCount = GetDigitCount(number);
            int leftMost = GetDigit(number, dCount);
            int remaining = RemoveLeftMostDigit(number);
            remaining *= 10 + leftMost;
            return remaining;
        }

        /// <summary>
        /// Takes the leftmost character and moves it to the back of the string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string RotateNumber(string text)
        {
            return text.Substring(1) + text[0];
        }

        /// <summary>
        /// Removes the left-most digit of a positive number, such that
        /// 1234 becomes 234.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int RemoveLeftMostDigit(int num)
        {
            if (num < 10)
                return num;
            int digitCount = GetDigitCount(num);
            return (int)(num % (Math.Pow(10, digitCount - 1)));
        }
    }
}
