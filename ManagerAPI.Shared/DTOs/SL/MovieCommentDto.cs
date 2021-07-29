using System;

namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Movie comment data object
    /// </summary>
    public class MovieCommentDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        public DateTime Creation { get; set; }

        /// <summary>
        /// Last update
        /// </summary>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment { get; set; }
    }
}