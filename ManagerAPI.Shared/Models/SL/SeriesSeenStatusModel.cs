using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Series seen status model
    /// </summary>
    public class SeriesSeenStatusModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required] public int Id { get; set; }

        /// <summary>
        /// Seen
        /// </summary>
        [Required] public bool Seen { get; set; }
    }
}