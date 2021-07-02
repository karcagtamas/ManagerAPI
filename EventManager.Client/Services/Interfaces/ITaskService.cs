using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Task Service
    /// </summary>
    public interface ITaskService : IHttpCall<TaskListDto, TaskDto, TaskModel>
    {
        /// <summary>
        /// Get tasks by date
        /// </summary>
        /// <param name="isSolved">Solved filter</param>
        /// <returns>Groupped list</returns>
        Task<List<TaskDateDto>> GetDate(bool? isSolved);
    }
}
