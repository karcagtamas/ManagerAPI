using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Helpers;

namespace EventManager.Client.Services
{
    /// <inheritdoc cref="EventManager.Client.Services.Interfaces.IWorkingDayService" />
    public class WorkingDayService : HttpCall<int>, IWorkingDayService
    {
        /// <summary>
        /// Init Working day Service
        /// </summary>
        /// <param name="http">HTTP Service</param>
        public WorkingDayService(IHttpService http) : base(http, $"{ApplicationSettings.BaseApiUrl}/working-day", "Working day")
        {
        }

        /// <inheritdoc />
        public async Task<WorkingDayListDto> Get(DateTime day)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(DateHelper.DateToNumberDayString(day));

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "day")).AddPathParams(pathParams);

            return await this.Http.Get<WorkingDayListDto>(settings).ExecuteWithResult() ?? new WorkingDayListDto();
        }

        /// <inheritdoc />
        public async Task<WorkingDayStatDto?> Stat(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            pathParams.Add<string>("stat");

            var settings = new HttpSettings(this.Url).AddPathParams(pathParams);

            return await this.Http.Get<WorkingDayStatDto>(settings).ExecuteWithResult();
        }
    }
}