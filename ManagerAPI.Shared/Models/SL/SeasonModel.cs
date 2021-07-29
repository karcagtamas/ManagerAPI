using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Season create or update model
    /// </summary>
    public class SeasonModel
    {
        /// <summary>
        /// Number
        /// </summary>
        [Required] public int Number { get; set; }

        /// <summary>
        /// Series
        /// </summary>
        [Required] public int SeriesId { get; set; }
    }
}