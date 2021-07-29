using System;

namespace ManagerAPI.Shared.DTOs
{
    /// <summary>
    /// Friend request list DTO
    /// </summary>
    public class FriendRequestListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Sender's Full name
        /// </summary>
        public string SenderFullName { get; set; }

        /// <summary>
        /// Sent date
        /// </summary>
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Response
        /// </summary>
        public bool? Response { get; set; }

        /// <summary>
        /// Response date
        /// </summary>
        public DateTime? ResponseDate { get; set; }
    }
}