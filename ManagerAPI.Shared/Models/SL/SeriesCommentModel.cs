using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Series comment create or update model
    /// </summary>
    public class SeriesCommentModel
    {
        /// <summary>
        /// Series Id
        /// </summary>
        [Required]
        public int SeriesId { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }
    }
}