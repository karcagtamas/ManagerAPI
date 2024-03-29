﻿using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class FriendService : IFriendService
    {
        private readonly string _url = ApplicationSettings.BaseApiUrl + "/friend";
        private readonly IHelperService _helperService;
        private readonly IHttpService _httpService;

        /// <summary>
        /// Init Friend Service
        /// </summary>
        /// <param name="helperService">Helper Service</param>
        /// <param name="httpService">HTTP Service</param>
        public FriendService(IHelperService helperService, IHttpService httpService)
        {
            this._helperService = helperService;
            this._httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<FriendDataDto> GetFriendData(string friendId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<string>(friendId, -1);

            var settings = new HttpSettings($"{this._url}/data", null, pathParams);

            return await this._httpService.Get<FriendDataDto>(settings);
        }

        /// <inheritdoc />
        public async Task<List<FriendRequestListDto>> GetMyFriendRequests()
        {
            var settings = new HttpSettings($"{this._url}/request");

            return await this._httpService.Get<List<FriendRequestListDto>>(settings);
        }

        /// <inheritdoc />
        public async Task<List<FriendListDto>> GetMyFriends()
        {
            var settings = new HttpSettings($"{this._url}");

            return await this._httpService.Get<List<FriendListDto>>(settings);
        }

        /// <inheritdoc />
        public async Task<bool> RemoveFriend(string friendId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<string>(friendId, -1);

            var toaster = new ToasterSettings("Friend removing");

            var settings = new HttpSettings($"{this._url}", null, pathParams, toaster);

            return await this._httpService.Delete(settings);
        }

        /// <inheritdoc />
        public async Task<bool> SendFriendRequest(FriendRequestModel model)
        {
            var toaster = new ToasterSettings("Friend request sending");

            var settings = new HttpSettings($"{this._url}/request", null, null, toaster);

            var body = new HttpBody<FriendRequestModel>(model);

            return await this._httpService.Create<FriendRequestModel>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> SendFriendRequestResponse(FriendRequestResponseModel model)
        {
            var toaster = new ToasterSettings("Friend request answering");

            var settings = new HttpSettings($"{this._url}/request", null, null, toaster);

            var body = new HttpBody<FriendRequestResponseModel>(model);

            return await this._httpService.Update<FriendRequestResponseModel>(settings, body);
        }
    }
}