namespace ManagerAPI.Shared.DTOs.SL
{
    /// <summary>
    /// Episode DTO
    /// </summary>
    public class EpisodeDto
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
        /// Number
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Image title
        /// </summary>
        public string ImageTitle { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        public byte[] ImageData { get; set; }

        /// <summary>
        /// Last Updater
        /// </summary>
        public string LastUpdater { get; set; }
        
        /// <summary>
        /// Series Id
        /// </summary>
        public int SeriesId { get; set; }
    }
}