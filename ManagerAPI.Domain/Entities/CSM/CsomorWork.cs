using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.CSM
{
    /// <summary>
    /// Csomor work
    /// </summary>
    public class CsomorWork
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required] public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Name
        /// </summary>
        [Required] [MaxLength(80)] public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Csomor
        /// </summary>
        [Required] public int CsomorId { get; set; }

        /// <summary>
        /// Csomor
        /// </summary>
        public virtual Csomor Csomor { get; set; } = default!;

        /// <summary>
        /// Tables
        /// </summary>
        public virtual ICollection<CsomorWorkTable> Tables { get; set; } = default!;

        /// <summary>
        /// Persons
        /// </summary>
        public virtual ICollection<CsomorPersonTable> Persons { get; set; } = default!;

        /// <summary>
        /// Ignoring persons
        /// </summary>
        public virtual ICollection<IgnoredWork> IgnoringPersons { get; set; } = default!;
    }
}