using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Represents one attendance record for a student and class.
    /// </summary>
    public class Attendance
    {
        private static readonly string[] ValidStatuses =
        {
            "Present",
            "Absent",
            "Excused"
        };

        public int AttendanceId { get; }
        public DateTime Date { get; }
        public string Status { get; }
        public Student Student { get; }
        public KarateClass KarateClass { get; }

        public Attendance(
            int attendanceId,
            DateTime date,
            string status,
            Student student,
            KarateClass karateClass)
        {
            if (attendanceId <= 0)
            {
                throw new ArgumentException(
                    "Attendance ID must be greater than zero.");
            }

            if (date.Date > DateTime.Today)
            {
                throw new ArgumentException(
                    "Attendance cannot be recorded for a future date.");
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException(
                    "Attendance status is required.");
            }

            bool validStatus = Array.Exists(
                ValidStatuses,
                item => item.Equals(
                    status,
                    StringComparison.OrdinalIgnoreCase));

            if (!validStatus)
            {
                throw new ArgumentException(
                    "Attendance status must be Present, Absent, or Excused.");
            }

            Student = student ??
                throw new ArgumentNullException(nameof(student));

            KarateClass = karateClass ??
                throw new ArgumentNullException(nameof(karateClass));

            AttendanceId = attendanceId;
            Date = date.Date;
            Status = status.Trim();
        }

        public override string ToString()
        {
            return $"{Student.FirstName} {Student.LastName}: " +
                   $"{Status} on {Date:d}";
        }
    }
}
