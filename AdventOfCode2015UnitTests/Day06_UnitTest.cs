using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day06_UnitTest
    {
        [TestMethod][TestCategory("Day06")]
        public void NotQuiteLisp_Simple()
        {
            Assert.AreEqual(1, Day06.GetLitLights());
        }
    }
}
