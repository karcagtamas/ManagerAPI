namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My series list DTO
    /// </summary>
    public class MySeriesListDto : SeriesListDto
    {
        /// <summary>
        /// Is mine
        /// </summary>
        public bool IsMine { get; set; }

        /// <summary>
        /// Is added
        /// </summary>
        public bool IsAdded { get; set; }
    }
}