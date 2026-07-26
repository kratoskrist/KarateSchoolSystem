using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateSchoolSystem.Tests
{
    [TestClass]
    public class AdministratorTests
    {
        [TestMethod]
        public void ConstructorValidDataCreatesAdministrator()
        {
            Administrator administrator =
                TestData.CreateAdministrator();

            Assert.AreEqual("Operations", administrator.Department);
            Assert.AreEqual(3, administrator.AccessLevel);
        }

        [TestMethod]
        public void Constructor_BlankDepartment_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Administrator(
                    3,
                    "Maria",
                    "Jones",
                    "maria@email.com",
                    "secret3",
                    "",
                    3));
        }

        [TestMethod]
        public void Constructor_InvalidAccessLevel_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                TestData.CreateAdministrator(accessLevel: 0));
        }

        [TestMethod]
        public void CreateAnnouncement_AuthorizedAdmin_CreatesAnnouncement()
        {
            Administrator administrator =
                TestData.CreateAdministrator();

            Announcement announcement =
                administrator.CreateAnnouncement(
                    1,
                    "Holiday Closing",
                    "The school will be closed Monday.",
                    DateTime.Today);

            Assert.AreEqual("Holiday Closing", announcement.Title);
            Assert.AreSame(administrator, announcement.CreatedBy);
        }

        [TestMethod]
        public void CreateAnnouncement_UnauthorizedAdmin_ThrowsException()
        {
            Administrator administrator =
                TestData.CreateAdministrator(accessLevel: 1);

            Assert.ThrowsExactly<InvalidOperationException>(() =>
                administrator.CreateAnnouncement(
                    1,
                    "Title",
                    "Message",
                    DateTime.Today));
        }

        [TestMethod]
        public void GetRoleDescription_ReturnsAdministratorDescription()
        {
            Administrator administrator =
                TestData.CreateAdministrator();

            StringAssert.Contains(
                administrator.GetRoleDescription(),
                "Operations");
        }

        [TestMethod]
        public void GenerateReport_ReturnsAdministratorReport()
        {
            Administrator administrator =
                TestData.CreateAdministrator();

            StringAssert.Contains(
                administrator.GenerateReport(),
                "Administrator Report");
        }

        [TestMethod]
        public void ToString_ReturnsMeaningfulText()
        {
            Administrator administrator =
                TestData.CreateAdministrator();

            StringAssert.Contains(
                administrator.ToString(),
                "Access Level");
        }

        [TestMethod]
        public void Constructor_ValidData_CreatesAdministrator()
        {
            Administrator administrator =
                TestData.CreateAdministrator();

            Assert.AreEqual(3, administrator.AdminId);
            Assert.AreEqual("Operations", administrator.Department);
            Assert.AreEqual(3, administrator.AccessLevel);
        }
    }
}
