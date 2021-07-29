using System;
using System.Collections.Generic;

namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Series DTO
    /// </summary>
    public class SeriesDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Start year
        /// </summary>
        public int? StartYear { get; set; }

        /// <summary>
        /// End year
        /// </summary>
        public int? EndYear { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Last Updater
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

        /// <summary>
        /// Image title
        /// </summary>
        public string ImageTitle { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        public byte[] ImageData { get; set; }

        /// <summary>
        /// Trailer url
        /// </summary>
        public string TrailerUrl { get; set; }

        /// <summary>
        /// Categories
        /// </summary>
        public List<string> Categories { get; set; }
    }
}