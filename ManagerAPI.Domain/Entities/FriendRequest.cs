using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// Friend request
    /// </summary>
    public class FriendRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [Required]
        public string SenderId { get; set; }

        /// <summary>
        /// Destination user
        /// </summary>
        [Required]
        public string DestinationId { get; set; }

        /// <summary>
        /// Sent date
        /// </summary>
        [Required]
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Message text
        /// </summary>
        [Required]
        [MaxLength(120)]
        public string Message { get; set; }

        /// <summary>
        /// Response
        /// </summary>
        public bool? Response { get; set; }

        /// <summary>
        /// Response date
        /// </summary>
        public DateTime? ResponseDate { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public virtual User Sender { get; set; }

        /// <summary>
        /// Destination user
        /// </summary>
        public virtual User Destination { get; set; }

        /// <summary>
        /// Friends
        /// </summary>
        public virtual ICollection<Friends> FriendCollection { get; set; }
    }
}
