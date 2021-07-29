using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Movie image update model
    /// </summary>
    public class MovieImageModel
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