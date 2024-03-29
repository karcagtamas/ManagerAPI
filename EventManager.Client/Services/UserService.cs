using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System.Threading.Tasks;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly string _url = ApplicationSettings.BaseApiUrl + "/user";
        private readonly IHelperService _helperService;
        private readonly IHttpService _httpService;

        /// <summary>
        /// Init User Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        /// <param name="helperService">Helper Service</param>
        public UserService(IHttpService httpService, IHelperService helperService)
        {
            this._httpService = httpService;
            this._helperService = helperService;
        }

        /// <inheritdoc />
        public async Task<UserDto> GetUser()
        {
            var settings = new HttpSettings($"{this._url}");

            return await this._httpService.Get<UserDto>(settings);
        }

        /// <inheritdoc />
        public async Task<UserShortDto> GetShortUser()
        {
            var settings = new HttpSettings($"{this._url}/shorter");

            return await this._httpService.Get<UserShortDto>(settings);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateUser(UserModel userUpdate)
        {
            var settings = new HttpSettings($"{this._url}", null, null, "User updating");

            var body = new HttpBody<UserModel>(userUpdate);

            return await this._httpService.Update<UserModel>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> UpdatePassword(PasswordUpdateModel model)
        {
            var settings = new HttpSettings($"{this._url}/password", null, null, "Password updating");

            var body = new HttpBody<PasswordUpdateModel>(model);

            return await this._httpService.Update<PasswordUpdateModel>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateProfileImage(byte[] image)
        {
            var settings = new HttpSettings($"{this._url}/profile-image", null, null, "Image updating");

            var body = new HttpBody<byte[]>(image);

            return await this._httpService.Update<byte[]>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateUsername(UsernameUpdateModel model)
        {
            var settings = new HttpSettings($"{this._url}/username", null, null, "User Name updating");

            var body = new HttpBody<UsernameUpdateModel>(model);

            return await this._httpService.Update<UsernameUpdateModel>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> DisableUser()
        {
            var settings = new HttpSettings($"{this._url}/disable", null, null, "User disabling");

            var body = new HttpBody<object>(null);

            return await this._httpService.Update<object>(settings, body);
        }
    }
}