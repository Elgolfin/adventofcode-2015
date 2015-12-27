using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    /// <summary>
    /// --- Day 11: Corporate Policy ---
    ///
    /// Santa's previous password expired, and he needs help choosing a new one.
    ///
    /// To help him remember his new password after the old one expires, Santa has devised a method of coming up with a password based on the previous one.Corporate policy dictates that passwords must be exactly eight lowercase letters(for security reasons), so he finds his new password by incrementing his old password string repeatedly until it is valid.
    ///
    /// Incrementing is just like counting with numbers: xx, xy, xz, ya, yb, and so on.Increase the rightmost letter one step; if it was z, it wraps around to a, and repeat with the next letter to the left until one doesn't wrap around.
    ///
    /// Unfortunately for Santa, a new Security-Elf recently started, and he has imposed some additional password requirements:
    ///
    ///    Passwords must include one increasing straight of at least three letters, like abc, bcd, cde, and so on, up to xyz.They cannot skip letters; abd doesn't count.
    ///    Passwords may not contain the letters i, o, or l, as these letters can be mistaken for other characters and are therefore confusing.
    ///    Passwords must contain at least two different, non-overlapping pairs of letters, like aa, bb, or zz.
    ///
    /// For example:
    ///
    ///    hijklmmn meets the first requirement (because it contains the straight hij) but fails the second requirement requirement(because it contains i and l).
    ///    abbceffg meets the third requirement(because it repeats bb and ff) but fails the first requirement.
    ///    abbcegjk fails the third requirement, because it only has one double letter(bb).
    ///    The next password after abcdefgh is abcdffaa.
    ///    The next password after ghijklmn is ghjaabcc, because you eventually skip all the passwords that start with ghi..., since i is not allowed.
    ///
    /// Given Santa's current password (your puzzle input), what should his next password be? hepxxyzz
    ///
    /// --- Part Two ---
    ///
    /// Santa's password expired again. What's the next one? heqaabcc
    /// </summary>
    public static class Day11
    {

        public static void CorporatePolicy_Part1(string input)
        {
            string newInput = input;
            while (!newInput.IsPasswordValid())
            {
                newInput = newInput.Increments();
            }
            Console.WriteLine("The new password is {0} (the old password was {1})", newInput, input);
        }

        public static void CorporatePolicy_Part2(string input)
        {
            string newInput = input;
            while (!newInput.IsPasswordValid())
            {
                newInput = newInput.Increments();
            }
            Console.WriteLine("The new password is {0} (the old password was {1})", newInput, input);

            input = newInput;
            newInput = newInput.Increments();
            while (!newInput.IsPasswordValid())
            {
                newInput = newInput.Increments();
            }
            Console.WriteLine("The new password is {0} (the old password was {1})", newInput, input);
        }

        public static bool IsPasswordValid(this string pwd)
        {
            bool isValid = false;
            isValid = pwd.DoesNotContain_iol()
                     && pwd.DoesContainTwoNonOverlappingDifferentPairsOfSameCharacters()
                     && pwd.DoesIncludeOneIncreasingStraightOfAtLeastThreeLetters()
                     && pwd.Length == 8;
            return isValid;
        }public static bool DoesNotContain_iol(this string input)
        {
            bool DoesNotContain_iol = true;
            Regex regex = new Regex(@"[iol]");
            Match match = regex.Match(input);
            if (match.Success)
            {
                DoesNotContain_iol = false;
            }
            return DoesNotContain_iol;
        }

        public static bool DoesContainTwoNonOverlappingIdenticalPairsOfSameCharacters(this string input)
        {
            bool DoesContainTwoNonOverlappingIdenticalPairs = false;
            Regex regex = new Regex(@"(([a-z])\2)[a-z]*\1");  // Not optimal, regex is greedy
            Match match = regex.Match(input);
            if (match.Success)
            {
                DoesContainTwoNonOverlappingIdenticalPairs = true;
            }
            return DoesContainTwoNonOverlappingIdenticalPairs;
        }



        public static bool DoesContainTwoNonOverlappingDifferentPairsOfSameCharacters(this string input)
        {
            bool DoesContainTwoNonOverlappingDifferentPairs = false;
            Regex regex = new Regex(@"(([a-z])\2)");
            string pair1 = String.Empty;
            foreach (Match result in regex.Matches(input))
            {
                if (String.IsNullOrEmpty(pair1))
                {
                    pair1 = result.Value;
                }
                 
                if (pair1 == result.Value)
                {
                    continue;
                } else
                {
                    DoesContainTwoNonOverlappingDifferentPairs = true;
                    break;
                }

            }
            return DoesContainTwoNonOverlappingDifferentPairs;
        }
        public static bool DoesIncludeOneIncreasingStraightOfAtLeastThreeLetters(this string input)
        {
            bool DoesIncludeOneIncreasingStraightOfAtLeastThreeLetters = false;
            Regex regex = new Regex(@"(abc|bcd|cde|def|efg|fgh|ghi|hij|ijk|jkl|klm|lmn|mno|nop|opq|pqr|qrs|rst|stu|tuv|uvw|vwx|wxy|xyz)");
            Match match = regex.Match(input);
            if (match.Success)
            {
                DoesIncludeOneIncreasingStraightOfAtLeastThreeLetters = true;
            }
            return DoesIncludeOneIncreasingStraightOfAtLeastThreeLetters;
        }

        public static string Increments (this string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }
            string newString = String.Empty;
            Char lastChar = input[input.Length - 1];
            lastChar++;

            if (!Char.IsLetter(lastChar))
            {
                lastChar = 'a';
                if (input.Length == 1)
                {
                    newString = "a" + lastChar;
                }
                else {
                    newString = input.Substring(0, input.Length - 1).Increments() + lastChar.ToString();
                }
            } else
            {
                newString = input.Substring(0, input.Length - 1) + lastChar.ToString();
            }
            return newString; 
        }

    }
}
