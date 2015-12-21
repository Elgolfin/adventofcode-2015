using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day20_UnitTest
    {

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresents_House1()
        {
            Assert.AreEqual(10, Day20.CalculatePresents(1));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresents_House2()
        {
            Assert.AreEqual(30, Day20.CalculatePresents(2));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresents_House3()
        {
            Assert.AreEqual(40, Day20.CalculatePresents(3));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresents_House4()
        {
            Assert.AreEqual(70, Day20.CalculatePresents(4));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresents_House5()
        {
            Assert.AreEqual(60, Day20.CalculatePresents(5));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresents_House6()
        {
            Assert.AreEqual(120, Day20.CalculatePresents(6));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresents_House7()
        {
            Assert.AreEqual(80, Day20.CalculatePresents(7));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresents_House8()
        {
            Assert.AreEqual(150, Day20.CalculatePresents(8));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresents_House9()
        {
            Assert.AreEqual(130, Day20.CalculatePresents(9));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresents_House10()
        {
            Assert.AreEqual(180, Day20.CalculatePresents(10));
        }


        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_ComputePresents_House1()
        {
            int total = 0;
            foreach (int value in Day20.ComputePresents(1))
            {
                total = value;
            }
            Assert.AreEqual(10, total);
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_ComputePresents_House10()
        {
            int total = 0;
            foreach (int value in Day20.ComputePresents(870))
            {
                total = value;
            }
            Assert.AreEqual(870, total);
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_ComputeHouses_House1()
        {
            int total = 0;
            foreach (int value in Day20.ComputeHouses(1))
            {
                total = value;
            }
            Assert.AreEqual(1, total);
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_ComputeHouses_House10()
        {
            int total = 0;
            foreach (int value in Day20.ComputeHouses(870))
            {
                total = value;
            }
            Assert.AreEqual(10, total);
        }




        

    }
}
