using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL
{
    /// <summary>
    /// Movie category
    /// </summary>
    public class MovieCategory : IEntity
    {
        /// <inheritdoc />
        [Required] public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required] [MaxLength(120)] public string Name { get; set; }

        /// <summary>
        /// Movies
        /// </summary>
        public virtual ICollection<MovieMovieCategory> ConnectedMovies { get; set; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj != null && this.Id == ((Movie)obj).Id;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(this.Id);
            hash.Add(this.Name);
            return hash.ToHashCode();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return EntityStringBuilder.BuildString(this, "Id", "Name");
        }
    }
}