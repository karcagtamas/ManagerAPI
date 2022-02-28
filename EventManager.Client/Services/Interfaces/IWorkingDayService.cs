using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.WM;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Working day Service
    /// </summary>
    public interface IWorkingDayService : IHttpCall<int>
    {
        /// <summary>
        /// Get by day
        /// </summary>
        /// <param name="day">Day</param>
        /// <returns>List of working days</returns>
        Task<WorkingDayListDto> Get(DateTime day);

        /// <summary>
        /// Get statistic by Id
        /// </summary>
        /// <param name="id">Working day Id</param>
        /// <returns>Statistic</returns>
        Task<WorkingDayStatDto?> Stat(int id);
    }
}