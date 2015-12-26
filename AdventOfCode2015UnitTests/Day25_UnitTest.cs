using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day25_UnitTest
    {
        [TestMethod]
        [TestCategory("Day25")]
        public void GetMyCode_Row1_Column1_Returns_1()
        {
            Func <ulong, ulong> calculateMethod = Day25.CalculateNextCode_Incremental;
            ulong newCode = 1;
            Assert.AreEqual(newCode, Day25.GetMyCode(1, 1, calculateMethod));
        }

        [TestMethod]
        [TestCategory("Day25")]
        public void GetMyCode_Row1_Column2_Returns_3()
        {
            Func<ulong, ulong> calculateMethod = Day25.CalculateNextCode_Incremental;
            ulong newCode = 3;
            Assert.AreEqual(newCode, Day25.GetMyCode(1, 2, calculateMethod));
        }

        [TestMethod]
        [TestCategory("Day25")]
        public void GetMyCode_Row2_Column1_Returns_2()
        {
            Func<ulong, ulong> calculateMethod = Day25.CalculateNextCode_Incremental;
            ulong newCode = 2;
            Assert.AreEqual(newCode, Day25.GetMyCode(2, 1, calculateMethod));
        }

        [TestMethod]
        [TestCategory("Day25")]
        public void GetMyCode_Row6_Column1_Returns_16()
        {
            Func<ulong, ulong> calculateMethod = Day25.CalculateNextCode_Incremental;
            ulong newCode = 16;
            Assert.AreEqual(newCode, Day25.GetMyCode(6, 1, calculateMethod));
        }

        [TestMethod]
        [TestCategory("Day25")]
        public void GetMyCode_Row1_Column6_Returns_21()
        {
            Func<ulong, ulong> calculateMethod = Day25.CalculateNextCode_Incremental;
            ulong newCode = 21;
            Assert.AreEqual(newCode, Day25.GetMyCode(1, 6, calculateMethod));
        }

        [TestMethod]
        [TestCategory("Day25")]
        public void GetMyCode_Complex_Row1_Column1_Returns_20151125()
        {
            Func<ulong, ulong> calculateMethod = Day25.CalculateNextCode_Complex;
            ulong newCode = 20151125;
            Assert.AreEqual(newCode, Day25.GetMyCode(20151125, 1, 1, calculateMethod));
        }

        [TestMethod]
        [TestCategory("Day25")]
        public void GetMyCode_Complex_Row5_Column1_Returns_77061()
        {
            Func<ulong, ulong> calculateMethod = Day25.CalculateNextCode_Complex;
            ulong newCode = 77061;
            Assert.AreEqual(newCode, Day25.GetMyCode(20151125, 5, 1, calculateMethod));
        }

        [TestMethod]
        [TestCategory("Day25")]
        public void GetMyCode_CalculateCode_PreviousCode_20151125_Returns_31916031()
        {
            ulong previousCode = 20151125;
            ulong newCode = 31916031;
            Assert.AreEqual(newCode, Day25.CalculateNextCode_Complex(previousCode));
        }
    }
}
