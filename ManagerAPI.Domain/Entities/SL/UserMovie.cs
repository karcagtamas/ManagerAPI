using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL
{
    /// <summary>
    /// User - Movie mapping
    /// </summary>
    public class UserMovie
    {
        /// <summary>
        /// Movie
        /// </summary>
        [Required] public int MovieId { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [Required] public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Is seen
        /// </summary>
        [Required] public bool IsSeen { get; set; }

        /// <summary>
        /// Is added
        /// </summary>
        [Required] public bool IsAdded { get; set; }

        /// <summary>
        /// Seen on
        /// </summary>
        public DateTime? SeenOn { get; set; }

        /// <summary>
        /// Added on
        /// </summary>
        public DateTime? AddedOn { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        public int? Rate { get; set; }

        /// <summary>
        /// Movie
        /// </summary>
        public virtual Movie Movie { get; set; } = default!;

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; } = default!;
    }
}