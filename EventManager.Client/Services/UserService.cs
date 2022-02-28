using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly string _url = ApplicationSettings.BaseApiUrl + "/user";
        private readonly IHttpService _httpService;

        /// <summary>
        /// Init User Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public UserService(IHttpService httpService)
        {
            this._httpService = httpService;
        }

        /// <inheritdoc />
        public async Task<UserDto?> GetUser()
        {
            var settings = new HttpSettings($"{this._url}");

            return await this._httpService.Get<UserDto>(settings).ExecuteWithResult();
        }

        /// <inheritdoc />
        public async Task<UserShortDto?> GetShortUser()
        {
            var settings = new HttpSettings($"{this._url}/shorter");

            return await this._httpService.Get<UserShortDto>(settings).ExecuteWithResult();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateUser(UserModel userUpdate)
        {
            var settings = new HttpSettings(this._url).AddToaster("User updating");

            var body = new HttpBody<UserModel>(userUpdate);

            return await this._httpService.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdatePassword(PasswordUpdateModel model)
        {
            var settings = new HttpSettings(this._httpService.BuildUrl(this._url, "password")).AddToaster("Password updating");

            var body = new HttpBody<PasswordUpdateModel>(model);

            return await this._httpService.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateProfileImage(byte[] image)
        {
            var settings = new HttpSettings(this._httpService.BuildUrl(this._url, "profile-image")).AddToaster("Image updating");

            var body = new HttpBody<byte[]>(image);

            return await this._httpService.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateUsername(UsernameUpdateModel model)
        {
            var settings = new HttpSettings( this._httpService.BuildUrl(this._url, "username")).AddToaster("User Name updating");

            var body = new HttpBody<UsernameUpdateModel>(model);

            return await this._httpService.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> DisableUser()
        {
            var settings = new HttpSettings(_httpService.BuildUrl(this._url, "disable")).AddToaster("User disabling");

            var body = new HttpBody<object?>(null);

            return await this._httpService.Put(settings, body).Execute();
        }
    }
}