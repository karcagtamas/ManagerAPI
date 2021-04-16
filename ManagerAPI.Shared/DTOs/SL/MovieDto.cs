using System;
using System.Collections.Generic;

namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Movie DTO
    /// </summary>
    public class MovieDto
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
        /// Release year
        /// </summary>
        public int? ReleaseYear { get; set; }

        /// <summary>
        /// Length
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Director
        /// </summary>
        public string Director { get; set; }

        /// <summary>
        /// Trailer url
        /// </summary>
        public string TrailerUrl { get; set; }

        /// <summary>
        /// Image title
        /// </summary>
        public string ImageTitle { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        public byte[] ImageData { get; set; }

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

        /// <summary>
        /// Categories
        /// </summary>
        public List<string> Categories { get; set; }

        /// <summary>
        /// Nmber of seen
        /// </summary>
        public int NumberOfSeen { get; set; }
    }
}