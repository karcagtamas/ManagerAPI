namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My series selector list DTO
    /// </summary>
    public class MySeriesSelectorListDto : SeriesListDto
    {
        /// <summary>
        /// Is mine
        /// </summary>
        public bool IsMine { get; set; }
    }
}