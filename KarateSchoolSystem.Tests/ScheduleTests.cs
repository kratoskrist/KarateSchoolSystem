using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateSchoolSystem.Tests
{
    [TestClass]
    public class ScheduleTests
    {
        [TestMethod]
        public void Constructor_ValidData_CreatesSchedule()
        {
            Schedule schedule = new Schedule(
                1,
                DayOfWeek.Monday,
                new TimeSpan(18, 0, 0),
                new TimeSpan(19, 0, 0),
                "A101");

            Assert.AreEqual(DayOfWeek.Monday, schedule.DayOfWeek);
            Assert.AreEqual("A101", schedule.Room);
        }

        [TestMethod]
        public void Constructor_InvalidId_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Schedule(
                    0,
                    DayOfWeek.Monday,
                    new TimeSpan(18, 0, 0),
                    new TimeSpan(19, 0, 0),
                    "A101"));
        }

        [TestMethod]
        public void Constructor_EndBeforeStart_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Schedule(
                    1,
                    DayOfWeek.Monday,
                    new TimeSpan(19, 0, 0),
                    new TimeSpan(18, 0, 0),
                    "A101"));
        }

        [TestMethod]
        public void Constructor_BlankRoom_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Schedule(
                    1,
                    DayOfWeek.Monday,
                    new TimeSpan(18, 0, 0),
                    new TimeSpan(19, 0, 0),
                    ""));
        }

        [TestMethod]
        public void ToString_ReturnsScheduleInformation()
        {
            Schedule schedule = new Schedule(
                1,
                DayOfWeek.Monday,
                new TimeSpan(18, 0, 0),
                new TimeSpan(19, 0, 0),
                "A101");

            StringAssert.Contains(schedule.ToString(), "Monday");
            StringAssert.Contains(schedule.ToString(), "A101");
        }
    }
}
