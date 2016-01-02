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
            Assert.AreEqual(2, molRepl.GenerateNewMolecules().Count);
        }

        [TestMethod]
        [TestCategory("Day19")]
        public void Replace_H_By_OH_in_HOH()
        {
            string input = "HOH";
            MoleculeReplacement molRepl = new MoleculeReplacement(input, "H", "OH");
            Assert.AreEqual(2, molRepl.GenerateNewMolecules().Count);
        }

        [TestMethod]
        [TestCategory("Day19")]
        public void Replace_O_By_HH_in_HOH()
        {
            string input = "HOH";
            MoleculeReplacement molRepl = new MoleculeReplacement(input, "O", "HH");
            Assert.AreEqual(1, molRepl.GenerateNewMolecules().Count);
        }

        [TestMethod]
        [TestCategory("Day19")]
        public void Calibrate_Machine_For_HOH_returns_4()
        {
            string input = "HOH";
            MoleculeConstructionMachine machine = new MoleculeConstructionMachine(input);
            MoleculeReplacement molRepl_1 = new MoleculeReplacement(input, "H", "HO");
            MoleculeReplacement molRepl_2 = new MoleculeReplacement(input, "H", "OH");
            MoleculeReplacement molRepl_3 = new MoleculeReplacement(input, "O", "HH");
            machine.AddMoleculeReplacement(molRepl_1);
            machine.AddMoleculeReplacement(molRepl_2);
            machine.AddMoleculeReplacement(molRepl_3);
            int newPossiblesMolecules = machine.Calibrate();
            Assert.AreEqual(4, newPossiblesMolecules);
        }
    }
}
