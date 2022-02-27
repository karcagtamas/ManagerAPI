using KarcagS.Common.Tools.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// Task
    /// </summary>
    public class Task : IEntity<int>
    {
        /// <inheritdoc />
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Task is solved
        /// </summary>
        [Required]
        public bool IsSolved { get; set; } = false;

        /// <summary>
        /// Owner
        /// </summary>
        [Required]
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// Creation
        /// </summary>
        [Required]
        public DateTime Creation { get; set; }

        /// <summary>
        /// Last update
        /// </summary>
        [Required]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Deadline
        /// </summary>
        [Required]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        public virtual User Owner { get; set; } = default!;

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj != null && this.Id == ((Task)obj).Id;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(this.Id);
            hash.Add(this.Title);
            hash.Add(this.Description);
            hash.Add(this.IsSolved);
            hash.Add(this.OwnerId);
            hash.Add(this.Creation);
            hash.Add(this.LastUpdate);
            hash.Add(this.Deadline);
            hash.Add(this.Owner);
            return hash.ToHashCode();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{this.Id} - {this.Title}";
        }
    }
}
