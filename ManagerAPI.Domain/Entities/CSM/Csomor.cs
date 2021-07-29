using ManagerAPI.Shared.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.CSM
{
    /// <summary>
    /// Csomor
    /// </summary>
    public class Csomor
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required] public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required] [MaxLength(120)] public string Title { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        [Required] public DateTime Creation { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        [Required] public string OwnerId { get; set; }

        /// <summary>
        /// Last update
        /// </summary>
        public DateTime? LastUpdate { get; set; }

        /// <summary>
        /// Last updater
        /// </summary>
        public string LastUpdaterId { get; set; }

        /// <summary>
        /// Start
        /// </summary>
        [Required] public DateTime Start { get; set; }

        /// <summary>
        /// Finish
        /// </summary>
        [Required] public DateTime Finish { get; set; }

        /// <summary>
        /// Max work hour
        /// </summary>
        [Required]
        [MinNumber(1)]
        [MaxNumber(8)]
        public int MaxWorkHour { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [Required]
        [MinNumber(1)]
        [MaxNumber(4)]
        public int MinRestHour { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [Required] public bool IsShared { get; set; }

        /// <summary>
        /// Is public
        /// </summary>
        [Required] public bool IsPublic { get; set; }

        /// <summary>
        /// Has generated csomor
        /// </summary>
        [Required] public bool HasGeneratedCsomor { get; set; }

        /// <summary>
        /// Last generation
        /// </summary>
        public DateTime? LastGeneration { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        public virtual User Owner { get; set; }

        /// <summary>
        /// Last updater
        /// </summary>
        public virtual User LastUpdater { get; set; }

        /// <summary>
        /// Persons
        /// </summary>
        public virtual ICollection<CsomorPerson> Persons { get; set; }

        /// <summary>
        /// Works
        /// </summary>
        public virtual ICollection<CsomorWork> Works { get; set; }

        /// <summary>
        /// Shared with
        /// </summary>
        public virtual ICollection<UserCsomor> SharedWith { get; set; }
    }
}