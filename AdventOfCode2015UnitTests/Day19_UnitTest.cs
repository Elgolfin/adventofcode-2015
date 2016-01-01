using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day19_UnitTest
    {
        [TestMethod][TestCategory("Day19")]
        public void Replace_H_By_HO_in_HOH()
        {
            string input = "HOH";
            MoleculeReplacement molRepl = new MoleculeReplacement(input, "H", "HO");
            Assert.AreEqual(2, molRepl.GenerateNewMolecule().Count);
        }

        [TestMethod]
        [TestCategory("Day19")]
        public void Replace_H_By_OH_in_HOH()
        {
            string input = "HOH";
            MoleculeReplacement molRepl = new MoleculeReplacement(input, "H", "OH");
            Assert.AreEqual(2, molRepl.GenerateNewMolecule().Count);
        }

        [TestMethod]
        [TestCategory("Day19")]
        public void Replace_O_By_HH_in_HOH()
        {
            string input = "HOH";
            MoleculeReplacement molRepl = new MoleculeReplacement(input, "O", "HH");
            Assert.AreEqual(1, molRepl.GenerateNewMolecule().Count);
        }
    }
}
