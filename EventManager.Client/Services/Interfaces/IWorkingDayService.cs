using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Models.WM;
using System;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Working day Service
    /// </summary>
    public interface IWorkingDayService : IHttpCall<WorkingDayListDto, WorkingDayDto, WorkingDayModel>
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
        Task<WorkingDayStatDto> Stat(int id);
    }
}