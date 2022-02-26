using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// Notification
    /// </summary>
    public class Notification
    {
        /// <inheritdoc />
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Sent date
        /// </summary>
        [Required]
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        [Required]
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// Notification is read
        /// </summary>
        [Required]
        public bool IsRead { get; set; }

        /// <summary>
        /// Notification is archived
        /// </summary>
        [Required]
        public bool Archived { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [Required]
        public int TypeId { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        public virtual User Owner { get; set; } = default!;

        /// <summary>
        /// Type
        /// </summary>
        public virtual NotificationType Type { get; set; } = default!;
    }
}