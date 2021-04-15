using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Episode image update model
    /// </summary>
    public class EpisodeImageModel
    {
        /// <summary>
        /// Image Title
        /// </summary>
        [MaxLength(100)] public string ImageTitle { get; set; }

        /// <summary>
        /// Image Data
        /// </summary>
        public byte[] ImageData { get; set; }
    }
}