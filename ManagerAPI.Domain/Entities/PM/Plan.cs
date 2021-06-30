using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.PM
{
    /// <summary>
    /// Plan
    /// </summary>
    public class Plan
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
        [MaxLength(150)]
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [MaxLength(512)]
        public string Description { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        [Required]
        public string OwnerId { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        [Required]
        public DateTime Creation { get; set; }

        /// <summary>
        /// Last update
        /// </summary>
        [Required]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Start time
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Priority level
        /// </summary>
        public int? PriorityLevel { get; set; }

        /// <summary>
        /// Is public
        /// </summary>
        [Required]
        public bool IsPublic { get; set; }

        /// <summary>
        /// Plan type
        /// </summary>
        public int? PlanTypeId { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        public virtual User Owner { get; set; }

        /// <summary>
        /// Plan type
        /// </summary>
        public virtual PlanType PlanType { get; set; }
    }
}