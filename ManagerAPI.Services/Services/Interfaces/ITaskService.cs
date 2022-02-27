using ManagerAPI.Services.Repositories;
using ManagerAPI.Shared.DTOs;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// Task Service
    /// </summary>
    public interface ITaskService : INotificationRepository<Domain.Entities.Task, int>
    {
        /// <summary>
        /// Get tasks for the current user
        /// </summary>
        /// <param name="isSolved">Filter - task is solved or not</param>
        /// <returns>List of tasks grouped by the deadline</returns>
        List<TaskDateDto> GetDate(bool? isSolved);
    }
}