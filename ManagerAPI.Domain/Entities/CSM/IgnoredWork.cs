using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.CSM
{
    /// <summary>
    /// Ignored work
    /// </summary>
    public class IgnoredWork
    {
        /// <summary>
        /// Person
        /// </summary>
        [Required]
        public string PersonId { get; set; } = string.Empty;

        /// <summary>
        /// Work
        /// </summary>
        [Required]
        public string WorkId { get; set; } = string.Empty;

        /// <summary>
        /// Person
        /// </summary>
        public virtual CsomorPerson Person { get; set; } = default!;

        /// <summary>
        /// Work
        /// </summary>
        public virtual CsomorWork Work { get; set; } = default!;
    }
}