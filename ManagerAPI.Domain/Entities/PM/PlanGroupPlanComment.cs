using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.PM
{
    /// <summary>
    /// Plan group plan comment
    /// </summary>
    public class PlanGroupPlanComment
    {
        /// <summary>
        /// Sender
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Comment { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [Required]
        public string SenderId { get; set; }

        /// <summary>
        /// Creation
        /// </summary>
        [Required]
        public DateTime Creation { get; set; }

        /// <summary>
        /// Plan
        /// </summary>
        [Required]
        public int PlanId { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public virtual User Sender { get; set; }

        /// <summary>
        /// Plan
        /// </summary>
        public virtual PlanGroupPlan Plan { get; set; }
    }
}