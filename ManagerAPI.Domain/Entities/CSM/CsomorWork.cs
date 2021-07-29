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
        [Required] public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required] [MaxLength(80)] public string Name { get; set; }

        /// <summary>
        /// Csomor
        /// </summary>
        [Required] public int CsomorId { get; set; }

        /// <summary>
        /// Csomor
        /// </summary>
        public virtual Csomor Csomor { get; set; }

        /// <summary>
        /// Tables
        /// </summary>
        public virtual ICollection<CsomorWorkTable> Tables { get; set; }

        /// <summary>
        /// Persons
        /// </summary>
        public virtual ICollection<CsomorPersonTable> Persons { get; set; }

        /// <summary>
        /// Ignoring persons
        /// </summary>
        public virtual ICollection<IgnoredWork> IgnoringPersons { get; set; }
    }
}