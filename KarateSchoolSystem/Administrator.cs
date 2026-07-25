using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Represents an administrator with system privileges.
    /// </summary>
    public class Administrator : User, IReportable
    {
        public int AdminId => UserId;
        public string Department { get; }
        public int AccessLevel { get; }

        public Administrator(
            int adminId,
            string firstName,
            string lastName,
            string email,
            string password,
            string department,
            int accessLevel)
            : base(
                adminId,
                firstName,
                lastName,
                email,
                password,
                "Administrator")
        {
            if (string.IsNullOrWhiteSpace(department))
            {
                throw new ArgumentException(
                    "Department is required.");
            }

            if (accessLevel < 1 || accessLevel > 5)
            {
                throw new ArgumentException(
                    "Access level must be between 1 and 5.");
            }

            Department = department.Trim();
            AccessLevel = accessLevel;
        }

        public Announcement CreateAnnouncement(
            int announcementId,
            string title,
            string message,
            DateTime postedDate)
        {
            if (AccessLevel < 2)
            {
                throw new InvalidOperationException(
                    "Administrator is not authorized to create announcements.");
            }

            return new Announcement(
                announcementId,
                title,
                message,
                postedDate,
                this);
        }

        public override string GetRoleDescription()
        {
            return $"Administrator in {Department} with access level " +
                   $"{AccessLevel}";
        }

        public string GenerateReport()
        {
            return $"Administrator Report: {FirstName} {LastName}, " +
                   $"Department: {Department}, Access Level: {AccessLevel}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Department: {Department} - " +
                   $"Access Level: {AccessLevel}";
        }
    }
}
