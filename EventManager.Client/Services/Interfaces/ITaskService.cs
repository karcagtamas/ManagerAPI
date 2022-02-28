using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Task Service
    /// </summary>
    public interface ITaskService : IHttpCall<int>
    {
        /// <summary>
        /// Get tasks by date
        /// </summary>
        /// <param name="isSolved">Solved filter</param>
        /// <returns>Groupped list</returns>
        Task<List<TaskDateDto>> GetDate(bool? isSolved);
    }
}
