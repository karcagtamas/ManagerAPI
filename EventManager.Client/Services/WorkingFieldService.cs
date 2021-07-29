using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Helpers;
using ManagerAPI.Shared.Models.WM;
using System;
using System.Threading.Tasks;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class WorkingFieldService : HttpCall<WorkingFieldListDto, WorkingFieldDto, WorkingFieldModel>, IWorkingFieldService
    {
        /// <summary>
        /// Init Working field Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public WorkingFieldService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/working-field", "Working field")
        {
        }

        /// <inheritdoc />
        public async Task<WorkingWeekStatDto> GetWeekStat(DateTime week)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<string>(DateHelper.DateToNumberDayString(week), -1);

            var settings = new HttpSettings($"{this.Url}/week-stat", null, pathParams);

            return await this.Http.Get<WorkingWeekStatDto>(settings);
        }

        /// <inheritdoc />
        public async Task<WorkingMonthStatDto> GetMonthStat(int year, int month)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(year, -1);
            pathParams.Add<int>(month, -1);

            var settings = new HttpSettings($"{this.Url}/month-stat", null, pathParams);

            return await this.Http.Get<WorkingMonthStatDto>(settings);
        }
    }
}