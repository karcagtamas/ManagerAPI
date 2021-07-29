using System;

namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Book DTO
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Pulish
        /// </summary>
        public DateTime? Publish { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Last updater
        /// </summary>
        public string LastUpdater { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        public DateTime Creation { get; set; }

        /// <summary>
        /// Last update
        /// </summary>
        public DateTime LastUpdate { get; set; }
    }
}