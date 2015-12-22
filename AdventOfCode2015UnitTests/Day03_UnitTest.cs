using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day03_UnitTest
    {
        //[TestCleanup]
        //public void CleanUp()
        //{

        //}

        [TestMethod][TestCategory("Day03")]
        public void PerfectlySphericalHousesInAVacuum_Simple1()
        {
            string directions = ">";
            HousesGrid grid = new HousesGrid();
            grid.GoDirections(directions);
            Assert.AreEqual(2, grid.GetHousesWithAtLeastOnePresent());
        }

        [TestMethod]
        [TestCategory("Day03")]
        public void PerfectlySphericalHousesInAVacuum_Simple2()
        {
            string directions = "^>v<";
            HousesGrid grid = new HousesGrid();
            grid.GoDirections(directions);
            Assert.AreEqual(4, grid.GetHousesWithAtLeastOnePresent());
        }

        [TestMethod]
        [TestCategory("Day03")]
        public void PerfectlySphericalHousesInAVacuum_Simple3()
        {
            string directions = "^v^v^v^v^v";
            HousesGrid grid = new HousesGrid();
            grid.GoDirections(directions);
            Assert.AreEqual(2, grid.GetHousesWithAtLeastOnePresent());
        }
    }
}
