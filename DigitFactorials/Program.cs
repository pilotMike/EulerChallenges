using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Numbers;
using EulerTools.Program;

namespace DigitFactorials
{
    public class Program
    {
        // Note: ! = factorial, as in x times every number lower than it.
        // E.G. 4! = 4x3x2x1 = 24

        //145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

        //Find the sum of all numbers which are equal to the sum of the factorial of their digits.

        //Note: as 1! = 1 and 2! = 2 are not sums they are not included.

        static void Main(string[] args)
        {
            Benchmarker b = new Benchmarker();
            b.Benchmark(Do);
            Console.ReadLine();
        }


        public static void Do()
        {
            var factorialHelper = new FactorialHelper();
            var factorials = new List<int>();
            const int limit = 40586; // originally 100,000, but solved for 40585
            const int start = 3;

            for (int i = start; i < limit; i++)
                if (factorialHelper.NumberEqualsSumOfDigitFactorials(i))
                    factorials.Add(i);
                
            Console.WriteLine(factorials.Sum());
        }
    }
}
