namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Series category selector list data object
    /// </summary>
    public class SeriesCategorySelectorListDto : IIdentified
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