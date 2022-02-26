using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// Notification type
    /// </summary>
    public class NotificationType
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Importance level
        /// </summary>
        [Required]
        public int ImportanceLevel { get; set; }

        /// <summary>
        /// System
        /// </summary>
        [Required]
        public int SystemId { get; set; }

        /// <summary>
        /// System
        /// </summary>
        public virtual NotificationSystem System { get; set; } = default!;

        /// <summary>
        /// Connected notification
        /// </summary>
        public virtual ICollection<Notification> Notifications { get; set; } = default!;
    }
}