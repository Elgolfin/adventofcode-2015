using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    /// <summary>
    /// Summary description for Day2_UnitTest
    /// </summary>
    [TestClass]
    public class Day2_UnitTest
    {
        
        [TestMethod]
        public void IWasToldThereWouldBeNoMath_BasicConstructor_Box_1x1x1()
        {
            Box box = new Box("1x1x1");
            Assert.AreEqual(box.Length, 1);
            Assert.AreEqual(box.Width, 1);
            Assert.AreEqual(box.Height, 1);
        }

        [TestMethod]
        public void IWasToldThereWouldBeNoMath_Box_2x3x4()
        {
            Box box = new Box("2x3x4");
            Assert.AreEqual(box.Length, 2);
            Assert.AreEqual(box.Width, 3);
            Assert.AreEqual(box.Height, 4);
            Assert.AreEqual(52, box.Area);
            Assert.AreEqual(24, box.Volume);
            Assert.AreEqual(58, box.GetNeededWrappingPaper());
            Assert.AreEqual(34, box.GetNeededRibbonLength());
        }

        [TestMethod]
        public void IWasToldThereWouldBeNoMath_Box_1x1x10()
        {
            Box box = new Box("1x1x10");
            Assert.AreEqual(box.Length, 1);
            Assert.AreEqual(box.Width, 1);
            Assert.AreEqual(box.Height, 10);
            Assert.AreEqual(42, box.Area);
            Assert.AreEqual(10, box.Volume);
            Assert.AreEqual(43, box.GetNeededWrappingPaper());
            Assert.AreEqual(14, box.GetNeededRibbonLength());
        }


    }
}
