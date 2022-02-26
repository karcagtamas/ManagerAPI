using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// Notification system
    /// </summary>
    public class NotificationSystem
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Short name
        /// </summary>
        [Required]
        public string ShortName { get; set; } = string.Empty;

        /// <summary>
        /// Connected notification types
        /// </summary>
        public virtual ICollection<NotificationType> Types { get; set; } = default!;
    }
}