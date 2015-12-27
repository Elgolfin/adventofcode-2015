using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day06_Part1_UnitTest
    {
        [TestMethod]
        [TestCategory("Day06_Part1 - Binary")]
        public void CountLitLights_All_Of_Is_0()
        {
            LightsGrid grid = new BinaryLightsGrid();
            Assert.AreEqual(0, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part1 - Binary")]
        public void CountLitLights_Toggle_x1_All_Is_1000000()
        {
            LightsGrid grid = new BinaryLightsGrid();
            grid.ParseLights(0, 0, 999, 999, grid.ToggleLights);
            Assert.AreEqual(1000000, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part1 - Binary")]
        public void CountLitLights_TurnOn_All_Is_1000000()
        {
            LightsGrid grid = new BinaryLightsGrid();
            grid.ParseLights(0, 0, 999, 999, grid.TurnOnLights);
            Assert.AreEqual(1000000, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part1 - Binary")]
        public void CountLitLights_TurnOff_All_Is_0()
        {
            LightsGrid grid = new BinaryLightsGrid();
            grid.ParseLights(0, 0, 999, 999, grid.TurnOnLights);
            Assert.AreEqual(1000000, grid.CountLitLights());
            grid.ParseLights(0, 0, 999, 999, grid.TurnOffLights);
            Assert.AreEqual(0, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part1 - Binary")]
        public void CountLitLights_ResetGrid_Is_0()
        {
            LightsGrid grid = new BinaryLightsGrid();
            grid.ParseLights(0, 0, 999, 999, grid.ToggleLights);
            Assert.AreEqual(1000000, grid.CountLitLights());
            grid.ResetGrid();
            Assert.AreEqual(0, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part1 - Binary")]
        public void CountLitLights_Toggle_x2_All_Is_0()
        {
            LightsGrid grid = new BinaryLightsGrid();
            grid.ParseLights(0, 0, 999, 999, grid.ToggleLights);
            Assert.AreEqual(1000000, grid.CountLitLights());
            grid.ParseLights(0, 0, 999, 999, grid.ToggleLights);
            Assert.AreEqual(0, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part1 - Binary")]
        public void CountLitLights_ParseAction_turn_on_0_0_through_999_999_Is_1000000()
        {
            LightsGrid grid = new BinaryLightsGrid();
            grid.ParseAction("turn on 0,0 through 999,999");
            Assert.AreEqual(1000000, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part1 - Binary")]
        public void CountLitLights_ParseAction_toggle_0_0_through_999_0_Is_1000()
        {
            LightsGrid grid = new BinaryLightsGrid();
            grid.ParseAction("toggle 0,0 through 999,0");
            Assert.AreEqual(1000, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part1 - Binary")]
        public void CountLitLights_ParseAction_turn_off_499_499_through_500_500_and_toggle_all_Is_4()
        {

            LightsGrid grid = new BinaryLightsGrid();
            grid.ParseAction("turn on 0,0 through 999,999");
            grid.ParseAction("turn off 499,499 through 500,500");
            grid.ParseAction("toggle 0,0 through 999,999");
            Assert.AreEqual(4, grid.CountLitLights());
        }


    }

    [TestClass]
    public class Day06_Part2_UnitTest
    {
        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_All_Of_Is_0()
        {
            LightsGrid grid = new GradientLightsGrid();
            Assert.AreEqual(0, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_Toggle_x1_All_Is_2000000()
        {
            LightsGrid grid = new GradientLightsGrid();
            grid.ParseLights(0, 0, 999, 999, grid.ToggleLights);
            Assert.AreEqual(2000000, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_TurnOn_All_Is_1000000()
        {
            LightsGrid grid = new GradientLightsGrid();
            grid.ParseLights(0, 0, 999, 999, grid.TurnOnLights);
            Assert.AreEqual(1000000, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_TurnOff_All_Is_0()
        {
            LightsGrid grid = new GradientLightsGrid();
            grid.ParseLights(0, 0, 999, 999, grid.TurnOnLights);
            Assert.AreEqual(1000000, grid.CountLitLights());
            grid.ParseLights(0, 0, 999, 999, grid.TurnOffLights);
            Assert.AreEqual(0, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_ResetGrid_Is_0()
        {
            LightsGrid grid = new GradientLightsGrid();
            grid.ParseLights(0, 0, 999, 999, grid.ToggleLights);
            Assert.AreEqual(2000000, grid.CountLitLights());
            grid.ResetGrid();
            Assert.AreEqual(0, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_TurnOff_All_After_Toggle_All_Is_1000000()
        {
            LightsGrid grid = new GradientLightsGrid();
            grid.ParseLights(0, 0, 999, 999, grid.ToggleLights);
            Assert.AreEqual(2000000, grid.CountLitLights());
            grid.ParseLights(0, 0, 999, 999, grid.TurnOffLights);
            Assert.AreEqual(1000000, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_Toggle_x2_All_Is_4000000()
        {
            LightsGrid grid = new GradientLightsGrid();
            grid.ParseLights(0, 0, 999, 999, grid.ToggleLights);
            Assert.AreEqual(2000000, grid.CountLitLights());
            grid.ParseLights(0, 0, 999, 999, grid.ToggleLights);
            Assert.AreEqual(4000000, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_ParseAction_turn_on_0_0_through_999_999_Is_1000000()
        {
            LightsGrid grid = new GradientLightsGrid();
            grid.ParseAction("turn on 0,0 through 999,999");
            Assert.AreEqual(1000000, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_ParseAction_toggle_0_0_through_999_0_Is_2000()
        {
            LightsGrid grid = new GradientLightsGrid();
            grid.ParseAction("toggle 0,0 through 999,0");
            Assert.AreEqual(2000, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_ParseAction_turn_on_499_499_through_500_500_Is_4()
        {
            LightsGrid grid = new GradientLightsGrid();
            grid.ParseAction("turn on 499,499 through 500,500");
            Assert.AreEqual(4, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_ParseAction_turn_on_0_0_through_0_0_Is_1()
        {
            LightsGrid grid = new GradientLightsGrid();
            grid.ParseAction("turn on 0,0 through 0,0");
            Assert.AreEqual(1, grid.CountLitLights());
        }

        [TestMethod]
        [TestCategory("Day06_Part2 - Binary")]
        public void CountLitLights_ParseAction_turn_off_first_light_x2_Is_0()
        {
            LightsGrid grid = new GradientLightsGrid();
            grid.ParseAction("turn off 0,0 through 0,0");
            grid.ParseAction("turn off 0,0 through 0,0");
            Assert.AreEqual(0, grid.CountLitLights());
        }


    }
}
