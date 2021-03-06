namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My episode list DTO
    /// </summary>
    public class MyEpisodeListDto : EpisodeListDto
    {
        public string Description { get; set; }
        public bool Seen { get; set; }
    }
}