using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// Message
    /// </summary>
    public class Message : IEntity
    {
        /// <inheritdoc />
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Message text
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(400)")]
        public string Text { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public string SenderId { get; set; }

        /// <summary>
        /// Receiver
        /// </summary>
        public string ReceiverId { get; set; }

        /// <summary>
        /// Sent date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Sender
        /// </summary>        
        public virtual User Sender { get; set; }

        /// <summary>
        /// Receiver
        /// </summary>
        public virtual User Receiver { get; set; }

    }
}
