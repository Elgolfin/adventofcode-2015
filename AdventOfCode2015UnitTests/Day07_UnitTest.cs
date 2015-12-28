using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day07_UnitTest
    {
        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_0_AND_0_Is_0()
        {
            uint a = 0;
            uint b = 0;
            uint result = 0;
            Gate op = new Gate_AND(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_1_AND_1_Is_0()
        {
            uint a = 1;
            uint b = 1;
            uint result = 1;
            Gate op = new Gate_AND(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_3_AND_1_Is_1()
        {
            uint a = 3;
            uint b = 1;
            uint result = 1;
            Gate op = new Gate_AND(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_1_AND_8_Is_0()
        {
            uint a = 1;
            uint b = 8;
            uint result = 0;
            Gate op = new Gate_AND(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_8_AND_3_Is_0()
        {
            uint a = 8;
            uint b = 3;
            uint result = 0;
            Gate op = new Gate_AND(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_0_OR_0_Is_0()
        {
            uint a = 0;
            uint b = 0;
            uint result = 0;
            Gate op = new Gate_OR(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_1_OR_1_Is_1()
        {
            uint a = 1;
            uint b = 1;
            uint result = 1;
            Gate op = new Gate_OR(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_4_OR_1_Is_5()
        {
            uint a = 4;
            uint b = 1;
            uint result = 5;
            Gate op = new Gate_OR(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_1_OR_3_Is_3()
        {
            uint a = 1;
            uint b = 3;
            uint result = 3;
            Gate op = new Gate_OR(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_8_OR_3_Is_11()
        {
            uint a = 8;
            uint b = 3;
            uint result = 11;
            Gate op = new Gate_OR(a, b);
            Assert.AreEqual(result, op.Execute());
        }



        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_NOT_1_Is_65534()
        {
            uint a = 1;
            uint result = 65534;
            Gate op = new Gate_NOT(a);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_NOT_0_Is_65535()
        {
            uint a = 0;
            uint result = 65535;
            Gate op = new Gate_NOT(a);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_NOT_65535_Is_0()
        {
            uint a = 65535;
            uint result = 0;
            Gate op = new Gate_NOT(a);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_NOT_1312_Is_64223()
        {
            uint a = 1312;
            uint result = 64223;
            Gate op = new Gate_NOT(a);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_RSHIFT_0x0001_x1_Is_0x0000()
        {
            uint a = 0;
            uint b = 1;
            uint result = 0;
            Gate op = new Gate_RSHIFT(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_RSHIFT_0x8000_x1_Is_0x4000()
        {
            uint a = 0x8000;
            uint b = 1;
            uint result = 0x4000;
            Gate op = new Gate_RSHIFT(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_LSHIFT_0x8000_x1_Is_0x0000()
        {
            uint a = 0x8000;
            uint b = 1;
            uint result = 0;
            Gate op = new Gate_LSHIFT(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_LSHIFT_0xFFFF_x16_Is_0x0000()
        {
            uint a = 0xFFFF;
            uint b = 16;
            uint result = 0;
            Gate op = new Gate_LSHIFT(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_123_AND_456_Is_72()
        {
            uint a = 123;
            uint b = 456;
            uint result = 72;
            Gate op = new Gate_AND(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_123_OR_456_Is_507()
        {
            uint a = 123;
            uint b = 456;
            uint result = 507;
            Gate op = new Gate_OR(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_LSHIFT_123_x2_Is_492()
        {
            uint a = 123;
            uint b = 2;
            uint result = 492;
            Gate op = new Gate_LSHIFT(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_RSHIFT_456_x2_Is_114()
        {
            uint a = 456;
            uint b = 2;
            uint result = 114;
            Gate op = new Gate_RSHIFT(a, b);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_NOT_123_Is_65412()
        {
            uint a = 123;
            uint result = 65412;
            Gate op = new Gate_NOT(a);
            Assert.AreEqual(result, op.Execute());
        }

        [TestMethod]
        [TestCategory("Day07")]
        public void Operation_NOT_456_Is_65079()
        {
            uint a = 456;
            uint result = 65079;
            Gate op = new Gate_NOT(a);
            Assert.AreEqual(result, op.Execute());
        }

    }
}
