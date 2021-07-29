using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.PM
{
    /// <summary>
    /// Group role
    /// </summary>
    public class GroupRole
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Access level
        /// </summary>
        [Required]
        public int AccessLevel { get; set; }

        /// <summary>
        /// Group members
        /// </summary>
        public virtual ICollection<UserPlanGroup> GroupMembers { get; set; }
    }
}