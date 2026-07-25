using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Represents a class offered by the karate school.
    /// </summary>
    public class KarateClass : IReportable
    {
        private readonly List<Student> _students = new();
        private readonly List<Attendance> _attendanceRecords = new();

        public int ClassId { get; }
        public string ClassName { get; }
        public string Level { get; }
        public int Capacity { get; }
        public string Location { get; }
        public Instructor Instructor { get; private set; }
        public Schedule Schedule { get; private set; }

        public IReadOnlyList<Student> Students =>
            _students.AsReadOnly();

        public IReadOnlyList<Attendance> AttendanceRecords =>
            _attendanceRecords.AsReadOnly();

        public KarateClass(
            int classId,
            string className,
            string level,
            int capacity,
            string location)
        {
            if (classId <= 0)
            {
                throw new ArgumentException(
                    "Class ID must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Class name is required.");
            }

            if (string.IsNullOrWhiteSpace(level))
            {
                throw new ArgumentException("Class level is required.");
            }

            if (capacity <= 0)
            {
                throw new ArgumentException(
                    "Class capacity must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException(
                    "Class location is required.");
            }

            ClassId = classId;
            ClassName = className.Trim();
            Level = level.Trim();
            Capacity = capacity;
            Location = location.Trim();
        }

        public void AssignInstructor(Instructor instructor)
        {
            Instructor = instructor ??
                throw new ArgumentNullException(nameof(instructor));

            instructor.AddClass(this);
        }

        public void SetSchedule(Schedule schedule)
        {
            Schedule = schedule ??
                throw new ArgumentNullException(nameof(schedule));
        }

        public void EnrollStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (_students.Exists(
                existingStudent =>
                    existingStudent.StudentId == student.StudentId))
            {
                throw new InvalidOperationException(
                    "A student with this ID is already enrolled.");
            }

            if (_students.Count >= Capacity)
            {
                throw new InvalidOperationException(
                    "Class capacity has been reached.");
            }

            _students.Add(student);
            student.AddClass(this);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (!_students.Remove(student))
            {
                throw new InvalidOperationException(
                    "Student is not enrolled in this class.");
            }

            student.RemoveClass(this);
        }

        public void RecordAttendance(Attendance attendance)
        {
            if (attendance == null)
            {
                throw new ArgumentNullException(nameof(attendance));
            }

            if (!_students.Contains(attendance.Student))
            {
                throw new InvalidOperationException(
                    "Attendance cannot be recorded for a student " +
                    "who is not enrolled.");
            }

            _attendanceRecords.Add(attendance);
            attendance.Student.AddAttendance(attendance);
        }

        public string GenerateReport()
        {
            return $"Class Report: {ClassName}, Level: {Level}, " +
                   $"Enrollment: {_students.Count}/{Capacity}";
        }

        public override string ToString()
        {
            return $"{ClassName} - {Level} - " +
                   $"{_students.Count}/{Capacity} students";
        }
    }
}
