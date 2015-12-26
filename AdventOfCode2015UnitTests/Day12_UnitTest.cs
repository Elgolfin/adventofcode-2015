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

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_1_returns_0()
        {
            string input = "{}";
            Assert.AreEqual(0, Day12.SumAllNumbers(input, "red"));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_2_returns_6()
        {
            string input = "[1,2,3]";
            Assert.AreEqual(6, Day12.SumAllNumbers(input, "red"));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_3_returns_4()
        {
            string input = "[1,{\"c\":\"red\",\"b\":2},3]";
            Assert.AreEqual(4, Day12.SumAllNumbers(input, "red"));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_4_returns_0()
        {
            string input = "{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}";
            Assert.AreEqual(0, Day12.SumAllNumbers(input, "red"));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_5_returns_6()
        {
            string input = "[1,\"red\",5]";
            Assert.AreEqual(6, Day12.SumAllNumbers(input, "red"));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_6_returns_293()
        {
            string input = "{\"a\":[\"red\",\"red\",46,\"red\"],\"b\":[\"green\",193,54,\"orange\"]}";
            Assert.AreEqual(293, Day12.SumAllNumbers(input, "red"));
        }



        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_7_returns_0()
        {
            string input = "{\"e\":\"red\",\"a\":{\"c\":115,\"a\":137,\"b\":\"green\"},\"d\":-25,\"c\":\"blue\",\"h\":{\"a\":161,\"b\":[\"yellow\",56,129,-31,\"yellow\",\"red\",\"green\",105,\"orange\",130]},\"b\":142,\"g\":194,\"f\":122,\"i\":-16}";
            Assert.AreEqual(0, Day12.SumAllNumbers(input, "red"));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_8_returns_0()
        {
            string input = "{\"red\",\"a\":{\"c\":115,\"a\":137,\"b\":\"green\"},\"d\":-25,\"c\":\"blue\",\"h\":{\"a\":161,\"b\":[\"yellow\",56,129,-31,\"yellow\",\"red\",\"green\",105,\"orange\",130]},\"b\":142,\"g\":194,\"f\":122,\"i\":-16}";
            Assert.AreEqual(0, Day12.SumAllNumbers(input, "red"));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_9_returns_0()
        {
            string input = "{\"a\":{\"c\":115,\"a\":137,\"b\":\"green\"},\"d\":-25,\"c\":\"blue\",\"h\":{\"a\":161,\"b\":[\"yellow\",56,129,-31,\"yellow\",\"red\",\"green\",105,\"orange\",130]},\"b\":142,\"g\":194,\"f\":122,\"i\":-16,\"red\"}";
            Assert.AreEqual(0, Day12.SumAllNumbers(input, "red"));
        }


        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_10_returns_0()
        {
            string input = "{\"a\",[1,2],\"red\",[3,4],\"b\"}";
            Assert.AreEqual(0, Day12.SumAllNumbers(input, "red"));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_11_returns_468()
        {
            string input = "{\"e\":6,\"c\":{\"c\":\"violet\",\"a\":8,\"b\":[\"red\",{\"a\":37},\"green\",84,\"yellow\",\"green\",[24,45,\"blue\",\"blue\",56,\"yellow\"],\"orange\"]},\"a\":\"violet\",\"b\":{\"a\":85},\"d\":[109,66,[\"yellow\",\"violet\",21,-30],\"violet\",\"blue\",-43,{\"e\":\"violet\",\"c\":\"red\",\"a\":\"blue\",\"b\":-22,\"d\":[71,\"red\",30,\"violet\",\"red\",26,120],\"f\":[\"red\"]},\"red\"]}";
            Assert.AreEqual(468, Day12.SumAllNumbers(input, "red"));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_12_returns_0()
        {
            string input = "{\"red\",\"e\":6,\"c\":{\"c\":\"violet\",\"a\":8,\"b\":[\"red\",{\"a\":37},\"green\",84,\"yellow\",\"green\",[24,45,\"blue\",\"blue\",56,\"yellow\"],\"orange\"]},\"a\":\"violet\",\"b\":{\"a\":85},\"d\":[109,66,[\"yellow\",\"violet\",21,-30],\"violet\",\"blue\",-43,{\"e\":\"violet\",\"c\":\"red\",\"a\":\"blue\",\"b\":-22,\"d\":[71,\"red\",30,\"violet\",\"red\",26,120],\"f\":[\"red\"]},\"red\"]}";
            Assert.AreEqual(0, Day12.SumAllNumbers(input, "red"));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_13_returns_0()
        {
            string input = "{\"e\":6,\"c\":{\"c\":\"violet\",\"a\":8,\"b\":[\"red\",{\"a\":37},\"green\",84,\"yellow\",\"green\",[24,45,\"blue\",\"blue\",56,\"yellow\"],\"orange\"]},\"a\":\"violet\",\"b\":{\"a\":85},\"d\":[109,66,[\"yellow\",\"violet\",21,-30],\"violet\",\"blue\",-43,{\"e\":\"violet\",\"c\":\"red\",\"a\":\"blue\",\"b\":-22,\"d\":[71,\"red\",30,\"violet\",\"red\",26,120],\"f\":[\"red\"]},\"red\"],\"red\"}";
            Assert.AreEqual(0, Day12.SumAllNumbers(input, "red"));
        }

        [TestMethod]
        [TestCategory("Day12")]
        public void SumAllNumbersIgnoreRed_14_returns_0()
        {
            string input = "{\"red\",[\"yellow\",\"violet\",21,-30],\"violet\",\"blue\",-43,{\"e\":\"violet\",\"c\":\"red\",\"a\":\"blue\",\"b\":-22,\"d\":[71,\"red\",30,\"violet\",\"red\",26,120],\"f\":[\"red\"]},\"red\"]}";
            Assert.AreEqual(0, Day12.SumAllNumbers(input, "red"));
        }

        
    }
}
