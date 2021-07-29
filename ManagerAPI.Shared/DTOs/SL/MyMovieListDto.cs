namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// My movie list DTO
    /// </summary>
    public class MyMovieListDto : MovieListDto
    {
        /// <summary>
        /// Is seen
        /// </summary>
        public bool IsSeen { get; set; }

        /// <summary>
        /// Is added
        /// </summary>
        public bool IsAdded { get; set; }
    }
}