using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace AdventOfCode2015
{
    /// <summary>
    /// 
    /// --- Day 12: JSAbacusFramework.io ---
    ///
    /// Santa's Accounting-Elves need help balancing the books after a recent order. Unfortunately, their accounting software uses a peculiar storage format. That's where you come in.
    ///
    /// They have a JSON document which contains a variety of things: arrays([1,2,3]), objects({ "a":1, "b":2}), numbers, and strings.Your first job is to simply find all of the numbers throughout the document and add them together.
    ///
    /// For example:
    ///
    ///     [1,2,3] and { "a":2,"b":4} both have a sum of 6.
    ///     [[[3]]] and {"a":{"b":4},"c":-1} both have a sum of 3.
    ///     {"a":[-1,1]} and[-1,{"a":1}] both have a sum of 0.
    ///     [] and {} both have a sum of 0.
    ///
    /// You will not encounter any strings containing numbers.
    ///
    /// What is the sum of all numbers in the document? 119433
    //
    /// --- Part Two ---
    //
    /// Uh oh - the Accounting-Elves have realized that they double-counted everything red.
    ///
    /// Ignore any object (and all of its children) which has any property with the value "red". Do this only for objects ({...}), not arrays([...]).
    ///
    ///    [1,2,3] still has a sum of 6.
    ///    [1,{"c":"red","b":2},3] now has a sum of 4, because the middle object is ignored.
    ///    {"d":"red","e":[1,2,3,4],"f":5} now has a sum of 0, because the entire structure is ignored.
    ///    [1, "red", 5] has a sum of 6, because "red" in an array has no effect.
    ///    
    ///  68466
    /// </summary>
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
            Console.WriteLine(String.Format("The sum of all the numbers in the messy JSON file is {0}", sum));
        }

        public static void JSAbacusFramework_io_Part2()
        {
            int sum = 0;
            using (StreamReader sr = new StreamReader("../../day12.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    sum += SumAllNumbers(line, "red");
                }
            }
            Console.WriteLine(String.Format("Considering we've ignored all objects which has any property with the value \"red\", the sum of all the numbers in the messy JSON file is {0}", sum));
        }

        public static int SumAllNumbers(string input)
        {
            int sum = 0;
            Regex regex = new Regex(@"-?[0-9]+");
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

        /// <summary>
        /// DOES NOT WORK; TO BE FIXED LATER
        /// </summary>
        /// <param name="input"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int SumAllNumbers_DOES_NOT_WORK(string input, string color)
        {
            string clearedInput = input;
            Regex regex;
            if (!String.IsNullOrEmpty(color))
            {
                // Replace color by any color name you want
                // Regex pattern: {[[\]\s":,a-z0-9]+:\s*"color"[[\]\s":,a-z0-9]+}
                /* Regex 101 with ungreedy modifier (U)
                    /{[[\]\s":,a-z0-9]+:\s*"red"[[\]\s":,a-z0-9]+}/gU
                */
                string pattern = @"{[[\]\s"":,a-z0-9]+:\s*""color""[[\]\s"":,a-z0-9]+}";
                regex = new Regex(pattern.Replace("color", color));
                foreach (Match result in regex.Matches(input))
                {
                    clearedInput = clearedInput.Replace(result.Value, String.Empty);
                    Console.WriteLine(result.Value);
                }
            }
            return SumAllNumbers(clearedInput);
        }

        public static bool IsColorFree(string input, string color)
        {
            bool isColorFree = true;
            string clearedInput = input;
            Regex regex;
            if (!String.IsNullOrEmpty(color))
            {
                // Remove all arrays in the current JSON Object
                string pattern = @"\[[^[\]]+]";
                regex = new Regex(pattern);
                while (regex.Match(clearedInput).Success) {
                    foreach (Match result in regex.Matches(clearedInput))
                    {
                        clearedInput = clearedInput.Replace(result.Value, String.Empty);
                    }
                }

                // Detect "color" pattern in a {} section only (we just removed the [] sections above)
                pattern = @"""color""";
                regex = new Regex(pattern.Replace("color", color));
                Match match = regex.Match(clearedInput);
                if (match.Success)
                {
                    isColorFree = false;
                }
            }
            return isColorFree;
        }

        public static int SumAllNumbers(string input, string color)
        {
            StringBuilder clearedInput = new StringBuilder();
            string currentJSONObject = String.Empty;
            Stack<int> currentOpenedBrackets = new Stack<int>();
            int countChar = 0;
            while (countChar < input.Length)
            {
                Char c = input[countChar];
                if (c == '{')
                {
                    currentOpenedBrackets.Push(countChar);
                }
                if (c == '}')
                {
                    int openedBracketChar = currentOpenedBrackets.Pop();
                    currentJSONObject = input.Substring(openedBracketChar, countChar - openedBracketChar + 1);
                    if (!IsColorFree(currentJSONObject, color))
                    {
                        input = input.Replace(currentJSONObject, String.Empty);
                        countChar = openedBracketChar;
                        continue;
                    }
                }
                countChar++;
            }
            return SumAllNumbers(input.ToString());
        }
    }

   
}
