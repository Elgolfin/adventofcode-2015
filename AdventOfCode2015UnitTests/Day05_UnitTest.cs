using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day05_UnitTest
    {

        //ugknbfddgicrmopn is nice because it has at least three vowels(u...i...o...), a double letter(...dd...), and none of the disallowed substrings.
        //aaa is nice because it has at least three vowels and a double letter, even though the letters used by different rules overlap.
        //jchzalrnumimnmhp is naughty because it has no double letter.
        //haegwjzuvuyypxyu is naughty because it contains the string xy.
        //dvszwmarrgswjxmb is naughty because it contains only one vowel.


        [TestMethod]
        [TestCategory("Day05")]
        public void ugknbfddgicrmopn_IsARidiculousNiceString()
        {
            string input = "ugknbfddgicrmopn";
            Assert.AreEqual(true, input.IsRidiculouslyNice());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void aaa_IsARidiculousNiceString()
        {
            string input = "aaa";
            Assert.AreEqual(true, input.IsRidiculouslyNice());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void jchzalrnumimnmhp_IsANaughtyString()
        {
            string input = "jchzalrnumimnmhp";
            Assert.AreEqual(true, input.IsRidiculouslyNaughty());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void jchzalrnumimnmhp_IsNotARidiculousNiceString()
        {
            string input = "jchzalrnumimnmhp";
            Assert.AreEqual(false, input.IsRidiculouslyNice());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void aaa_HasAtLeastThreeVowels()
        {
            string input = "aaa";
            Assert.AreEqual(true, input.HasAtLeastThreeVowels());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void aaaa_HasAtLeastThreeVowels()
        {
            string input = "aaaa";
            Assert.AreEqual(true, input.HasAtLeastThreeVowels());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void baertu_HasAtLeastThreeVowels()
        {
            string input = "baertu";
            Assert.AreEqual(true, input.HasAtLeastThreeVowels());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void aa_HasNotAtLeastThreeVowels()
        {
            string input = "aa";
            Assert.AreEqual(false, input.HasAtLeastThreeVowels());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void a_HasNotAtLeastThreeVowels()
        {
            string input = "a";
            Assert.AreEqual(false, input.HasAtLeastThreeVowels());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void yyy_HasNotAtLeastThreeVowels_Y_IsNotAVowel1()
        {
            string input = "yyy";
            Assert.AreEqual(false, input.HasAtLeastThreeVowels());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void yayey_HasNotAtLeastThreeVowels_Y_IsNotAVowel1()
        {
            string input = "yayey";
            Assert.AreEqual(false, input.HasAtLeastThreeVowels());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void bcdfgh_HasNotAtLeastThreeVowels()
        {
            string input = "bcdfgh";
            Assert.AreEqual(false, input.HasAtLeastThreeVowels());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void bcefgh_DoesNotContain_ab_cd_pq_xy()
        {
            string input = "bcefgh";
            Assert.AreEqual(true, input.DoesNotContain_ab_cd_pq_xy());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void abmsldfkjs_DoesContain_ab_cd_pq_xy()
        {
            string input = "abmsldfkjs";
            Assert.AreEqual(false, input.DoesNotContain_ab_cd_pq_xy());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void cdmsldfkjs_DoesContain_ab_cd_pq_xy()
        {
            string input = "cdmsldfkjs";
            Assert.AreEqual(false, input.DoesNotContain_ab_cd_pq_xy());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void pqmsldfkjs_DoesContain_ab_cd_pq_xy()
        {
            string input = "pqmsldfkjs";
            Assert.AreEqual(false, input.DoesNotContain_ab_cd_pq_xy());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void xymsldfkjs_DoesContain_ab_cd_pq_xy()
        {
            string input = "xymsldfkjs";
            Assert.AreEqual(false, input.DoesNotContain_ab_cd_pq_xy());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void xymslddfkjs_DoesContainALetterTwiceInARow()
        {
            string input = "xymslddfkjs";
            Assert.AreEqual(true, input.DoesContainALetterTwiceInARow());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void xymslddfkjs_DoesNotContainALetterTwiceInARow()
        {
            string input = "xymsledfdkjs";
            Assert.AreEqual(false, input.DoesContainALetterTwiceInARow());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void qjhvhtzxzqqjkmpb_IsANiceString()
        {
            string input = "qjhvhtzxzqqjkmpb";
            Assert.AreEqual(true, input.IsNice());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void xxyxx_IsANiceString()
        {
            string input = "xxyxx";
            Assert.AreEqual(true, input.IsNice());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void uurcxstgmygtbstg_IsANaughtyString()
        {
            string input = "uurcxstgmygtbstg";
            Assert.AreEqual(true, input.IsNaughty());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void ieodomkazucvgmuy_IsANaughtyString()
        {
            string input = "ieodomkazucvgmuy";
            Assert.AreEqual(true, input.IsNaughty());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void ssrjgasfhdouwyoh_IsANaughtyString()
        {
            string input = "ssrjgasfhdouwyoh";
            Assert.AreEqual(true, input.IsNaughty());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void aaa_DoesContainOneLetterWhichRepeatsWithExactlyOneLetterBetweenThem()
        {
            string input = "aaa";
            Assert.AreEqual(true, input.DoesContainOneLetterWhichRepeatsWithExactlyOneLetterBetweenThem());
        }

        [TestMethod]
        [TestCategory("Day05")]
        public void aya_DoesContainOneLetterWhichRepeatsWithExactlyOneLetterBetweenThem()
        {
            string input = "aya";
            Assert.AreEqual(true, input.DoesContainOneLetterWhichRepeatsWithExactlyOneLetterBetweenThem());
        }


    }
}
