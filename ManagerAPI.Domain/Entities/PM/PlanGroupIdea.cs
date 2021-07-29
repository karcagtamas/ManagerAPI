using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.PM
{
    /// <summary>
    /// Plan group idea
    /// </summary>
    public class PlanGroupIdea
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        [Required]
        public string CreatorId { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        [Required]
        public DateTime Creation { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        [Required]
        public int GroupId { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public virtual PlanGroup Group { get; set; }
    }
}