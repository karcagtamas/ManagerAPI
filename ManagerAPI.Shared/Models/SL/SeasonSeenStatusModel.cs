using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Season seen status model
    /// </summary>
    public class SeasonSeenStatusModel
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