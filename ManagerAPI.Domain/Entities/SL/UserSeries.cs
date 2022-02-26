using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL
{
    /// <summary>
    /// User - Series mapping
    /// </summary>
    public class UserSeries
    {
        /// <summary>
        /// Series
        /// </summary>
        [Required] public int SeriesId { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [Required] public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Is added
        /// </summary>
        [Required] public bool IsAdded { get; set; }

        /// <summary>
        /// Added on
        /// </summary>
        public DateTime? AddedOn { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        public int? Rate { get; set; }

        /// <summary>
        /// Series
        /// </summary>
        public virtual Series Series { get; set; } = default!;

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; } = default!;
    }
}