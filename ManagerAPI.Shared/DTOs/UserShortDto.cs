using System;

namespace ManagerAPI.Shared.DTOs
{
    /// <summary>
    /// User short DTO
    /// </summary>
    public class UserShortDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// E-mail address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Last Login
        /// </summary>
        public DateTime LastLogin { get; set; }
    }
}