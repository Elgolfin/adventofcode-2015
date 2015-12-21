using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day01_UnitTest
    {
        //[TestCleanup]
        //public void CleanUp()
        //{

        //}

        [TestMethod][TestCategory("Day01")]
        public void NotQuiteLisp_Simple()
        {
            Day1.NotQuiteLisp("()()()()()())");
            Assert.AreEqual(Day1.actualFloor, -1);
            Assert.AreEqual(Day1.firstTimeEnteringBasement, 13);
        }

        [TestMethod]
        [TestCategory("Day01")]
        public void NotQuiteLisp_Complex()
        {
            Day1.NotQuiteLisp(String.Empty);
            Assert.AreEqual(280, Day1.actualFloor);
            Assert.AreEqual(1797, Day1.firstTimeEnteringBasement);
        }
    }
}
