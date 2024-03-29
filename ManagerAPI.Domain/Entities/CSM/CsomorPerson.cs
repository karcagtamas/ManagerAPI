using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.CSM
{
    /// <summary>
    /// Csomor person
    /// </summary>
    public class CsomorPerson
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required] public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required] [MaxLength(120)] public string Name { get; set; }

        /// <summary>
        /// Csomor
        /// </summary>
        [Required] public int CsomorId { get; set; }

        /// <summary>
        /// Plus work counter
        /// </summary>
        [Required] public int PlusWorkCounter { get; set; }

        /// <summary>
        /// Is ignored
        /// </summary>
        [Required] public bool IsIgnored { get; set; }

        /// <summary>
        /// Csomor
        /// </summary>
        public virtual Csomor Csomor { get; set; }

        /// <summary>
        /// Tables
        /// </summary>
        public virtual ICollection<CsomorPersonTable> Tables { get; set; }

        /// <summary>
        /// Works
        /// </summary>
        public virtual ICollection<CsomorWorkTable> Works { get; set; }

        /// <summary>
        /// Ignored works
        /// </summary>
        public virtual ICollection<IgnoredWork> IgnoredWorks { get; set; }
    }
}