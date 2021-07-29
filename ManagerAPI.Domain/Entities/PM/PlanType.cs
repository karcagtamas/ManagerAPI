using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.PM
{
    /// <summary>
    /// Plan type
    /// </summary>
    public class PlanType
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
        public string Name { get; set; }

        /// <summary>
        /// Plans
        /// </summary>
        public virtual ICollection<Plan> Plans { get; set; }

        /// <summary>
        /// Group plans
        /// </summary>
        public virtual ICollection<PlanGroupPlan> GroupPlans { get; set; }
    }
}