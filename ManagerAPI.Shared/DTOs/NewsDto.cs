using System;

namespace ManagerAPI.Shared.DTOs
{
    /// <summary>
    /// News DTO
    /// </summary>
    public class NewsDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        public DateTime Creation { get; set; }

        /// <summary>
        /// Last Updater
        /// </summary>
        public string LastUpdater { get; set; }

        /// <summary>
        /// Last Update
        /// </summary>
        public DateTime LastUpdate { get; set; }
    }
}