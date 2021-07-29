using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL
{
    /// <summary>
    /// Movie - Movie category mapping
    /// </summary>
    public class MovieMovieCategory
    {
        /// <summary>
        /// Movie
        /// </summary>
        [Required] public int MovieId { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        [Required] public int CategoryId { get; set; }

        /// <summary>
        /// Movie
        /// </summary>
        public virtual Movie Movie { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public virtual MovieCategory Category { get; set; }
    }
}