using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Models.WM;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class WorkingDayTypeService : HttpCall<WorkingDayTypeListDto, WorkingDayTypeDto, WorkingDayTypeModel>, IWorkingDayTypeService
    {
        /// <summary>
        /// Init Working day Type Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public WorkingDayTypeService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/working-day-type", "Working day type")
        {
        }
    }
}