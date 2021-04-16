using System;

namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Series list DTO
    /// </summary>
    public class SeriesListDto : IIdentified
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
        /// Start year
        /// </summary>
        public int? StartYear { get; set; }

        /// <summary>
        /// End year
        /// </summary>
        public int? EndYear { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        public DateTime Creation { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public string Creator { get; set; }
    }
}