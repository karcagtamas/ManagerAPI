using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Helpers;

namespace EventManager.Client.Services
{
    /// <inheritdoc cref="EventManager.Client.Services.Interfaces.IWorkingFieldService" />
    public class WorkingFieldService : HttpCall<int>, IWorkingFieldService
    {
        /// <summary>
        /// Init Working field Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public WorkingFieldService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/working-field", "Working field")
        {
        }

        /// <inheritdoc />
        public async Task<WorkingWeekStatDto?> GetWeekStat(DateTime week)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(DateHelper.DateToNumberDayString(week));

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "week-stat")).AddPathParams(pathParams);

            return await this.Http.Get<WorkingWeekStatDto>(settings).ExecuteWithResult();
        }

        /// <inheritdoc />
        public async Task<WorkingMonthStatDto?> GetMonthStat(int year, int month)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(year);
            pathParams.Add(month);

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "month-stat")).AddPathParams(pathParams);

            return await this.Http.Get<WorkingMonthStatDto>(settings).ExecuteWithResult();
        }
    }
}