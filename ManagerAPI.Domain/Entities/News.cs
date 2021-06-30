using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// News
    /// </summary>
    public class News : IEntity
    {
        /// <inheritdoc />
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [Required]
        [MaxLength(512)]
        public string Content { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        [Required]
        public string CreatorId { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        [Required]
        public DateTime Creation { get; set; }

        /// <summary>
        /// Last updater
        /// </summary>
        [Required]
        public string LastUpdaterId { get; set; }

        /// <summary>
        /// Last update
        /// </summary>
        [Required]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// Last updater
        /// </summary>
        public virtual User LastUpdater { get; set; }
    }
}