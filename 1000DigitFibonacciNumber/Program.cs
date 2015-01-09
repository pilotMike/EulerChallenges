using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Fibonacci;

namespace _1000DigitFibonacciNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var fib = new FibonacciCalculator();
            var result = fib.FibonnaciTermToDigitCount(1000);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
