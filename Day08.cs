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
        /// <summary>
        /// --- Day 8: Matchsticks ---
        ///
        /// Space on the sleigh is limited this year, and so Santa will be bringing his list as a digital copy.He needs to know how much space it will take up when stored.
        ///
        /// It is common in many programming languages to provide a way to escape special characters in strings.For example, C, JavaScript, Perl, Python, and even PHP handle special characters in very similar ways.
        ///
        /// However, it is important to realize the difference between the number of characters in the code representation of the string literal and the number of characters in the in-memory string itself.
        ///
        /// For example:
        ///
        ///    "" is 2 characters of code (the two double quotes), but the string contains zero characters.
        ///    "abc" is 5 characters of code, but 3 characters in the string data.
        ///    "aaa\"aaa" is 10 characters of code, but the string itself contains six "a" characters and a single, escaped quote character, for a total of 7 characters in the string data.
        ///    "\x27" is 6 characters of code, but the string itself contains just one - an apostrophe ('), escaped using hexadecimal notation.
        ///
        /// Santa's list is a file that contains many double-quoted string literals, one on each line. The only escape sequences used are \\ (which represents a single backslash), \" (which represents a lone double-quote character), and \x plus two hexadecimal characters (which represents a single character with that ASCII code).
        ///
        /// Disregarding the whitespace in the file, what is the number of characters of code for string literals minus the number of characters in memory for the values of the strings in total for the entire file?
        ///
        /// For example, given the four strings above, the total number of characters of string code (2 + 5 + 10 + 6 = 23) minus the total number of characters in memory for string values(0 + 3 + 7 + 1 = 11) is 23 - 11 = 12.
        ///
        /// Your puzzle answer was 1333.
        /// --- Part Two ---
        ///
        /// Now, let's go the other way. In addition to finding the number of characters of code, you should now encode each code representation as a new string and find the number of characters of the new encoded representation, including the surrounding double quotes.
        ///
        /// For example:
        ///
        ///    "" encodes to "\"\"", an increase from 2 characters to 6.
        ///    "abc" encodes to "\"abc\"", an increase from 5 characters to 9.
        ///    "aaa\"aaa" encodes to "\"aaa\\\"aaa\"", an increase from 10 characters to 16.
        ///    "\x27" encodes to "\"\\x27\"", an increase from 6 characters to 11.
        ///
        /// Your task is to find the total number of characters to represent the newly encoded strings minus the number of characters of code in each original string literal.For example, for the strings above, the total encoded length (6 + 9 + 16 + 11 = 42) minus the characters in the original code representation(23, just like in the first part of this puzzle) is 42 - 23 = 19.
        ///
        /// Your puzzle answer was 2046.
        /// </summary>
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
        public static void Matchsticks_Part2()
        {
            int sum2 = 0;
            int sum1 = 0;
            using (StreamReader sr = new StreamReader("../../Day08.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    sum1 += line.Length;
                    sum2 += line.EncodeSantaWay().Length;
                }
            }
            Console.WriteLine(String.Format("The total number of characters to represent the newly encoded strings minus the number of characters of code in each original string literal is {0}", sum2 - sum1));
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

        public static string EncodeSantaWay(this string s)
        {
            string output = s;
            output = output.Replace(@"\", @"\\")
                           .Replace(@"""", @"\""");
                           
            return String.Format("\"{0}\"",output);
        }
    }
}
