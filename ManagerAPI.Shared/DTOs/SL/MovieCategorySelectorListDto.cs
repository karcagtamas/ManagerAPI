namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Movie category selector list data object
    /// </summary>
    public class MovieCategorySelectorListDto : IIdentified
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Is selected
        /// </summary>
        public bool IsSelected { get; set; }
    }
}