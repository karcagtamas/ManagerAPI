using System;

namespace ManagerAPI.Shared.DTOs.EM
{
    /// <summary>
    /// Event action list DTO
    /// </summary>
    public class EventActionListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public string User { get; set; }
    }
}