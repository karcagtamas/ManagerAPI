using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.CSM
{
    /// <summary>
    /// User - Csomor mapping
    /// </summary>
    public class UserCsomor
    {
        /// <summary>
        /// User
        /// </summary>
        [Required]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Csomor
        /// </summary>
        [Required]
        public int CsomorId { get; set; }

        /// <summary>
        /// Shared on
        /// </summary>
        [Required]
        public DateTime SharedOn { get; set; }

        /// <summary>
        /// Has write access
        /// </summary>
        [Required]
        public bool HasWriteAccess { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; } = default!;

        /// <summary>
        /// Csomor
        /// </summary>
        public virtual Csomor Csomor { get; set; } = default!;
    }
}