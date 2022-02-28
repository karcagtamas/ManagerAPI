using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.CSM
{
    /// <summary>
    /// Csomor work table
    /// </summary>
    public class CsomorWorkTable
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required] public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Work
        /// </summary>
        [Required]
        public string WorkId { get; set; } = string.Empty;

        /// <summary>
        /// Is active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Person
        /// </summary>
        public string? PersonId { get; set; } = string.Empty;

        /// <summary>
        /// Work
        /// </summary>
        public virtual CsomorWork Work { get; set; } = default!;

        /// <summary>
        /// Person
        /// </summary>
        public virtual CsomorPerson? Person { get; set; } = default!;
    }
}