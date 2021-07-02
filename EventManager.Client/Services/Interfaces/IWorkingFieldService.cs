using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Models.WM;
using System;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Working field Service
    /// </summary>
    public interface IWorkingFieldService : IHttpCall<WorkingFieldListDto, WorkingFieldDto, WorkingFieldModel>
    {
        /// <summary>
        /// Get week statistic
        /// </summary>
        /// <param name="week">Week</param>
        /// <returns>Statistic</returns>
        Task<WorkingWeekStatDto> GetWeekStat(DateTime week);

        /// <summary>
        /// Get month statistic
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <returns>Statistic</returns>
        Task<WorkingMonthStatDto> GetMonthStat(int year, int month);
    }
}