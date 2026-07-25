using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateSchoolSystem.Tests
{
    [TestClass]
    public class KarateClassTests
    {
        [TestMethod]
        public void Constructor_ValidData_CreatesClass()
        {
            KarateClass karateClass = TestData.CreateClass();

            Assert.AreEqual("Beginner Karate", karateClass.ClassName);
            Assert.AreEqual(10, karateClass.Capacity);
        }

        [TestMethod]
        public void Constructor_InvalidId_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new KarateClass(
                    0,
                    "Beginner Karate",
                    "Beginner",
                    10,
                    "Main Dojo"));
        }

        [TestMethod]
        public void Constructor_BlankName_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new KarateClass(
                    1,
                    "",
                    "Beginner",
                    10,
                    "Main Dojo"));
        }

        [TestMethod]
        public void Constructor_BlankLevel_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new KarateClass(
                    1,
                    "Beginner Karate",
                    "",
                    10,
                    "Main Dojo"));
        }

        [TestMethod]
        public void Constructor_InvalidCapacity_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                TestData.CreateClass(0));
        }

        [TestMethod]
        public void Constructor_BlankLocation_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new KarateClass(
                    1,
                    "Beginner Karate",
                    "Beginner",
                    10,
                    ""));
        }

        [TestMethod]
        public void AssignInstructor_ValidInstructor_AssignsInstructor()
        {
            KarateClass karateClass = TestData.CreateClass();
            Instructor instructor = TestData.CreateInstructor();

            karateClass.AssignInstructor(instructor);

            Assert.AreSame(instructor, karateClass.Instructor);
            Assert.AreEqual(1, instructor.ClassesTaught.Count);
        }

        [TestMethod]
        public void AssignInstructor_Null_ThrowsArgumentNullException()
        {
            KarateClass karateClass = TestData.CreateClass();

            Assert.ThrowsExactly<ArgumentNullException>(() =>
                karateClass.AssignInstructor(null!));
        }

        [TestMethod]
        public void SetSchedule_ValidSchedule_SetsSchedule()
        {
            KarateClass karateClass = TestData.CreateClass();

            Schedule schedule = new Schedule(
                1,
                DayOfWeek.Monday,
                new TimeSpan(18, 0, 0),
                new TimeSpan(19, 0, 0),
                "A101");

            karateClass.SetSchedule(schedule);

            Assert.AreSame(schedule, karateClass.Schedule);
        }

        [TestMethod]
        public void SetSchedule_Null_ThrowsArgumentNullException()
        {
            KarateClass karateClass = TestData.CreateClass();

            Assert.ThrowsExactly<ArgumentNullException>(() =>
                karateClass.SetSchedule(null!));
        }

        [TestMethod]
        public void EnrollStudent_ValidStudent_AddsStudent()
        {
            KarateClass karateClass = TestData.CreateClass();
            Student student = TestData.CreateStudent();

            karateClass.EnrollStudent(student);

            Assert.AreEqual(1, karateClass.Students.Count);
            Assert.AreEqual(1, student.EnrolledClasses.Count);
        }

        [TestMethod]
        public void EnrollStudent_DuplicateStudent_ThrowsException()
        {
            KarateClass karateClass = TestData.CreateClass();
            Student student = TestData.CreateStudent();

            karateClass.EnrollStudent(student);

            Assert.ThrowsExactly<InvalidOperationException>(() =>
                karateClass.EnrollStudent(student));
        }

        [TestMethod]
        public void EnrollStudent_ClassFull_ThrowsException()
        {
            KarateClass karateClass = TestData.CreateClass(1);

            karateClass.EnrollStudent(TestData.CreateStudent(1));

            Assert.ThrowsExactly<InvalidOperationException>(() =>
                karateClass.EnrollStudent(TestData.CreateStudent(2)));
        }

        [TestMethod]
        public void EnrollStudent_Null_ThrowsArgumentNullException()
        {
            KarateClass karateClass = TestData.CreateClass();

            Assert.ThrowsExactly<ArgumentNullException>(() =>
                karateClass.EnrollStudent(null!));
        }

        [TestMethod]
        public void RemoveStudent_EnrolledStudent_RemovesStudent()
        {
            KarateClass karateClass = TestData.CreateClass();
            Student student = TestData.CreateStudent();

            karateClass.EnrollStudent(student);
            karateClass.RemoveStudent(student);

            Assert.AreEqual(0, karateClass.Students.Count);
            Assert.AreEqual(0, student.EnrolledClasses.Count);
        }

        [TestMethod]
        public void RemoveStudent_NotEnrolled_ThrowsException()
        {
            KarateClass karateClass = TestData.CreateClass();
            Student student = TestData.CreateStudent();

            Assert.ThrowsExactly<InvalidOperationException>(() =>
                karateClass.RemoveStudent(student));
        }

        [TestMethod]
        public void RemoveStudent_Null_ThrowsArgumentNullException()
        {
            KarateClass karateClass = TestData.CreateClass();

            Assert.ThrowsExactly<ArgumentNullException>(() =>
                karateClass.RemoveStudent(null!));
        }

        [TestMethod]
        public void GenerateReport_ReturnsClassInformation()
        {
            KarateClass karateClass = TestData.CreateClass();

            StringAssert.Contains(
                karateClass.GenerateReport(),
                "Class Report");
        }

        [TestMethod]
        public void ToString_ReturnsMeaningfulText()
        {
            KarateClass karateClass = TestData.CreateClass();

            StringAssert.Contains(
                karateClass.ToString(),
                "Beginner Karate");
        }
    }
}
