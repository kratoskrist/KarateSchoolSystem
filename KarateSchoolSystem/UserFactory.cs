using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Creates user objects based on the selected role.
    /// </summary>
    public static class UserFactory
    {
        public static User CreateUser(
            string role,
            int id,
            string firstName,
            string lastName,
            string email,
            string password)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentException("Role is required.");
            }

            switch (role.Trim().ToLower())
            {
                case "student":
                    Belt whiteBelt = new Belt(
                        1,
                        "White",
                        0,
                        "Basic stance and etiquette");

                    return new Student(
                        id,
                        firstName,
                        lastName,
                        email,
                        password,
                        DateTime.Today,
                        whiteBelt,
                        "Active");

                case "instructor":
                    return new Instructor(
                        id,
                        firstName,
                        lastName,
                        email,
                        password,
                        "General Karate",
                        DateTime.Today,
                        "Active");

                case "administrator":
                case "admin":
                    return new Administrator(
                        id,
                        firstName,
                        lastName,
                        email,
                        password,
                        "Administration",
                        3);

                default:
                    throw new ArgumentException(
                        "Role must be Student, Instructor, or Administrator.");
            }
        }
    }
}
