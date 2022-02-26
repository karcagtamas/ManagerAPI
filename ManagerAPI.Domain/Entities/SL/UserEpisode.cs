using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL
{
    /// <summary>
    /// User - Episode mapping
    /// </summary>
    public class UserEpisode
    {
        /// <summary>
        /// User
        /// </summary>
        [Required] public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Episode
        /// </summary>
        [Required] public int EpisodeId { get; set; }

        /// <summary>
        /// Is seen
        /// </summary>
        [Required] public bool Seen { get; set; }

        /// <summary>
        /// Seen on
        /// </summary>
        public DateTime? SeenOn { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; } = default!;

        /// <summary>
        /// Episode
        /// </summary>
        public virtual Episode Episode { get; set; } = default!;
    }
}