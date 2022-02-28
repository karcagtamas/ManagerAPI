using Blazored.LocalStorage;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class AuthService : IAuthService
    {
        private readonly IHttpService _httpService;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorageService;
        private readonly string _url = ApplicationSettings.BaseApiUrl + "/auth";

        /// <summary>
        /// Init Auth Service
        /// </summary>
        /// <params name="httpService">HTTP Service</params>
        /// <params name="httpService">HTTP Client</params>
        /// <params name="httpService">Auth state manager</params>
        /// <params name="httpService">Localstorage Service</params>
        /// <params name="httpService">Helper Service</params>
        public AuthService(IHttpService httpService, HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorageService)
        {
            this._httpService = httpService;
            this._authenticationStateProvider = authenticationStateProvider;
            this._localStorageService = localStorageService;
            this._httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<bool> Register(RegistrationModel model)
        {
            var settings = new HttpSettings(this._httpService.BuildUrl(this._url, "Registration")).AddToaster("Registration");

            var body = new HttpBody<RegistrationModel>(model);

            return await this._httpService.Post(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<string?> Login(LoginModel model)
        {
            var settings = new HttpSettings(this._httpService.BuildUrl(this._url, "Login")).AddToaster("Login");

            var body = new HttpBody<LoginModel>(model);

            string? result = await this._httpService.PostString(settings, body).ExecuteWithResult();

            if (!string.IsNullOrEmpty(result))
            {
                await this._localStorageService.SetItemAsync("authToken", result);
                this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result);
                ((ApiAuthenticationStateProvider)this._authenticationStateProvider).MarkUserAsAuthenticated();
            }

            return result;
        }

        /// <inheritdoc />
        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)this._authenticationStateProvider).ClearStorage();
        }

        /// <inheritdoc />
        public async Task<bool> HasRole(params string[] roles)
        {
            var state = await this._authenticationStateProvider.GetAuthenticationStateAsync();
            var claims = state.User.Claims.Where(x => x.Type == ClaimTypes.Role)
                .Select(x => x.Value).ToList();

            return claims.Any(roles.Contains);
        }

        /// <inheritdoc />
        public async Task<bool> IsLoggedIn()
        {
            return !string.IsNullOrEmpty(await this._localStorageService.GetItemAsync<string>("authToken"));
        }
    }
}