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
            Day01.NotQuiteLisp("()()()()()())");
            Assert.AreEqual(Day01.actualFloor, -1);
            Assert.AreEqual(Day01.firstTimeEnteringBasement, 13);
        }

        [TestMethod]
        [TestCategory("Day01")]
        public void NotQuiteLisp_Complex()
        {
            Day01.NotQuiteLisp(String.Empty);
            Assert.AreEqual(280, Day01.actualFloor);
            Assert.AreEqual(1797, Day01.firstTimeEnteringBasement);
        }
    }
}
