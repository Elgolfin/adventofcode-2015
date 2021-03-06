﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    /// <summary>
    /// 
    /// --- Day 5: Doesn't He Have Intern-Elves For This? ---
    ///
    /// Santa needs help figuring out which strings in his text file are naughty or nice.
    ///
    /// A nice string is one with all of the following properties:
    ///
    ///   It contains at least three vowels(aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
    ///   It contains at least one letter that appears twice in a row, like xx, abcdde(dd), or aabbccdd(aa, bb, cc, or dd).
    ///   It does not contain the strings ab, cd, pq, or xy, even if they are part of one of the other requirements.
    ///
    /// For example:
    ///
    ///    ugknbfddgicrmopn is nice because it has at least three vowels(u...i...o...), a double letter(...dd...), and none of the disallowed substrings.
    ///    aaa is nice because it has at least three vowels and a double letter, even though the letters used by different rules overlap.
    ///    jchzalrnumimnmhp is naughty because it has no double letter.
    ///    haegwjzuvuyypxyu is naughty because it contains the string xy.
    ///    dvszwmarrgswjxmb is naughty because it contains only one vowel.
    ///
    /// How many strings are nice? 258
    ///
    /// --- Part Two ---
    ///
    /// Realizing the error of his ways, Santa has switched to a better model of determining whether a string is naughty or nice.None of the old rules apply, as they are all clearly ridiculous.
    ///
    /// Now, a nice string is one with all of the following properties:
    ///
    ///    It contains a pair of any two letters that appears at least twice in the string without overlapping, like xyxy (xy) or aabcdefgaa(aa), but not like aaa(aa, but it overlaps).
    ///    It contains at least one letter which repeats with exactly one letter between them, like xyx, abcdefeghi(efe), or even aaa.
    ///
    /// For example:
    ///
    ///    qjhvhtzxzqqjkmpb is nice because is has a pair that appears twice(qj) and a letter that repeats with exactly one letter between them(zxz).
    ///    xxyxx is nice because it has a pair that appears twice and a letter that repeats with one between, even though the letters used by each rule overlap.
    ///    uurcxstgmygtbstg is naughty because it has a pair(tg) but no repeat with a single letter between them.
    ///    ieodomkazucvgmuy is naughty because it has a repeating letter with one between(odo), but no pair that appears twice.
    ///
    /// How many strings are nice under these new rules? 53
    /// </summary>
    public static class Day05
    {
        public static void DoesntHeHaveInternElvesForThis_Part1()
        {
            int countNiceStrings = 0;
            using (StreamReader sr = new StreamReader("../../day05.txt"))
            {
                while (sr.Peek() >= 0) 
                {
                    string line = sr.ReadLine();
                    if (line.IsRidiculouslyNice())
                    {
                        countNiceStrings++;
                        //Console.WriteLine(line);
                    }
                }
            }
            Console.WriteLine(String.Format("There are {0} ridiculously nice strings", countNiceStrings));
        }

        public static void DoesntHeHaveInternElvesForThis_Part2()
        {
            int countNiceStrings = 0;
            using (StreamReader sr = new StreamReader("../../day05.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    if (line.IsNice())
                    {
                        countNiceStrings++;
                        //Console.WriteLine(line);
                    }
                }
            }
            Console.WriteLine(String.Format("There are {0} nice strings", countNiceStrings));
        }

        public static bool IsNice(this string input)
        {
            bool IsNice = false;
            IsNice =    input.DoesContainAnyPairOfTwoLettersAppearingTwiceWithoutOverlapping()
                     && input.DoesContainOneLetterWhichRepeatsWithExactlyOneLetterBetweenThem();
            return IsNice;
        }
        public static bool IsNaughty(this string input)
        {
            return !input.IsNice();
        }

        public static bool IsRidiculouslyNice(this string input)
        {
            bool IsNice = false;
            IsNice =    input.HasAtLeastThreeVowels() 
                     && input.DoesContainALetterTwiceInARow() 
                     && input.DoesNotContain_ab_cd_pq_xy();
            return IsNice;
        }

        public static bool IsRidiculouslyNaughty(this string input)
        {
            return !input.IsRidiculouslyNice();
        }

        public static bool HasAtLeastThreeVowels(this string input)
        {
            string pattern = @"([^aeiou]*[aeiou]){3,}";
            return input.Match(pattern);
        }

        public static bool DoesNotContain_ab_cd_pq_xy(this string input)
        {
            string pattern = @"ab|cd|pq|xy";
            return !input.Match(pattern);
        }

        public static bool DoesContainALetterTwiceInARow(this string input)
        {
            string pattern = @"([a-z])\1";
            return input.Match(pattern);
        }

        public static bool DoesContainOneLetterWhichRepeatsWithExactlyOneLetterBetweenThem(this string input)
        {
            string pattern = @"(.).\1";
            return input.Match(pattern);
        }

        public static bool DoesContainAnyPairOfTwoLettersAppearingTwiceWithoutOverlapping (this string input)
        {
            string pattern = @"([a-z]{2})[a-z]*\1"; // Not optimal, Regex is greedy
            return input.Match(pattern);
        }

        public static bool Match (this string input, string pattern)
        {
            bool IsMatchingCondition = false;

            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            if (match.Success)
            {
                IsMatchingCondition = true;
            }

            return IsMatchingCondition;
        }

    }
}
