using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.PM
{
    /// <summary>
    /// Mark type
    /// </summary>
    public class MarkType
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
        [MaxLength(120)]
        public string Title { get; set; }

        /// <summary>
        /// Marked plans
        /// </summary>
        public virtual ICollection<PlanGroupPlan> MarkedPlans { get; set; }
    }
}