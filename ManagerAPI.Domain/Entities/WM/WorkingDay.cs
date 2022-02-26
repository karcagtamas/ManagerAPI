using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerAPI.Domain.Entities.WM
{
    /// <summary>
    /// Working day
    /// </summary>
    public class WorkingDay : IEntity
    {
        /// <inheritdoc />
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Day
        /// </summary>
        [Required]
        public DateTime Day { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [Required]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Type
        /// </summary>
        [Required]
        public int TypeId { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public virtual WorkingDayType Type { get; set; } = default!;

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; } = default!;

        /// <summary>
        /// Working fields
        /// </summary>
        public virtual ICollection<WorkingField> WorkingFields { get; set; } = default!;

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj != null && this.Id == ((WorkingDay)obj).Id;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Day, this.UserId, this.TypeId);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{this.Id} - {this.Day}";
        }
    }
}
