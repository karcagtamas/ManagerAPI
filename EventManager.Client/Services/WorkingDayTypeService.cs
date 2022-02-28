using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;

namespace EventManager.Client.Services
{
    /// <inheritdoc cref="EventManager.Client.Services.Interfaces.IWorkingDayTypeService" />
    public class WorkingDayTypeService : HttpCall<int>, IWorkingDayTypeService
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