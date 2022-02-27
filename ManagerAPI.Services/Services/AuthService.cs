using KarcagS.Common.Tools.HttpInterceptor;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Enums;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Services.Utils;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAPI.Services.Services
{
    /// <inheritdoc />
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<WebsiteRole> roleManager;
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly INotificationService _notificationService;

        /// <summary>
        /// Auth Service constructor
        /// </summary>
        /// <param name="userManager">User Manager</param>
        /// <param name="roleManager">Role Manager</param>
        /// <param name="userService">User Service</param>
        /// <param name="tokenService">Token Service</param>
        /// <param name="notificationService">Notification Service</param>
        public AuthService(UserManager<User> userManager, RoleManager<WebsiteRole> roleManager, IUserService userService, ITokenService tokenService, INotificationService notificationService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.userService = userService;
            this.tokenService = tokenService;
            this._notificationService = notificationService;
        }

        /// <inheritdoc />
        public async System.Threading.Tasks.Task Registration(RegistrationModel model)
        {
            if (userService.IsExist(model.UserName, model.Email))
            {
                throw new ServerException("User already created");
            }

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
                LastLogin = DateTime.Now,
                RegistrationDate = DateTime.Now,
                IsActive = true
            };

            var result = await userManager.CreateAsync(user, model.Password);

            await AddDefaultRoleByResult(result, user);

            this._notificationService.AddSystemNotificationByType(SystemNotificationType.Registration, user);
        }

        /// <inheritdoc />
        public async Task<TokenDTO> Login(LoginModel model)
        {
            var user = userManager.Users.SingleOrDefault(u => u.UserName == model.UserName);

            if (user is null)
            {
                throw new ServerException("User not found");
            }

            if (!user.IsActive)
            {
                throw new ServerException("User is disabled");
            }

            if (!await userManager.CheckPasswordAsync(user, model.Password))
                throw new ServerException("Incorrect username or password");

            user.LastLogin = DateTime.Now;
            userService.Update(user);
            userService.Persist();

            return await CreateTokensAndSave(user, Guid.NewGuid().ToString());

        }

        /// <inheritdoc />
        public void Logout(string userName, string clientId)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("User is not logged in");
            }

            var user = userService.GetByName(userName);

            if (user is null)
            {
                throw new ArgumentException("User does not exist");
            }

            foreach (var token in user.RefreshTokens)
            {
                if (token.IsActive && token.ClientId == clientId)
                {
                    token.Revoked = DateTime.Now;
                }
            }

            userService.Update(user);
            userService.Persist();
            this._notificationService.AddSystemNotificationByType(SystemNotificationType.Logout, user);
        }

        private async System.Threading.Tasks.Task AddDefaultRoleByResult(IdentityResult result, User user)
        {
            if (!result.Succeeded)
            {
                throw new ArgumentException(result.Errors.FirstOrDefault()?.Description);
            }
            else
            {
                if (await roleManager.RoleExistsAsync(Roles.NormalWebsiteRole.ToString()))
                {
                    await userManager.AddToRoleAsync(user, Roles.NormalWebsiteRole.ToString());
                }
            }
        }

        private async Task<TokenDTO> CreateTokensAndSave(User user, string clientId)
        {
            var refreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive && t.ClientId == clientId);
            if (refreshToken is null)
            {
                refreshToken = tokenService.BuildRefreshToken(clientId);
                user.RefreshTokens.Add(refreshToken);
                userService.Update(user);
                userService.Persist();
            }

            return new TokenDTO
            {
                AccessToken = tokenService.BuildAccessToken(userService.GetMapped<UserTokenDTO>(user.Id),
                    await userManager.GetRolesAsync(user)),
                RefreshToken = refreshToken.Token,
                ClientId = clientId,
                UserId = user.Id
            };
        }
    }
}