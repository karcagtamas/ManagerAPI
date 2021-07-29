using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Episode seen status model
    /// </summary>
    public class EpisodeSeenStatusModel
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