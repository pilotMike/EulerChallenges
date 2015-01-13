using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Files;
using EulerTools.Program;
using EulerTools.Text;

namespace CodedTriangleNumbers
{
    class Program
    {
        //The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); so the first ten triangle numbers are:

        //1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

        //By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value.
        // For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. If the word value is a triangle number then we shall call the word a triangle word.

        //Using words.txt (right click and 'Save Link/Target As...'), a 16K text file containing nearly two-thousand common English words, how many are triangle words?


        static void Main(string[] args)
        {
            var words = new FileHelper().ParseFile("p042_words.txt");

            var benchmarker = new Benchmarker();
            int count = 0;
            benchmarker.Benchmark(()=> count = Do(words));

            Console.WriteLine(count);
            Console.ReadLine();
        }

        private static int Do(IEnumerable<string> words)
        {
            var triangleNumbers = new List<int>();
            // assume that the list is be sorted ascending by adding
            // greater values to the end. Use the last item in the 
            // collection as the max value. If a potential number is
            // greater than the max value, iterate the formula
            // for a max that is greater than or equal to the number.

            SeedTriangleNumbers(triangleNumbers);

            var count = GetTriangleNumberCount(words, triangleNumbers);
            return count;
        }

        private static int GetTriangleNumberCount(IEnumerable<string> words, IList<int> triangleNumbers)
        {
            var textHelper = new TextHelper();
            int triangleWordCount = 0;
            foreach (var word in words)
            {
                int sum = textHelper.GetNumberValue(word);
                if (sum <= triangleNumbers.Last())
                {
                    if (triangleNumbers.Contains(sum))
                        triangleWordCount++;
                }
                else
                {
                    // this is never hit...oh well.
                    // get more triangle numbers until they
                    // exceed the value of sum
                    GetNextTriangleNumber(sum, triangleNumbers);
                    if (triangleNumbers.Contains(sum))
                        triangleWordCount++;
                }
            }
            return triangleWordCount;
        }

        private static void GetNextTriangleNumber(int sum, IList<int> triangleNumbers)
        {
            while (sum >= triangleNumbers.Last())
                triangleNumbers.Add(Formula(triangleNumbers.Count));
        }

        private static void SeedTriangleNumbers(ICollection<int> triangleNumbers)
        {
            for (int i = 0; i < 26; i++)
                triangleNumbers.Add(Formula(i));
        }


        private static int Formula(int n)
        {
            return (int)(.5 * n * (n + 1));
        }
    }
}
