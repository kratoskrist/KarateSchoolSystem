using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Represents a student enrolled at the karate school.
    /// </summary>
    public class Student : User, IReportable
    {
        private readonly List<KarateClass> _enrolledClasses = new();
        private readonly List<Attendance> _attendanceRecords = new();
        private readonly List<Payment> _payments = new();

        public int StudentId => UserId;
        public DateTime EnrollmentDate { get; }
        public Belt BeltLevel { get; private set; }
        public string Status { get; private set; }

        public IReadOnlyList<KarateClass> EnrolledClasses =>
            _enrolledClasses.AsReadOnly();

        public IReadOnlyList<Attendance> AttendanceRecords =>
            _attendanceRecords.AsReadOnly();

        public IReadOnlyList<Payment> Payments =>
            _payments.AsReadOnly();

        public Student(
            int studentId,
            string firstName,
            string lastName,
            string email,
            string password,
            DateTime enrollmentDate,
            Belt beltLevel,
            string status)
            : base(
                studentId,
                firstName,
                lastName,
                email,
                password,
                "Student")
        {
            if (enrollmentDate > DateTime.Today)
            {
                throw new ArgumentException(
                    "Enrollment date cannot be in the future.");
            }

            BeltLevel = beltLevel ??
                throw new ArgumentNullException(nameof(beltLevel));

            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Student status is required.");
            }

            EnrollmentDate = enrollmentDate;
            Status = status.Trim();
        }

        public void PromoteBelt(Belt newBelt)
        {
            if (newBelt == null)
            {
                throw new ArgumentNullException(nameof(newBelt));
            }

            if (newBelt.RankOrder <= BeltLevel.RankOrder)
            {
                throw new InvalidOperationException(
                    "The new belt must be a higher rank.");
            }

            BeltLevel = newBelt;
        }

        internal void AddClass(KarateClass karateClass)
        {
            if (!_enrolledClasses.Contains(karateClass))
            {
                _enrolledClasses.Add(karateClass);
            }
        }

        internal void RemoveClass(KarateClass karateClass)
        {
            _enrolledClasses.Remove(karateClass);
        }

        public void AddAttendance(Attendance attendance)
        {
            if (attendance == null)
            {
                throw new ArgumentNullException(nameof(attendance));
            }

            _attendanceRecords.Add(attendance);
        }

        public void AddPayment(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }

            _payments.Add(payment);
        }

        public override string GetRoleDescription()
        {
            return $"Student with {BeltLevel.BeltColor} belt";
        }

        public string GenerateReport()
        {
            return $"Student Report: {FirstName} {LastName}, " +
                   $"Belt: {BeltLevel.BeltColor}, Status: {Status}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Belt: {BeltLevel.BeltColor} - " +
                   $"Status: {Status}";
        }
    }
}
