#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.PM
{
    /// <summary>
    /// Plan group
    /// </summary>
    public class PlanGroup
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; } = "";

        /// <summary>
        /// Creator
        /// </summary>
        [Required]
        public string CreatorId { get; set; } = "";

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
        [Required]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Is archived
        /// </summary>
        [Required]
        public bool IsArchived { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public virtual User Creator { get; set; } = new User();

        /// <summary>
        /// Last updater
        /// </summary>
        public virtual User LastUpdater { get; set; } = new User();

        /// <summary>
        /// Ideas
        /// </summary>
        public virtual ICollection<PlanGroupIdea> Ideas { get; set; } = new List<PlanGroupIdea>();

        /// <summary>
        /// Messages
        /// </summary>
        public virtual ICollection<PlanGroupChatMessage> Messages { get; set; } = new List<PlanGroupChatMessage>();

        /// <summary>
        /// Plans
        /// </summary>
        public virtual ICollection<PlanGroupPlan> Plans { get; set; } = new List<PlanGroupPlan>();

        /// <summary>
        /// Users
        /// </summary>
        public virtual ICollection<UserPlanGroup> Users { get; set; } = new List<UserPlanGroup>();
    }
}