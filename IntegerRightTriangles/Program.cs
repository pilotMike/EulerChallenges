using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Program;

namespace IntegerRightTriangles
{
    class Program
    {
        //If p is the perimeter of a right angle triangle with integral 
        //length sides, {a,b,c}, there are exactly three solutions for p = 120.

        //{20,48,52}, {24,45,51}, {30,40,50}

        //For which value of p ≤ 1000, is the number of solutions maximised?

        // I originally tried using the formula
        // taking ints m, n, where m>n,
        // 2mn, m*m-n*n, m*m+n*n to get the sides of
        // the right triangles, but this didn't get
        // triangles where the sides had a prime number.
        // So, it turns out that brute forcing a and b in
        // the formular a*a+b*b=c*c is the best way to go.

        const int Limit = 1000;
        static void Main(string[] args)
        {
            var b = new Benchmarker();
            b.Benchmark(Do);
            Console.ReadLine();
        }

        private static void Do()
        {
            var perimeters = new Dictionary<int, int>();

            // chose 500 for the limit because, in the example,
            // the sides never exceed more than a little less than
            // half of the perimeter. so I chose 1/2 of 1,000.
            for (int a = 0; a < 500; a++) 
                for (int b = 0; b < 500; b++)
                {
                    int cSquared = a*a + b*b;
                    double croot = Math.Sqrt(cSquared);
                    if (croot%1 != 0) continue; // if croot is not an int, continue.

                    int sum = a + b + (int) croot;
                    if (sum > Limit) break;
                    if (!perimeters.ContainsKey(sum))
                        perimeters.Add(sum, 0);
                    perimeters[sum]++;
                }

            var maxKey = perimeters.Aggregate((previous, next) => next.Value > previous.Value ? next : previous).Key;
            Console.WriteLine(maxKey);
        }



        #region FirstAttempt
        //private static void FirstWay()
        //{
        //    var perimeters = new Dictionary<int, int>();

        //    for (int m = 1; m < 10000; m++)
        //    {
        //        int perimeter = 0;
        //        for (int n = 1; n < m; n++)
        //        {
        //            perimeter = Perimeter(m, n);
        //            if (perimeter > Limit) continue;

        //            if (!perimeters.ContainsKey(perimeter))
        //            {
        //                perimeters.Add(perimeter, 0);
        //                //Console.WriteLine(perimeter);
        //            }
        //            perimeters[perimeter]++;
        //            //Console.WriteLine(2*m*n + "\t" + (m*m-n*n) + "\t" + (m*m+n*n) + " = " + perimeter);
        //        }
        //    }


        //    //Console.WriteLine(perimeters[120]);
        //    var maxKey = perimeters.Aggregate((previous, next) => next.Value > previous.Value ? next : previous).Key;
        //        //perimeters.Max(p => p.Value);
        //    //Console.WriteLine(maxKey);

        //    var sorted = perimeters.OrderBy(p => p.Value);
        //    foreach (var keyValuePair in sorted)
        //    {
        //        Console.WriteLine(keyValuePair.Key + "\t" + keyValuePair.Value);
        //    }
        //}

        ///// <summary>
        ///// Returns the perimeter of a right triangle where
        ///// m > n using formula 2mn, m^2-n^2, m^2+n^2 to determine
        ///// side a, side b, and side c for the right triangle equation
        ///// a^2+b^2=c^2.
        ///// </summary>
        ///// <param name="m"></param>
        ///// <param name="n"></param>
        ///// <returns></returns>
        //static int Perimeter(int m, int n)
        //{
        //    int a = 2*m*n;
        //    int b = m*m - n*n;
        //    int c = m*m + n*n;
        //    return a + b + c;
        //}
        #endregion
    }
}
