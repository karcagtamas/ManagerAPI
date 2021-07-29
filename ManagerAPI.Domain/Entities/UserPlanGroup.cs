using ManagerAPI.Domain.Entities.PM;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// User plan group
    /// </summary>
    public class UserPlanGroup
    {
        /// <summary>
        /// User
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// Plan group
        /// </summary>
        [Required]
        public int GroupId { get; set; }

        /// <summary>
        /// Group role
        /// </summary>
        [Required]
        public int RoleId { get; set; }

        /// <summary>
        /// Connection
        /// </summary>
        [Required]
        public DateTime Connection { get; set; }

        /// <summary>
        /// Added by
        /// </summary>
        [Required]
        public string AddedById { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Plan group
        /// </summary>
        public virtual PlanGroup Group { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public virtual GroupRole Role { get; set; }

        /// <summary>
        /// Added by
        /// </summary>
        public virtual User AddedBy { get; set; }
    }
}