namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Movie list DTO
    /// </summary>
    public class MovieListDto : IIdentified
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
        /// Release year
        /// </summary>
        public int? ReleaseYear { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public string Creator { get; set; }
    }
}