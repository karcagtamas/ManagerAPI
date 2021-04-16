namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My episode list DTO
    /// </summary>
    public class MyEpisodeListDto : EpisodeListDto
    {
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Seen
        /// </summary>
        public bool Seen { get; set; }
    }
}