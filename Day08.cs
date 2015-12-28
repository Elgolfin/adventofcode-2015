using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2015
{
    public static class Day08
    {
        public static void Matchsticks_Part1()
        {
            int sum = 0;
            using (StreamReader sr = new StreamReader("../../Day08.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    sum += line.Length - line.LengthInMemory();
                }
            }
            Console.WriteLine(String.Format("The number of characters of code for string literals minus the number of characters in memory for the values of the strings in total for the entire file is {0}", sum));
        }

        public static int LengthInMemory (this string s)
        {
            string input = s;
            input = input.ToLower()
                 .Replace(@"\""", ".")              // Sequence \" (Slash Double Quote) counts as one
                 .Replace(@"\\", ".")               // Sequence \\ (Double slash) counts as one
                 .Replace(@"\x0", String.Empty)     // \xn count as zero (second digit of the hexa number will count as one)
                 .Replace(@"\x1", String.Empty)
                 .Replace(@"\x2", String.Empty)
                 .Replace(@"\x3", String.Empty)
                 .Replace(@"\x4", String.Empty)
                 .Replace(@"\x5", String.Empty)
                 .Replace(@"\x6", String.Empty)
                 .Replace(@"\x7", String.Empty)
                 .Replace(@"\x8", String.Empty)
                 .Replace(@"\x9", String.Empty)
                 .Replace(@"\xa", String.Empty)
                 .Replace(@"\xb", String.Empty)
                 .Replace(@"\xc", String.Empty)
                 .Replace(@"\xd", String.Empty)
                 .Replace(@"\xe", String.Empty)
                 .Replace(@"\xf", String.Empty);
            return input.Length - 2 < 0 ? 0: input.Length - 2; // Remove first and last Double Quote from the total
        }
    }
}
