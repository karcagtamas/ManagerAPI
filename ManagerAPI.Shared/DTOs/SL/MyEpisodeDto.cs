using System;

namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My episode DTO
    /// </summary>
    public class MyEpisodeDto : EpisodeDto
    {
        /// <summary>
        /// Is mine
        /// </summary>
        public bool IsMine { get; set; }

        /// <summary>
        /// Is seen
        /// </summary>
        public bool IsSeen { get; set; }

        /// <summary>
        /// Seen on
        /// </summary>
        public DateTime? SeenOn { get; set; }
    }
}