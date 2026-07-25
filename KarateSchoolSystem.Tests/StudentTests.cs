using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateSchoolSystem.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Constructor_ValidData_CreatesStudent()
        {
            Belt belt = TestData.CreateWhiteBelt();
            Student student = TestData.CreateStudent();

            Assert.AreEqual(1, student.StudentId);
            Assert.AreEqual("Anna", student.FirstName);
            Assert.AreEqual("Lee", student.LastName);
            Assert.AreEqual("Student", student.Role);
            Assert.AreEqual("White", student.BeltLevel.BeltColor);
            Assert.AreEqual("Active", student.Status);
        }

        [TestMethod]
        public void Constructor_InvalidId_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Student(
                    0,
                    "Anna",
                    "Lee",
                    "anna@email.com",
                    "secret1",
                    DateTime.Today,
                    TestData.CreateWhiteBelt(),
                    "Active"));
        }

        [TestMethod]
        public void Constructor_BlankFirstName_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Student(
                    1,
                    "",
                    "Lee",
                    "anna@email.com",
                    "secret1",
                    DateTime.Today,
                    TestData.CreateWhiteBelt(),
                    "Active"));
        }

        [TestMethod]
        public void Constructor_BlankLastName_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Student(
                    1,
                    "Anna",
                    "",
                    "anna@email.com",
                    "secret1",
                    DateTime.Today,
                    TestData.CreateWhiteBelt(),
                    "Active"));
        }

        [TestMethod]
        public void Constructor_InvalidEmail_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Student(
                    1,
                    "Anna",
                    "Lee",
                    "not-an-email",
                    "secret1",
                    DateTime.Today,
                    TestData.CreateWhiteBelt(),
                    "Active"));
        }

        [TestMethod]
        public void Constructor_ShortPassword_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Student(
                    1,
                    "Anna",
                    "Lee",
                    "anna@email.com",
                    "123",
                    DateTime.Today,
                    TestData.CreateWhiteBelt(),
                    "Active"));
        }

        [TestMethod]
        public void Constructor_FutureEnrollmentDate_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Student(
                    1,
                    "Anna",
                    "Lee",
                    "anna@email.com",
                    "secret1",
                    DateTime.Today.AddDays(1),
                    TestData.CreateWhiteBelt(),
                    "Active"));
        }

        [TestMethod]
        public void Constructor_NullBelt_ThrowsArgumentNullException()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
                new Student(
                    1,
                    "Anna",
                    "Lee",
                    "anna@email.com",
                    "secret1",
                    DateTime.Today,
                    null!,
                    "Active"));
        }

        [TestMethod]
        public void Constructor_BlankStatus_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Student(
                    1,
                    "Anna",
                    "Lee",
                    "anna@email.com",
                    "secret1",
                    DateTime.Today,
                    TestData.CreateWhiteBelt(),
                    ""));
        }

        [TestMethod]
        public void PromoteBelt_HigherRank_ChangesBelt()
        {
            Student student = TestData.CreateStudent();

            Belt yellowBelt = new Belt(
                2,
                "Yellow",
                1,
                "Basic blocks and strikes");

            student.PromoteBelt(yellowBelt);

            Assert.AreEqual("Yellow", student.BeltLevel.BeltColor);
        }

        [TestMethod]
        public void PromoteBelt_SameRank_ThrowsInvalidOperationException()
        {
            Student student = TestData.CreateStudent();

            Belt anotherWhiteBelt = new Belt(
                2,
                "White",
                0,
                "Basic skills");

            Assert.ThrowsExactly<InvalidOperationException>(() =>
                student.PromoteBelt(anotherWhiteBelt));
        }

        [TestMethod]
        public void PromoteBelt_NullBelt_ThrowsArgumentNullException()
        {
            Student student = TestData.CreateStudent();

            Assert.ThrowsExactly<ArgumentNullException>(() =>
                student.PromoteBelt(null!));
        }

        [TestMethod]
        public void GetRoleDescription_ReturnsStudentDescription()
        {
            Student student = TestData.CreateStudent();

            string result = student.GetRoleDescription();

            StringAssert.Contains(result, "White");
        }

        [TestMethod]
        public void GenerateReport_ReturnsStudentReport()
        {
            Student student = TestData.CreateStudent();

            string result = student.GenerateReport();

            StringAssert.Contains(result, "Student Report");
            StringAssert.Contains(result, "Anna Lee");
        }

        [TestMethod]
        public void ToString_ReturnsMeaningfulText()
        {
            Student student = TestData.CreateStudent();

            string result = student.ToString();

            StringAssert.Contains(result, "Anna Lee");
            StringAssert.Contains(result, "White");
        }
    }
}
