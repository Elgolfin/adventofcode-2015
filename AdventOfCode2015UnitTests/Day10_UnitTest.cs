using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day10_UnitTest
    {
        //[TestCleanup]
        //public void CleanUp()
        //{

        //}

        [TestMethod][TestCategory("Day10")]
        public void LookAndSay_1_1_HasALengthOf_1()
        {
            string input = "1";
            Assert.AreEqual(2, Day10.LookAndSay(input, 1));
        }

        [TestMethod]
        [TestCategory("Day10")]
        public void LookAndSay_1_2Iterations_HasALengthOf_2()
        {
            string input = "1";
            Assert.AreEqual(2, Day10.LookAndSay(input, 2));
        }

        [TestMethod]
        [TestCategory("Day10")]
        public void LookAndSay_1_3Iterations_HasALengthOf_4()
        {
            string input = "1";
            Assert.AreEqual(4, Day10.LookAndSay(input, 3));
        }

        [TestMethod]
        [TestCategory("Day10")]
        public void LookAndSay_1_4Iterations_HasALengthOf_6()
        {
            string input = "1";
            Assert.AreEqual(6, Day10.LookAndSay(input, 4));
        }

        [TestMethod]
        [TestCategory("Day10")]
        public void LookAndSay_1_5Iterations_HasALengthOf_6()
        {
            string input = "1";
            Assert.AreEqual(6, Day10.LookAndSay(input, 5));
        }

    }
}
