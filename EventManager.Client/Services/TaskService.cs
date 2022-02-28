using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs;

namespace EventManager.Client.Services
{
    /// <inheritdoc cref="EventManager.Client.Services.Interfaces.ITaskService" />
    public class TaskService : HttpCall<int>, ITaskService
    {
        private readonly IHelperService _helperService;

        /// <summary>
        /// Init Task Service
        /// </summary>
        /// <param name="helperService"></param>
        /// <param name="httpService"></param>
        /// <returns></returns>
        public TaskService(IHelperService helperService, IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/task", "Task")
        {
            this._helperService = helperService;
        }

        /// <inheritdoc />
        public async Task<List<TaskDateDto>> GetDate(bool? isSolved)
        {
            var queryParams = new HttpQueryParameters();

            if (isSolved != null)
            {
                queryParams.Add<bool>("isSolved", (bool)isSolved);
            }

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "date")).AddQueryParams(queryParams);

            return await this.Http.Get<List<TaskDateDto>>(settings).ExecuteWithResult() ?? new List<TaskDateDto>();
        }
    }
}
