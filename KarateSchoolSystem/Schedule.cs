using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Represents the scheduled day, time, and room for a class.
    /// </summary>
    public class Schedule
    {
        public int ScheduleId { get; }
        public DayOfWeek DayOfWeek { get; }
        public TimeSpan StartTime { get; }
        public TimeSpan EndTime { get; }
        public string Room { get; }

        public Schedule(
            int scheduleId,
            DayOfWeek dayOfWeek,
            TimeSpan startTime,
            TimeSpan endTime,
            string room)
        {
            if (scheduleId <= 0)
            {
                throw new ArgumentException(
                    "Schedule ID must be greater than zero.");
            }

            if (endTime <= startTime)
            {
                throw new ArgumentException(
                    "End time must be later than start time.");
            }

            if (string.IsNullOrWhiteSpace(room))
            {
                throw new ArgumentException("Room is required.");
            }

            ScheduleId = scheduleId;
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
            Room = room.Trim();
        }

        public override string ToString()
        {
            return $"{DayOfWeek}: {StartTime:hh\\:mm} - " +
                   $"{EndTime:hh\\:mm}, Room {Room}";
        }
    }
}
