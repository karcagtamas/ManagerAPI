using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL
{
    /// <summary>
    /// User - Book mapping
    /// </summary>
    public class UserBook
    {
        /// <summary>
        /// Book
        /// </summary>
        [Required]
        public int BookId { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [Required]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Is read
        /// </summary>
        [Required]
        public bool Read { get; set; }

        /// <summary>
        /// Read on
        /// </summary>
        public DateTime? ReadOn { get; set; }

        /// <summary>
        /// Added on
        /// </summary>
        [Required]
        public DateTime AddOn { get; set; }

        /// <summary>
        /// Book
        /// </summary>
        public virtual Book Book { get; set; } = default!;

        /// <summary>
        /// User
        /// </summary>        
        public virtual User User { get; set; } = default!;
    }
}