using System.Collections.Generic;

namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Season list DTO
    /// </summary>
    public class SeasonListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Number
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Episode List
        /// </summary>
        public List<EpisodeListDto> Episodes { get; set; }
    }
}