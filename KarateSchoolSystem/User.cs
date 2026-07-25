using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace KarateSchoolSystem
{
    /// <summary>
    /// represents a general user of the karate school system.
    /// </summary>
    public abstract class User
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;

        public int UserId { get; }

        public string FirstName
        {
            get => _firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name is required.");
                }

                _firstName = value.Trim();
            }
        }

        public string LastName
        {
            get => _lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name is required.");
                }

                _lastName = value.Trim();
            }
        }

        public string Email
        {
            get => _email;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email is required.");
                }

                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentException("Email format is invalid.");
                }

                _email = value.Trim();
            }
        }

        public string Password
        {
            get => _password;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password is required.");
                }

                if (value.Length < 6)
                {
                    throw new ArgumentException("Password must contain at least six characters.");
                }

                _password = value;
            }
        }

        public string Role { get; protected set; }

        protected User(
            int userId,
            string firstName,
            string lastName,
            string email,
            string password,
            string role)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("User ID must be greater thatn zero.");
            }

            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentException("Role is required.");
            }

            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role.Trim();
        }

        /// <summary>
        /// Produces role-specific information about the user.
        /// </summary>
        public abstract string GetRoleDescription();

        public override string ToString()
        {
            return $"{UserId}: {FirstName} {LastName} - {Role} - {Email}";
        }
    }
}
