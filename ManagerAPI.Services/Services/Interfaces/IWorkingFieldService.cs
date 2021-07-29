using ManagerAPI.Domain.Entities.WM;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Shared.DTOs.WM;
using System;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// Working Field Service
    /// </summary>
    public interface IWorkingFieldService : IRepository<WorkingField>
    {
        /// <summary>
        /// Get statistic summary for the given week
        /// </summary>
        /// <param name="week">First day of the week (M)</param>
        /// <returns>Statistic</returns>
        WorkingWeekStatDto GetWeekStat(DateTime week);

        /// <summary>
        /// Get statistic summary for the given month
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <returns>Statistic</returns>
        WorkingMonthStatDto GetMonthStat(int year, int month);
    }
}