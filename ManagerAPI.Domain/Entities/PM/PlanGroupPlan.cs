using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.PM
{
    /// <summary>
    /// Plan group plan
    /// </summary>
    public class PlanGroupPlan
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
        /// Last updater
        /// </summary>
        public string? LastUpdaterId { get; set; }

        /// <summary>
        /// Last update
        /// </summary>
        public DateTime? LastUpdate { get; set; }

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
        /// Marked user
        /// </summary>
        public string MarkedUserId { get; set; }

        /// <summary>
        /// Mark type
        /// </summary>
        public int? MarkTypeId { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        public virtual User Owner { get; set; }

        /// <summary>
        /// Last updater
        /// </summary>
        public virtual User LastUpdater { get; set; }

        /// <summary>
        /// Plan type
        /// </summary>
        public virtual PlanType PlanType { get; set; }

        /// <summary>
        /// Marked user
        /// </summary>
        public virtual User MarkedUser { get; set; }

        /// <summary>
        /// Mark type
        /// </summary>
        public virtual MarkType MarkType { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public virtual PlanGroup Group { get; set; }

        /// <summary>
        /// Comments
        /// </summary>
        public virtual ICollection<PlanGroupPlanComment> Comments { get; set; }
    }
}