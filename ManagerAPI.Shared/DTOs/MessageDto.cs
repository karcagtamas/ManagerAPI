using System;

namespace ManagerAPI.Shared.DTOs
{
    /// <summary>
    /// Message DTO
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Receiver
        /// </summary>
        public string Receiver { get; set; }

        /// <summary>
        /// Is Mine
        /// </summary>
        public bool IsMine { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }
    }
}