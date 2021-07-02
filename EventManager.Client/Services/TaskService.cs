using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class TaskService : HttpCall<TaskListDto, TaskDto, TaskModel>, ITaskService
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

            var settings = new HttpSettings($"{this.Url}/date", queryParams, null);

            return await this.Http.Get<List<TaskDateDto>>(settings);
        }
    }
}
