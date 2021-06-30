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
        [Required] public string Id { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Work
        /// </summary>
        [Required]
        public string WorkId { get; set; }

        /// <summary>
        /// Is active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Person
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Work
        /// </summary>
        public virtual CsomorWork Work { get; set; }

        /// <summary>
        /// Person
        /// </summary>
        public virtual CsomorPerson Person { get; set; }
    }
}