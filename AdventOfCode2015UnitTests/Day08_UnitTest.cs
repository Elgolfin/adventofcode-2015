using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day08_UnitTest
    {
        [TestMethod][TestCategory("Day08")]
        public void string1_LengthInMemory_Is_0()
        {
            string input = @"""""";
            Assert.AreEqual(0, input.LengthInMemory());
        }

        [TestMethod]
        [TestCategory("Day08")]
        public void string1_Encode()
        {
            string input = @"""""";
            Assert.AreEqual(@"""\""\""""", input.EncodeSantaWay());
        }

        [TestMethod]
        [TestCategory("Day08")]
        public void string2_LengthInMemory_Is_3()
        {
            string input = @"""abc""";
            Assert.AreEqual(3, input.LengthInMemory());
        }

        [TestMethod]
        [TestCategory("Day08")]
        public void string2_Encode()
        {
            string input = @"""abc""";
            Assert.AreEqual(@"""\""abc\""""", input.EncodeSantaWay());
        }

        [TestMethod]
        [TestCategory("Day08")]
        public void string3_LengthInMemory_Is_7()
        {
            string input = @"""aaa\""aaa""";
            Assert.AreEqual(7, input.LengthInMemory());
        }

        [TestMethod]
        [TestCategory("Day08")]
        public void string3_Encode()
        {
            string input = @"""aaa\""aaa""";
            Assert.AreEqual(@"""\""aaa\\\""aaa\""""", input.EncodeSantaWay());
        }

        [TestMethod]
        [TestCategory("Day08")]
        public void string4_LengthInMemory_Is_1()
        {
            string input = @"""\x27""";
            Assert.AreEqual(1, input.LengthInMemory());
        }

        [TestMethod]
        [TestCategory("Day08")]
        public void string4_Encode()
        {
            string input = @"""\x27""";
            Assert.AreEqual(@"""\""\\x27\""""", input.EncodeSantaWay());
        }

        [TestMethod]
        [TestCategory("Day08")]
        public void Diff_Is_12()
        {
            string input1 = @"""""";
            Assert.AreEqual(0, input1.LengthInMemory());
            string input2 = @"""abc""";
            Assert.AreEqual(3, input2.LengthInMemory());
            string input3 = @"""aaa\""aaa""";
            Assert.AreEqual(7, input3.LengthInMemory());
            string input4 = @"""\x27""";
            Assert.AreEqual(1, input4.LengthInMemory());
            int diff = input1.Length + input2.Length + input3.Length + input4.Length;
            diff -= input1.LengthInMemory() + input2.LengthInMemory() + input3.LengthInMemory() + input4.LengthInMemory();
            Assert.AreEqual(12, diff);
        }

        [TestMethod]
        [TestCategory("Day08")]
        public void Diff_Is_19()
        {
            string input1 = @"""""";
            Assert.AreEqual(6, input1.EncodeSantaWay().Length);
            string input2 = @"""abc""";
            Assert.AreEqual(9, input2.EncodeSantaWay().Length);
            string input3 = @"""aaa\""aaa""";
            Assert.AreEqual(16, input3.EncodeSantaWay().Length);
            string input4 = @"""\x27""";
            Assert.AreEqual(11, input4.EncodeSantaWay().Length);
            int diff = input1.EncodeSantaWay().Length + input2.EncodeSantaWay().Length + input3.EncodeSantaWay().Length + input4.EncodeSantaWay().Length;
            diff -= input1.Length + input2.Length + input3.Length + input4.Length;
            Assert.AreEqual(19, diff);
        }
    }
}
