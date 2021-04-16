using System.Collections.Generic;

namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My season DTO
    /// </summary>
    public class MySeasonDto
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
        /// Is seen
        /// </summary>
        public bool IsSeen { get; set; }

        /// <summary>
        /// Episode List
        /// </summary>
        public List<MyEpisodeListDto> Episodes { get; set; }
    }
}