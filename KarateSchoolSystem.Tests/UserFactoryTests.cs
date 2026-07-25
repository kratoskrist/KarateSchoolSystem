using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateSchoolSystem.Tests
{
    [TestClass]
    public class UserFactoryTests
    {
        [TestMethod]
        public void CreateUser_StudentRole_ReturnsStudent()
        {
            User user = UserFactory.CreateUser(
                "Student",
                1,
                "Anna",
                "Lee",
                "anna@email.com",
                "secret1");

            Assert.IsInstanceOfType<Student>(user);
        }

        [TestMethod]
        public void CreateUser_InstructorRole_ReturnsInstructor()
        {
            User user = UserFactory.CreateUser(
                "Instructor",
                2,
                "Daniel",
                "Kim",
                "daniel@email.com",
                "secret2");

            Assert.IsInstanceOfType<Instructor>(user);
        }

        [TestMethod]
        public void CreateUser_AdministratorRole_ReturnsAdministrator()
        {
            User user = UserFactory.CreateUser(
                "Administrator",
                3,
                "Maria",
                "Jones",
                "maria@email.com",
                "secret3");

            Assert.IsInstanceOfType<Administrator>(user);
        }

        [TestMethod]
        public void CreateUser_AdminRole_ReturnsAdministrator()
        {
            User user = UserFactory.CreateUser(
                "Admin",
                3,
                "Maria",
                "Jones",
                "maria@email.com",
                "secret3");

            Assert.IsInstanceOfType<Administrator>(user);
        }

        [TestMethod]
        public void CreateUser_BlankRole_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                UserFactory.CreateUser(
                    "",
                    1,
                    "Anna",
                    "Lee",
                    "anna@email.com",
                    "secret1"));
        }

        [TestMethod]
        public void CreateUser_UnknownRole_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                UserFactory.CreateUser(
                    "Ninja Accountant",
                    1,
                    "Anna",
                    "Lee",
                    "anna@email.com",
                    "secret1"));
        }

        [TestMethod]
        public void UserReference_CanHoldDifferentDerivedTypes()
        {
            User student = UserFactory.CreateUser(
                "Student",
                1,
                "Anna",
                "Lee",
                "anna@email.com",
                "secret1");

            User instructor = UserFactory.CreateUser(
                "Instructor",
                2,
                "Daniel",
                "Kim",
                "daniel@email.com",
                "secret2");

            Assert.AreNotEqual(
                student.GetRoleDescription(),
                instructor.GetRoleDescription());
        }
    }
}
