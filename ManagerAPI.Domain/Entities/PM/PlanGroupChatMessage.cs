using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.PM
{
    /// <summary>
    /// PLan group message
    /// </summary>
    public class PlanGroupChatMessage
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [Required]
        public string Message { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [Required]
        public string SenderId { get; set; }

        /// <summary>
        /// Sent
        /// </summary>
        [Required]
        public DateTime Sent { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        [Required]
        public int GroupId { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public virtual User Sender { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public virtual PlanGroup Group { get; set; }
    }
}