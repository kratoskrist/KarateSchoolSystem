using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateSchoolSystem.Tests
{
    [TestClass]
    public class BeltTests
    {
        [TestMethod]
        public void Constructor_ValidData_CreatesBelt()
        {
            Belt belt = TestData.CreateWhiteBelt();

            Assert.AreEqual(1, belt.BeltId);
            Assert.AreEqual("White", belt.BeltColor);
            Assert.AreEqual(0, belt.RankOrder);
        }

        [TestMethod]
        public void Constructor_InvalidId_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Belt(0, "White", 0, "Basic skills"));
        }

        [TestMethod]
        public void Constructor_BlankColor_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Belt(1, "", 0, "Basic skills"));
        }

        [TestMethod]
        public void Constructor_NegativeRank_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Belt(1, "White", -1, "Basic skills"));
        }

        [TestMethod]
        public void Constructor_BlankRequirements_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Belt(1, "White", 0, ""));
        }

        [TestMethod]
        public void GenerateReport_ReturnsBeltInformation()
        {
            Belt belt = TestData.CreateWhiteBelt();

            StringAssert.Contains(belt.GenerateReport(), "White");
        }

        [TestMethod]
        public void ToString_ReturnsMeaningfulText()
        {
            Belt belt = TestData.CreateWhiteBelt();

            Assert.AreEqual("White Belt - Rank 0", belt.ToString());
        }
    }
}
