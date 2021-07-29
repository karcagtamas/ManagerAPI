using System;

namespace ManagerAPI.Shared.DTOs
{
    /// <summary>
    /// Notification DTO
    /// </summary>
    public class NotificationDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Send Date
        /// </summary>
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Is Read
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// Archived
        /// </summary>
        public bool Archived { get; set; }

        /// <summary>
        /// Type Title
        /// </summary>
        public string TypeTitle { get; set; }

        /// <summary>
        /// Importance level
        /// </summary>
        public int ImportanceLevel { get; set; }

        /// <summary>
        /// System name
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// System short name
        /// </summary>
        public string SystemShortName { get; set; }
    }
}