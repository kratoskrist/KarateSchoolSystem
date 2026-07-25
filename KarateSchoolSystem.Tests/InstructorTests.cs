using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateSchoolSystem.Tests
{
    [TestClass]
    public class InstructorTests
    {
        [TestMethod]
        public void Constructor_ValidData_CreatesInstructor()
        {
            Instructor instructor = TestData.CreateInstructor();

            Assert.AreEqual("Kata", instructor.Specialty);
            Assert.AreEqual("Instructor", instructor.Role);
        }

        [TestMethod]
        public void Constructor_BlankSpecialty_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Instructor(
                    2,
                    "Daniel",
                    "Kim",
                    "daniel@email.com",
                    "secret2",
                    "",
                    DateTime.Today,
                    "Active"));
        }

        [TestMethod]
        public void Constructor_FutureHireDate_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Instructor(
                    2,
                    "Daniel",
                    "Kim",
                    "daniel@email.com",
                    "secret2",
                    "Kata",
                    DateTime.Today.AddDays(1),
                    "Active"));
        }

        [TestMethod]
        public void Constructor_BlankStatus_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Instructor(
                    2,
                    "Daniel",
                    "Kim",
                    "daniel@email.com",
                    "secret2",
                    "Kata",
                    DateTime.Today,
                    ""));
        }

        [TestMethod]
        public void GetRoleDescription_ReturnsSpecialty()
        {
            Instructor instructor = TestData.CreateInstructor();

            StringAssert.Contains(
                instructor.GetRoleDescription(),
                "Kata");
        }

        [TestMethod]
        public void GenerateReport_ReturnsInstructorReport()
        {
            Instructor instructor = TestData.CreateInstructor();

            StringAssert.Contains(
                instructor.GenerateReport(),
                "Instructor Report");
        }

        [TestMethod]
        public void ToString_ReturnsMeaningfulText()
        {
            Instructor instructor = TestData.CreateInstructor();

            StringAssert.Contains(instructor.ToString(), "Kata");
        }
    }
}
