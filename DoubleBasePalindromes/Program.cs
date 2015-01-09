using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Numbers;
using EulerTools.Program;

namespace DoubleBasePalindromes
{
    class Program
    {
        //The decimal number, 585 = 1001001001 (base 2) (binary), is palindromic in both bases.

        //Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

        //(Please note that the palindromic number, in either base, may not include leading zeros.)

        // convert to binary: Convert.ToString(num, 2);

        private const int Limit = 1000000;

        static void Main(string[] args)
        {
            var benchmarker = new Benchmarker();
            benchmarker.Benchmark(Do);
            Console.ReadLine();
        }

        private static void Do()
        {
            var converter = new Converter();
            var palindromeHelper = new PalindromeHelper();
            int sum = 0;

            for (int i = 1; i < Limit; i++)
                if (palindromeHelper.IsPalindrome(i) && 
                    palindromeHelper.IsPalindrome(converter.ToBinaryString(i)))
                    sum += i;

            Console.WriteLine(sum);
        }
    }
}
