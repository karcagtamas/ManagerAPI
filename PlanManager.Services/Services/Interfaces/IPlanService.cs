using ManagerAPI.Shared.DTOs.PM;
using ManagerAPI.Shared.Models.PM;
using System.Collections.Generic;

namespace PlanManager.Services.Services.Interfaces
{
    /// <summary>
    /// Plan Service
    /// </summary>
    public interface IPlanService
    {
        /// <summary>
        /// Get plans
        /// </summary>
        /// <returns>List of all plan</returns>
        List<PlanListDto> GetPlans();

        /// <summary>
        /// Get only plans for specific User
        /// </summary>
        /// <returns>Filtered plan list</returns>
        List<PlanListDto> GetMyPlans();

        /// <summary>
        /// Get plan by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Plan with given Id</returns>
        PlanDto GetPlan(int id);

        /// <summary>
        /// Get user's public Plans
        /// </summary>
        /// <param name="userId">User</param>
        /// <returns>Filtered plan list</returns>
        List<PlanListDto> GetUserPublicPlans(string userId);

        /// <summary>
        /// Create plan by model
        /// </summary>
        /// <param name="model">Source model</param>
        void CreatePlan(PlanModel model);

        /// <summary>
        /// Update plan by model
        /// </summary>
        /// <param name="id">Base plan Id</param>
        /// <param name="model">Source model</param>
        void UpdatePlan(int id, PlanModel model);

        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <param name="id">Plan</param>
        void DeletePlan(int id);
    }
}