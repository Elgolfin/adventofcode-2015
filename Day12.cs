using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace AdventOfCode2015
{
    public static class Day12
    {
        public static void JSAbacusFramework_io_Part1()
        {
            int sum = 0;
            using (StreamReader sr = new StreamReader("../../day12.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    sum += SumAllNumbers(line);
                }
            }
            Console.WriteLine(String.Format("The sum of the messy JSON file is {0}", sum));
        }

        public static int SumAllNumbers(string input)
        {
            int sum = 0;
            Regex regex = new Regex(@"(-?[0-9]+)");
            foreach (Match result in regex.Matches(input))
            {
                int number = 0;
                if (Int32.TryParse(result.Value, out number))
                {
                    sum += number;
                }
            }
            return sum;
        }

    }

   
}
