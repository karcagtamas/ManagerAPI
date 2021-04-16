using System;
using System.Collections.Generic;

namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My series DTO
    /// </summary>
    public class MySeriesDto : SeriesDto
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
        /// Added on
        /// </summary>
        public DateTime? AddedOn { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// Seasons
        /// </summary>
        public List<MySeasonDto> Seasons { get; set; }
    }
}