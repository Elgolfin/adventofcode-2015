using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day11_UnitTest
    {

        [TestMethod]
        [TestCategory("Day11")]
        public void aaxyzbbp_IsAValidPassword()
        {
            string input = "aaxyzbbp";
            Assert.AreEqual(true, input.IsPasswordValid());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void aaxyzbbp_IsNotAValidPassword()
        {
            string input = "aaxyzbb";
            Assert.AreEqual(false, input.IsPasswordValid());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void hijklmmn_IsNotAValidPassword()
        {
            string input = "hijklmmn";
            Assert.AreEqual(false, input.IsPasswordValid());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void abbceffg_IsNotAValidPassword()
        {
            string input = "abbceffg";
            Assert.AreEqual(false, input.IsPasswordValid());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void abbcegjk_IsNotAValidPassword()
        {
            string input = "abbcegjk";
            Assert.AreEqual(false, input.IsPasswordValid());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void ugknbfddgicrmopn_DoesContain_iol()
        {
            string input = "ugknbfddgicrmopn";
            Assert.AreEqual(false, input.DoesNotContain_iol());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void ugknbfddgcrmpn_DoesNotContain_iol()
        {
            string input = "ugknbfddgcrmpn";
            Assert.AreEqual(true, input.DoesNotContain_iol());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void letter_DoesContain_iol()
        {
            string input = "letter";
            Assert.AreEqual(false, input.DoesNotContain_iol());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void elgolfin_DoesContain_iol()
        {
            string input = "elgolfin";
            Assert.AreEqual(false, input.DoesNotContain_iol());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void aaaa_DoesContainTwoNonOverlappingIdenticalPairs()
        {
            string input = "aaaa";
            Assert.AreEqual(true, input.DoesContainTwoNonOverlappingIdenticalPairsOfSameCharacters());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void bbaabbaabb_DoesContainTwoNonOverlappingIdenticalPairs()
        {
            string input = "bbaabbaabb";
            Assert.AreEqual(true, input.DoesContainTwoNonOverlappingIdenticalPairsOfSameCharacters());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void aaaa_DoesNotContainTwoNonOverlappingDifferentPairs()
        {
            string input = "aaaa";
            Assert.AreEqual(false, input.DoesContainTwoNonOverlappingDifferentPairsOfSameCharacters());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void bbaabbaabb_DoesContainTwoNonOverlappingDifferentPairs()
        {
            string input = "bbaabbaabb";
            Assert.AreEqual(true, input.DoesContainTwoNonOverlappingDifferentPairsOfSameCharacters());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void elgolfin_DoesNotIncludeOneIncreasingStraightOfAtLeastThreeLetters()
        {
            string input = "elgolfin";
            Assert.AreEqual(false, input.DoesIncludeOneIncreasingStraightOfAtLeastThreeLetters());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void DoesIncludeOneIncreasingStraightOfAtLeastThreeLetters()
        {
            string[] toBeTested = { "abc", "bcd", "cde", "def", "efg", "fgh", "ghi", "hij", "ijk", "jkl", "klm", "lmn", "mno", "nop", "opq", "pqr", "qrs", "rst", "stu", "tuv", "uvw", "vwx", "wxy", "xyz" };
            foreach (string str in toBeTested)
            {
                Assert.AreEqual(true, str.DoesIncludeOneIncreasingStraightOfAtLeastThreeLetters());
            }
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void a_incrementsTo_b()
        {
            Assert.AreEqual("b", "a".Increments());
        }

        [TestMethod]
        [TestCategory("Day11")]
        public void y_incrementsTo_z()
        {
            Assert.AreEqual("z", "y".Increments());

        }

        [TestMethod]
        [TestCategory("Day11")]
        public void z_incrementsTo_aa()
        {
            Assert.AreEqual("aa", "z".Increments());

        }

        [TestMethod]
        [TestCategory("Day11")]
        public void az_incrementsTo_ba()
        {
            Assert.AreEqual("ba", "az".Increments());

        }

        [TestMethod]
        [TestCategory("Day11")]
        public void aaa_incrementsTo_aab()
        {
            Assert.AreEqual("aab", "aaa".Increments());

        }

        [TestMethod]
        [TestCategory("Day11")]
        public void aza_incrementsTo_azb()
        {
            Assert.AreEqual("azb", "aza".Increments());

        }

        [TestMethod]
        [TestCategory("Day11")]
        public void aca_incrementsTo_abz()
        {
            Assert.AreEqual("aca", "abz".Increments());

        }

        [TestMethod]
        [TestCategory("Day11")]
        public void zzzz_incrementsTo_aaaaa()
        {
            Assert.AreEqual("aaaaa", "zzzz".Increments());

        }

        [TestMethod]
        [TestCategory("Day11")]
        public void hepxcrrq_incrementsTo_hepxcrrr()
        {
            Assert.AreEqual("hepxcrrr", "hepxcrrq".Increments());
        }
    }
}
