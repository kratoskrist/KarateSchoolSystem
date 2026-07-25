using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateSchoolSystem.Tests
{
    [TestClass]
    public class AttendanceTests
    {
        [TestMethod]
        public void Constructor_ValidData_CreatesAttendance()
        {
            Student student = TestData.CreateStudent();
            KarateClass karateClass = TestData.CreateClass();

            Attendance attendance = new Attendance(
                1,
                DateTime.Today,
                "Present",
                student,
                karateClass);

            Assert.AreEqual("Present", attendance.Status);
            Assert.AreSame(student, attendance.Student);
        }

        [TestMethod]
        public void Constructor_InvalidId_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Attendance(
                    0,
                    DateTime.Today,
                    "Present",
                    TestData.CreateStudent(),
                    TestData.CreateClass()));
        }

        [TestMethod]
        public void Constructor_FutureDate_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Attendance(
                    1,
                    DateTime.Today.AddDays(1),
                    "Present",
                    TestData.CreateStudent(),
                    TestData.CreateClass()));
        }

        [TestMethod]
        public void Constructor_BlankStatus_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Attendance(
                    1,
                    DateTime.Today,
                    "",
                    TestData.CreateStudent(),
                    TestData.CreateClass()));
        }

        [TestMethod]
        public void Constructor_InvalidStatus_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Attendance(
                    1,
                    DateTime.Today,
                    "Late",
                    TestData.CreateStudent(),
                    TestData.CreateClass()));
        }

        [TestMethod]
        public void Constructor_NullStudent_ThrowsArgumentNullException()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
                new Attendance(
                    1,
                    DateTime.Today,
                    "Present",
                    null!,
                    TestData.CreateClass()));
        }

        [TestMethod]
        public void Constructor_NullClass_ThrowsArgumentNullException()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
                new Attendance(
                    1,
                    DateTime.Today,
                    "Present",
                    TestData.CreateStudent(),
                    null!));
        }

        [TestMethod]
        public void RecordAttendance_EnrolledStudent_RecordsAttendance()
        {
            Student student = TestData.CreateStudent();
            KarateClass karateClass = TestData.CreateClass();
            karateClass.EnrollStudent(student);

            Attendance attendance = new Attendance(
                1,
                DateTime.Today,
                "Present",
                student,
                karateClass);

            karateClass.RecordAttendance(attendance);

            Assert.AreEqual(1, karateClass.AttendanceRecords.Count);
            Assert.AreEqual(1, student.AttendanceRecords.Count);
        }

        [TestMethod]
        public void RecordAttendance_NotEnrolled_ThrowsException()
        {
            Student student = TestData.CreateStudent();
            KarateClass karateClass = TestData.CreateClass();

            Attendance attendance = new Attendance(
                1,
                DateTime.Today,
                "Present",
                student,
                karateClass);

            Assert.ThrowsExactly<InvalidOperationException>(() =>
                karateClass.RecordAttendance(attendance));
        }

        [TestMethod]
        public void RecordAttendance_Null_ThrowsArgumentNullException()
        {
            KarateClass karateClass = TestData.CreateClass();

            Assert.ThrowsExactly<ArgumentNullException>(() =>
                karateClass.RecordAttendance(null!));
        }

        [TestMethod]
        public void ToString_ReturnsMeaningfulText()
        {
            Student student = TestData.CreateStudent();

            Attendance attendance = new Attendance(
                1,
                DateTime.Today,
                "Present",
                student,
                TestData.CreateClass());

            StringAssert.Contains(attendance.ToString(), "Anna Lee");
            StringAssert.Contains(attendance.ToString(), "Present");
        }
    }
}
