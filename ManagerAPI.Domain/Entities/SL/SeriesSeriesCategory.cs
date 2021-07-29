using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL
{
    /// <summary>
    /// Series - Series category mapping
    /// </summary>
    public class SeriesSeriesCategory
    {
        /// <summary>
        /// Series
        /// </summary>
        [Required] public int SeriesId { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        [Required] public int CategoryId { get; set; }

        /// <summary>
        /// Series
        /// </summary>
        public virtual Series Series { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public virtual SeriesCategory Category { get; set; }
    }
}