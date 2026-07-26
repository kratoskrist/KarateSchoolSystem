using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateSchoolSystem.Tests
{
    [TestClass]
    public class UserTests
    {
        // Test-only class used to access User's protected constructor.
        private class TestUser : User
        {
            public TestUser(
                int userId,
                string firstName,
                string lastName,
                string email,
                string password,
                string role)
                : base(
                    userId,
                    firstName,
                    lastName,
                    email,
                    password,
                    role)
            {
            }

            public override string GetRoleDescription()
            {
                return "Test user";
            }
        }

        [TestMethod]
        public void Constructor_BlankRole_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new TestUser(
                    1,
                    "Anna",
                    "Lee",
                    "anna@email.com",
                    "secret1",
                    ""));
        }
    }
}
