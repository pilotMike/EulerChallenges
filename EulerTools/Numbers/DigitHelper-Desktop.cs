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
        /// Returns the number of digits in a number. 
        /// e.g. 1,000 = 4
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int GetDigitCount(int number)
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
        public int RotateNumber(int number)
        {
            string num = number.ToString();
            string output = num.Substring(1) + num[0];
            return int.Parse(output);
        }

        public string RotateNumber(string text)
        {
            return text.Substring(1) + text[0];
        }
    }
}
