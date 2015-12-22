using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day04_UnitTest
    {

        [TestMethod]
        [TestCategory("Day04")]
        public void TheIdealStockingStuffer_1()
        {
            string secretKey = "abcdef";
            Assert.AreEqual("609043", Day04.FindLowestPositiveNumber(secretKey));
        }

        [TestMethod]
        [TestCategory("Day04")]
        public void TheIdealStockingStuffer_2()
        {
            string secretKey = "pqrstuv";
            Assert.AreEqual("1048970", Day04.FindLowestPositiveNumber(secretKey));
        }


    }
}
