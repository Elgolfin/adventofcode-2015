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




        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House1()
        {
            Assert.AreEqual(11, Day20.CalculatePresents_Limited(1, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House2()
        {
            Assert.AreEqual(33, Day20.CalculatePresents_Limited(2, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House3()
        {
            Assert.AreEqual(44, Day20.CalculatePresents_Limited(3, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House4()
        {
            Assert.AreEqual(77, Day20.CalculatePresents_Limited(4, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House5()
        {
            Assert.AreEqual(66, Day20.CalculatePresents_Limited(5, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House6()
        {
            Assert.AreEqual(132, Day20.CalculatePresents_Limited(6, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House7()
        {
            Assert.AreEqual(88, Day20.CalculatePresents_Limited(7, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House8()
        {
            Assert.AreEqual(165, Day20.CalculatePresents_Limited(8, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House9()
        {
            Assert.AreEqual(143, Day20.CalculatePresents_Limited(9, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House10()
        {
            Assert.AreEqual(198, Day20.CalculatePresents_Limited(10, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House50()
        {
            Assert.AreEqual(1023, Day20.CalculatePresents_Limited(50, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House51()
        {
            Assert.AreEqual(781, Day20.CalculatePresents_Limited(51, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House100()
        {
            Assert.AreEqual(2376, Day20.CalculatePresents_Limited(100, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House101()
        {
            Assert.AreEqual(1111, Day20.CalculatePresents_Limited(101, 50));
        }

        [TestMethod]
        [TestCategory("Day20")]
        public void InfiniteElvesAndInfiniteHouses_CalculatePresentsLimited_House102()
        {
            Assert.AreEqual(2343, Day20.CalculatePresents_Limited(102, 50));
        }

    }
}
