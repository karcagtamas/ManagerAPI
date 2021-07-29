﻿using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class NotificationService : INotificationService
    {
        private readonly IHttpService _httpService;
        private readonly string _url = ApplicationSettings.BaseApiUrl + "/notification";
        private readonly IHelperService _helperService;

        /// <summary>
        /// Init Notification Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        /// <param name="helperService">Helper Service</param>
        public NotificationService(IHttpService httpService, IHelperService helperService)
        {
            this._httpService = httpService;
            this._helperService = helperService;
        }

        /// <inheritdoc />
        public async Task<int?> GetCountOfUnReadNotifications()
        {
            var settings = new HttpSettings($"{this._url}/unreads/count");

            return await this._httpService.GetInt(settings);
        }

        /// <inheritdoc />
        public async Task<List<NotificationDto>> GetMyNotifications()
        {
            var settings = new HttpSettings($"{this._url}");

            return await this._httpService.Get<List<NotificationDto>>(settings);
        }

        /// <inheritdoc />
        public async Task<bool> SetUnReadsToRead(int[] ids)
        {
            var settings = new HttpSettings($"{this._url}", null, null, "Notification refreshing");

            var body = new HttpBody<int[]>(ids);

            return await this._httpService.Update<int[]>(settings, body);
        }
    }
}