using System;

namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My movie DTO
    /// </summary>
    public class MyMovieDto : MovieDto
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

        /// <summary>
        /// Added on
        /// </summary>
        public DateTime? AddedOn { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        public int Rate { get; set; }
    }
}