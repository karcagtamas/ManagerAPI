using Blazored.LocalStorage;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.WebUtilities;
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
        private readonly ITokenService tokenService;
        private readonly NavigationManager navigationManager;
        private readonly string _url = ApplicationSettings.BaseApiUrl + "/auth";

        /// <summary>
        /// Init Auth Service
        /// </summary>
        /// <params name="httpService">HTTP Service</params>
        /// <params name="httpService">HTTP Client</params>
        /// <params name="httpService">Auth state manager</params>
        /// <params name="httpService">Localstorage Service</params>
        /// <params name="httpService">Helper Service</params>
        public AuthService(IHttpService httpService, HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorageService, ITokenService tokenService, NavigationManager navigationManager)
        {
            this._httpService = httpService;
            this._authenticationStateProvider = authenticationStateProvider;
            this._localStorageService = localStorageService;
            this._httpClient = httpClient;
            this.tokenService = tokenService;
            this.navigationManager = navigationManager;

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

            var user = await _httpService.PostWithResult<TokenDTO, LoginModel>(settings, body).ExecuteWithResult();

            if (user is null) return null;

            await tokenService.SetUser(user);

            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated();

            return user.UserId;
        }

        /// <inheritdoc />
        public async Task Logout()
        {
            await tokenService.ClearUser();

            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
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
        public bool IsLoggedIn()
        {
            return tokenService.UserInStore();
        }

        /// <inheritdoc />
        public void NotAuthorized()
        {
            var query = new Dictionary<string, string>
            {
                ["redirectUri"] = navigationManager.Uri
            };

            navigationManager.NavigateTo(QueryHelpers.AddQueryString("/login", query));
        }
    }
}