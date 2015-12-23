using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
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
