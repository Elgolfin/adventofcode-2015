using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day23_UnitTest
    {
        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_hlf_a_0_returns_0()
        {
            string listing = "hlf a";
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing);
            comp.Run();
            Assert.AreEqual(0, comp.RegisterA);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_inc_a_0_returns_1()
        {
            string listing = "inc a";
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing);
            comp.Run();
            Assert.AreEqual(1, comp.RegisterA);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_hlf_a_1_returns_0()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("inc a");
            listing.AppendLine("hlf a");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(0, comp.RegisterA);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_hlf_a_2_returns_1()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("inc a");
            listing.AppendLine("inc a");
            listing.AppendLine("hlf a");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(1, comp.RegisterA);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_hlf_b_0_returns_0()
        {
            string listing = "hlf b";
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing);
            comp.Run();
            Assert.AreEqual(0, comp.RegisterB);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_inc_b_0_returns_1()
        {
            string listing = "inc b";
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing);
            comp.Run();
            Assert.AreEqual(1, comp.RegisterB);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_hlf_b_1_returns_0()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("inc b");
            listing.AppendLine("hlf b");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(0, comp.RegisterB);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_hlf_b_2_returns_1()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("inc b");
            listing.AppendLine("inc b");
            listing.AppendLine("hlf b");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(1, comp.RegisterB);
        }



        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_tpl_b_3_returns_9()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("inc b");
            listing.AppendLine("inc b");
            listing.AppendLine("inc b");
            listing.AppendLine("tpl b");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(9, comp.RegisterB);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_tpl_a_1_returns_3()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("inc a");
            listing.AppendLine("tpl a");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(3, comp.RegisterA);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_tpl_a_0_returns_0()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("inc b");
            listing.AppendLine("tpl a");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(0, comp.RegisterA);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_jmp_a_0_returns_2()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("inc a");
            listing.AppendLine("jmp +2");
            listing.AppendLine("tpl a");
            listing.AppendLine("inc a");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(2, comp.RegisterA);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_jie_a_0_returns_4()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("inc a");
            listing.AppendLine("jie a, +2");
            listing.AppendLine("tpl a");
            listing.AppendLine("inc a");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(4, comp.RegisterA);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_jie_a_0_returns_1()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("jie a, +2");
            listing.AppendLine("tpl a");
            listing.AppendLine("inc a");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(1, comp.RegisterA);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_jio_a_0_returns_1()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("jio a, +2");
            listing.AppendLine("tpl a");
            listing.AppendLine("inc a");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(1, comp.RegisterA);
        }

        [TestMethod]
        [TestCategory("Day23")]
        public void OpeningTheTuringLock_jie_a_0_returns_2()
        {
            StringBuilder listing = new StringBuilder();
            listing.AppendLine("inc a");
            listing.AppendLine("jio a, +2");
            listing.AppendLine("tpl a");
            listing.AppendLine("inc a");
            Computer comp = new Computer();
            comp.LoadProgramFromString(listing.ToString());
            comp.Run();
            Assert.AreEqual(2, comp.RegisterA);
        }

    }
}
