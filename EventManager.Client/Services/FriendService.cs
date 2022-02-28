using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Models;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using ApplicationSettings = EventManager.Client.Models.ApplicationSettings;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class FriendService : IFriendService
    {
        private readonly string _url = ApplicationSettings.BaseApiUrl + "/friend";
        private readonly IHttpService _httpService;

        /// <summary>
        /// Init Friend Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public FriendService(IHttpService httpService)
        {
            this._httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<FriendDataDto?> GetFriendData(string friendId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(friendId);

            var settings = new HttpSettings(this._httpService.BuildUrl(this._url, "data")).AddPathParams(pathParams);

            return await this._httpService.Get<FriendDataDto>(settings).ExecuteWithResult();
        }

        /// <inheritdoc />
        public async Task<List<FriendRequestListDto>> GetMyFriendRequests()
        {
            var settings = new HttpSettings(this._httpService.BuildUrl(this._url, "request"));

            return await this._httpService.Get<List<FriendRequestListDto>>(settings).ExecuteWithResult() ?? new List<FriendRequestListDto>();
        }

        /// <inheritdoc />
        public async Task<List<FriendListDto>> GetMyFriends()
        {
            var settings = new HttpSettings(this._url);

            return await this._httpService.Get<List<FriendListDto>>(settings).ExecuteWithResult() ?? new List<FriendListDto>();
        }

        /// <inheritdoc />
        public async Task<bool> RemoveFriend(string friendId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(friendId);

            var toaster = new ToasterSettings("Friend removing");

            var settings = new HttpSettings(this._url).AddPathParams(pathParams).AddToaster(toaster);

            return await this._httpService.Delete(settings).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> SendFriendRequest(FriendRequestModel model)
        {
            var toaster = new ToasterSettings("Friend request sending");

            var settings = new HttpSettings(_httpService.BuildUrl(this._url, "request")).AddToaster(toaster);

            var body = new HttpBody<FriendRequestModel>(model);

            return await this._httpService.Post(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> SendFriendRequestResponse(FriendRequestResponseModel model)
        {
            var toaster = new ToasterSettings("Friend request answering");

            var settings = new HttpSettings(this._httpService.BuildUrl(this._url, "request")).AddToaster(toaster);

            var body = new HttpBody<FriendRequestResponseModel>(model);

            return await this._httpService.Put(settings, body).Execute();
        }
    }
}