using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitFifthPowers
{
    public class Program
    {
        //Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

        //1634 = 1^4 + 6^4 + 3^4 + 4^4
        //8208 = 8^4 + 2^4 + 0^4 + 8^4
        //9474 = 9^4 + 4^4 + 7^4 + 4^4

        //As 1 = 1^4 is not a sum it is not included.

        //The sum of these numbers is 1634 + 8208 + 9474 = 19316.

        //Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.

        static void Main(string[] args)
        {
            var result = Process(5);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static int Process(int digits)
        {
            var all = new List<int>();

            var products = PopulatePowers(digits);
            var upperLimit = GetUpperLimit(digits);
            var lowerLimit = GetLowerLimit(digits);

            // start at 11...12 to exclude all 1's
            for (int i = lowerLimit + 1; i < upperLimit; i++)
            {
                string number = i.ToString();
                // get the sum of each digit raised to the
                // power of the number of digits
                int result = number.Sum(c => products[c]);
                if (result == i)
                    all.Add(result);
            }

            return all.Sum();
        }

        /// <summary>
        /// Populates a dictionary of 1-9 to the fifth power so that
        /// the math doesn't need to be done repeatedly.
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        private static Dictionary<char, int> PopulatePowers(int digits)
        {
            var products = new Dictionary<char, int>();
            for (int i = 0; i < 10; i++)
                products[i.ToString()[0]] = (int) Math.Pow(i, digits);
            return products;
        }

        private static int GetUpperLimit(int digits)
        {
            string upper = "1";
            for (int i = 0; i < digits; i++)
                upper += "0";
            
            return int.Parse(upper);
        }

        private static int GetLowerLimit(int digits)
        {
            string lower = "";
            for (int i = 0; i < digits; i++)
                lower += "1";

            return int.Parse(lower);
        }
    }
}
