using ManagerAPI.Domain.Entities.WM;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Shared.DTOs.WM;
using System;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// Working Day Service
    /// </summary>
    public interface IWorkingDayService : IRepository<WorkingDay>
    {
        /// <summary>
        /// Get working day by date
        /// </summary>
        /// <param name="day">Date of the day</param>
        /// <returns>Working day</returns>
        WorkingDayListDto Get(DateTime day);

        /// <summary>
        /// Working day statistic
        /// </summary>
        /// <param name="id">Id of the working day</param>
        /// <returns>Statistic</returns>
        WorkingDayStatDto Stat(int id);
    }
}