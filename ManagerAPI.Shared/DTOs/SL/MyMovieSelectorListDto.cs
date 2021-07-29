namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My movie selector list DTO
    /// </summary>
    public class MyMovieSelectorListDto : MovieListDto
    {
        /// <summary>
        /// Is mine
        /// </summary>
        public bool IsMine { get; set; }

        /// <summary>
        /// Is seen
        /// </summary>
        public bool IsSeen { get; set; }
    }
}