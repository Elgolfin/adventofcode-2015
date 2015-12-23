using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day12_UnitTest
    {
        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbers_1_returns_6()
        {
            string input = "[1,2,3]";
            Assert.AreEqual(6, Day12.SumAllNumbers(input));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbers_2_returns_6()
        {
            string input = "{\"a\":2,\"b\":4}";
            Assert.AreEqual(6, Day12.SumAllNumbers(input));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbers_1_returns_3()
        {
            string input = "[[[3]]]";
            Assert.AreEqual(3, Day12.SumAllNumbers(input));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbers_2_returns_3()
        {
            string input = "{\"a\":{\"b\":4},\"c\":-1}";
            Assert.AreEqual(3, Day12.SumAllNumbers(input));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbers_1_returns_0()
        {
            string input = "{\"a\":[-1,1]}";
            Assert.AreEqual(0, Day12.SumAllNumbers(input));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbers_2_returns_0()
        {
            string input = "[-1,{\"a\":1}]";
            Assert.AreEqual(0, Day12.SumAllNumbers(input));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbers_3_returns_0()
        {
            string input = "[]";
            Assert.AreEqual(0, Day12.SumAllNumbers(input));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbers_4_returns_0()
        {
            string input = "{}";
            Assert.AreEqual(0, Day12.SumAllNumbers(input));
        }
    }
}
