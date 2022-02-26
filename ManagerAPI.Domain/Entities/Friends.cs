using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// Friends Mapping
    /// </summary>
    public class Friends
    {
        /// <summary>
        /// User Id
        /// </summary>
        [Required]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Friend Id
        /// </summary>
        [Required]
        public string FriendId { get; set; } = string.Empty;

        /// <summary>
        /// Connection date
        /// </summary>
        [Required]
        public DateTime ConnectionDate { get; set; }

        /// <summary>
        /// Friend request
        /// </summary>
        [Required]
        public int RequestId { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; } = default!;

        /// <summary>
        /// Friend
        /// </summary>
        public virtual User Friend { get; set; } = default!;

        /// <summary>
        /// Friend Request
        /// </summary>
        public virtual FriendRequest Request { get; set; } = default!;
    }
}
