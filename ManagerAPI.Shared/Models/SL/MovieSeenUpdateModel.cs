using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Movie seen update model
    /// </summary>
    public class MovieSeenUpdateModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required] public int Id { get; set; }

        /// <summary>
        /// Seen status
        /// </summary>
        [Required] public bool Seen { get; set; }
    }
}