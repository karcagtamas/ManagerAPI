namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Movie category data object
    /// </summary>
    public class MovieCategoryDto : IIdentified
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}