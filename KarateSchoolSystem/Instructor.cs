using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Represents a karate instructor.
    /// </summary>
    public class Instructor : User, IReportable
    {
        private readonly List<KarateClass> _classesTaught = new();

        public int InstructorId => UserId;
        public string Specialty { get; }
        public DateTime HireDate { get; }
        public string Status { get; private set; }

        public IReadOnlyList<KarateClass> ClassesTaught =>
            _classesTaught.AsReadOnly();

        public Instructor(
            int instructorId,
            string firstName,
            string lastName,
            string email,
            string password,
            string specialty,
            DateTime hireDate,
            string status)
            : base(
                instructorId,
                firstName,
                lastName,
                email,
                password,
                "Instructor")
        {
            if (string.IsNullOrWhiteSpace(specialty))
            {
                throw new ArgumentException(
                    "Instructor specialty is required.");
            }

            if (hireDate > DateTime.Today)
            {
                throw new ArgumentException(
                    "Hire date cannot be in the future.");
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException(
                    "Instructor status is required.");
            }

            Specialty = specialty.Trim();
            HireDate = hireDate;
            Status = status.Trim();
        }

        internal void AddClass(KarateClass karateClass)
        {
            if (!_classesTaught.Contains(karateClass))
            {
                _classesTaught.Add(karateClass);
            }
        }

        public override string GetRoleDescription()
        {
            return $"Instructor specializing in {Specialty}";
        }

        public string GenerateReport()
        {
            return $"Instructor Report: {FirstName} {LastName}, " +
                   $"Specialty: {Specialty}, Classes: {_classesTaught.Count}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Specialty: {Specialty} - " +
                   $"Status: {Status}";
        }
    }
}
