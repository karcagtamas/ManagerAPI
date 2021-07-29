using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL
{
    /// <summary>
    /// Series comment
    /// </summary>
    public class SeriesComment : IEntity
    {
        /// <inheritdoc />
        public int Id { get; set; }

        /// <summary>
        /// Series
        /// </summary>
        [Required] public int SeriesId { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [Required] public string UserId { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        [Required] public DateTime Creation { get; set; }

        /// <summary>
        /// Last update
        /// </summary>
        [Required] public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        [Required] [MaxLength(500)] public string Comment { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public virtual Series Series { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; }
    }
}