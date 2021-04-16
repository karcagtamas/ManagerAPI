using System;

namespace ManagerAPI.Shared.DTOs
{
    /// <summary>
    /// News list DTO
    /// </summary>
    public class NewsListDto
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
        /// Creatio
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