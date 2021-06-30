using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Shared.DTOs;
using System.Collections.Generic;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// Task Service
    /// </summary>
    public interface ITaskService : IRepository<Task>
    {
        /// <summary>
        /// Get tasks for the current user
        /// </summary>
        /// <param name="isSolved">Filter - task is solved or not</param>
        /// <returns>List of tasks grouped by the deadline</returns>
        List<TaskDateDto> GetDate(bool? isSolved);
    }
}