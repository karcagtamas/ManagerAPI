using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.WM;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Working field Service
    /// </summary>
    public interface IWorkingFieldService : IHttpCall<int>
    {
        /// <summary>
        /// Get week statistic
        /// </summary>
        /// <param name="week">Week</param>
        /// <returns>Statistic</returns>
        Task<WorkingWeekStatDto?> GetWeekStat(DateTime week);

        /// <summary>
        /// Get month statistic
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <returns>Statistic</returns>
        Task<WorkingMonthStatDto?> GetMonthStat(int year, int month);
    }
}