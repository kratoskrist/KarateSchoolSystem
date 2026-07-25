using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateSchoolSystem.Tests
{
    [TestClass]
    public class AnnouncementTests
    {
        [TestMethod]
        public void Constructor_ValidData_CreatesAnnouncement()
        {
            Announcement announcement = CreateAnnouncement();

            Assert.AreEqual("Holiday Closing", announcement.Title);
        }

        [TestMethod]
        public void Constructor_InvalidId_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Announcement(
                    0,
                    "Title",
                    "Message",
                    DateTime.Today,
                    TestData.CreateAdministrator()));
        }

        [TestMethod]
        public void Constructor_BlankTitle_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Announcement(
                    1,
                    "",
                    "Message",
                    DateTime.Today,
                    TestData.CreateAdministrator()));
        }

        [TestMethod]
        public void Constructor_BlankMessage_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Announcement(
                    1,
                    "Title",
                    "",
                    DateTime.Today,
                    TestData.CreateAdministrator()));
        }

        [TestMethod]
        public void Constructor_FutureDate_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Announcement(
                    1,
                    "Title",
                    "Message",
                    DateTime.Today.AddDays(1),
                    TestData.CreateAdministrator()));
        }

        [TestMethod]
        public void Constructor_NullAdministrator_ThrowsArgumentNullException()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
                new Announcement(
                    1,
                    "Title",
                    "Message",
                    DateTime.Today,
                    null!));
        }

        [TestMethod]
        public void ToString_ReturnsMeaningfulText()
        {
            Announcement announcement = CreateAnnouncement();

            StringAssert.Contains(
                announcement.ToString(),
                "Holiday Closing");
        }

        private static Announcement CreateAnnouncement()
        {
            return new Announcement(
                1,
                "Holiday Closing",
                "The school will be closed Monday.",
                DateTime.Today,
                TestData.CreateAdministrator());
        }
    }
}
