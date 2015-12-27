using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    //// <summary>
    //// --- Day 10: Elves Look, Elves Say ---
    ///
    /// Today, the Elves are playing a game called look-and-say.They take turns making sequences by reading aloud the previous sequence and using that reading as the next sequence.For example, 211 is read as "one two, two ones", which becomes 1221 (1 2, 2 1s).
    ///
    /// Look-and-say sequences are generated iteratively, using the previous value as input for the next step.For each step, take the previous value, and replace each run of digits(like 111) with the number of digits(3) followed by the digit itself(1).
    ///
    /// For example:
    ///
    ///    1 becomes 11 (1 copy of digit 1).
    ///    11 becomes 21 (2 copies of digit 1).
    ///    21 becomes 1211 (one 2 followed by one 1).
    ///    1211 becomes 111221 (one 1, one 2, and two 1s).
    ///    111221 becomes 312211 (three 1s, two 2s, and one 1).
    ///
    /// Starting with the digits in your puzzle input, apply this process 40 times.What is the length of the result? 492982
    ///
    /// --- Part Two ---
    ///
    /// Neat, right? You might also enjoy hearing John Conway talking about this sequence (that's Conway of Conway's Game of Life fame).
    ///
    /// Now, starting again with the digits in your puzzle input, apply this process 50 times. What is the length of the new result? 6989950
    //// </summary>
    public class Day10
    {

        public static void ElvesLookElvesSay_Part1(string phrase, int numIterations)
        {
            //Console.WriteLine(String.Format("{0}", phrase));
            //Console.ReadKey();
            string finalResult = String.Empty;
            foreach (string result in ComputeLookAndSay(phrase, numIterations))
            {
                //Console.WriteLine(String.Format("{0}", result));
                //Console.ReadKey();
                finalResult = result;
            }

            Console.WriteLine(String.Format("After {0} iterations of look and say on the initial phrase <{1}>, the result string is {2} characters long", numIterations, phrase, finalResult.Length));
        }

        public static IEnumerable<string> ComputeLookAndSay(string phrase, int numIterations)
        {
            string currentPhrase = phrase;
            int idxIteration = 0;

            while (idxIteration < numIterations)
            {
                StringBuilder newPhrase = new StringBuilder();
                int countChar = 0;
                Char lastChar = currentPhrase[0];
                foreach (Char c in currentPhrase)
                {
                    if (lastChar == c)
                    {
                        countChar++;
                    } else
                    {
                        newPhrase.Append(countChar.ToString());
                        newPhrase.Append(lastChar.ToString());
                        countChar = 1;
                    }
                    lastChar = c;
                }
                idxIteration++;
                newPhrase.Append(countChar.ToString());
                newPhrase.Append(lastChar.ToString());
                currentPhrase = newPhrase.ToString();
                yield return currentPhrase;
            }
        }

        public static int LookAndSay(string phrase, int numIterations)
        {
            StringBuilder lookAndSayResult = new StringBuilder();
            string finalResult = String.Empty;
            foreach (string result in ComputeLookAndSay(phrase, numIterations))
            {
                lookAndSayResult.Append(result);
                finalResult = result;
            }
            return finalResult.Length;
            //return lookAndSayResult.ToString().Length;
        }

    }
}
