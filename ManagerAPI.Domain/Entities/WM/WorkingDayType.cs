using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.WM
{
    /// <summary>
    /// Working dat type
    /// </summary>
    public class WorkingDayType : IEntity
    {
        /// <inheritdoc />
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// Day is active
        /// </summary>
        [Required]
        public bool DayIsActive { get; set; }

        /// <summary>
        /// Working days
        /// </summary>
        public virtual ICollection<WorkingDay> WorkingDays { get; set; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj != null && this.Id == ((WorkingDayType)obj).Id;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Title, this.DayIsActive);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{this.Id} - {this.Title}";
        }
    }
}
