using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.WM
{
    /// <summary>
    /// Working field
    /// </summary>
    public class WorkingField : IEntity
    {
        /// <inheritdoc />
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Length
        /// </summary>
        [Required]
        public decimal Length { get; set; }

        /// <summary>
        /// Working day
        /// </summary>
        [Required]
        public int WorkingDayId { get; set; }

        /// <summary>
        /// Working day
        /// </summary>
        public virtual WorkingDay WorkingDay { get; set; } = default!;

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj != null && this.Id == ((WorkingField)obj).Id;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Title, this.Description, this.Length, this.WorkingDayId);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{this.Id} - {this.Title}";
        }
    }
}
