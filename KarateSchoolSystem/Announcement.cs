using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Represents an announcement created by an administrator.
    /// </summary>
    public class Announcement
    {
        public int AnnouncementId { get; }
        public string Title { get; }
        public string Message { get; }
        public DateTime PostedDate { get; }
        public Administrator CreatedBy { get; }

        public Announcement(
            int announcementId,
            string title,
            string message,
            DateTime postedDate,
            Administrator createdBy)
        {
            if (announcementId <= 0)
            {
                throw new ArgumentException(
                    "Announcement ID must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException(
                    "Announcement title is required.");
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException(
                    "Announcement message is required.");
            }

            if (postedDate.Date > DateTime.Today)
            {
                throw new ArgumentException(
                    "Posted date cannot be in the future.");
            }

            CreatedBy = createdBy ??
                throw new ArgumentNullException(nameof(createdBy));

            AnnouncementId = announcementId;
            Title = title.Trim();
            Message = message.Trim();
            PostedDate = postedDate.Date;
        }

        public override string ToString()
        {
            return $"{Title} - Posted {PostedDate:d} by " +
                   $"{CreatedBy.FirstName} {CreatedBy.LastName}";
        }
    }
}
