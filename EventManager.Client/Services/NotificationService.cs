using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class NotificationService : INotificationService
    {
        private readonly IHttpService _httpService;
        private readonly string _url = ApplicationSettings.BaseApiUrl + "/notification";

        /// <summary>
        /// Init Notification Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public NotificationService(IHttpService httpService)
        {
            this._httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<int?> GetCountOfUnReadNotifications()
        {
            var settings = new HttpSettings(_httpService.BuildUrl(_url, "unreads", "count"));

            return await this._httpService.GetInt(settings).ExecuteWithResult();
        }

        /// <inheritdoc />
        public async Task<List<NotificationDto>> GetMyNotifications()
        {
            var settings = new HttpSettings($"{this._url}");

            return await this._httpService.Get<List<NotificationDto>>(settings).ExecuteWithResult() ?? new();
        }

        /// <inheritdoc />
        public async Task<bool> SetUnReadsToRead(int[] ids)
        {
            var settings = new HttpSettings(this._url).AddToaster("Notification refreshing");

            var body = new HttpBody<int[]>(ids);

            return await this._httpService.Put(settings, body).Execute();
        }
    }
}