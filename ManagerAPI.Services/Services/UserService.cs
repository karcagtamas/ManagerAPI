using AutoMapper;
using KarcagS.Common.Tools.HttpInterceptor;
using KarcagS.Common.Tools.Repository;
using KarcagS.Common.Tools.Services;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Enums;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace ManagerAPI.Services.Services;

/// <summary>
/// User Service
/// </summary>
public class UserService : MapperRepository<User, string>, IUserService
{
    // Injects
    private readonly UserManager<User> userManager;
    private readonly INotificationService notificationService;

    /// <summary>
    /// User Service constructor
    /// </summary>
    /// <param name="context">Database Context</param>
    /// <param name="mapper">Mapper</param>
    /// <param name="utilsService">Utils Service</param>
    /// <param name="userManager">User manager</param>
    /// <param name="notificationService">Notification Service</param>
    /// <param name="loggerService">Logger Service</param>
    public UserService(DatabaseContext context, IMapper mapper, IUtilsService utilsService,
        UserManager<User> userManager,
        INotificationService notificationService, ILoggerService loggerService) : base(context, loggerService, utilsService, mapper, "User")
    {
        this.userManager = userManager;
        this.notificationService = notificationService;
    }

    /// <inheritdoc />
    public async Task<UserDto> GetUser()
    {
        var userId = Utils.GetCurrentUserId<string>();

        if (userId is null)
        {
            throw new ArgumentNullException(nameof(userId));
        }

        var user = Get(userId);
        var list = (await this.userManager.GetRolesAsync(user)).ToList();


        var userDto = GetMapped<UserDto>(userId);
        userDto.Roles = this.Context.Set<WebsiteRole>().OrderByDescending(x => x.AccessLevel).Where(x => list.Contains(x.Name))
            .Select(x => x.Name).ToList();

        return userDto;
    }

    /// <inheritdoc />
    public UserShortDto GetShortUser()
    {
        var userId = Utils.GetCurrentUserId<string>();

        if (userId is null)
        {
            throw new ArgumentNullException(nameof(userId));
        }

        return GetMapped<UserShortDto>(userId);
    }

    /// <inheritdoc />
    public void UpdateUser(UserModel model)
    {
        var userId = Utils.GetCurrentUserId<string>();

        if (userId is null)
        {
            throw new ArgumentNullException(nameof(userId));
        }

        if (model is null)
        {
            throw new ServerException("Invalid model");
        }

        UpdateByModel(userId, model);
        Persist();

        this.notificationService.AddSystemNotificationByType(SystemNotificationType.MyProfileUpdated, Get(userId));
    }

    /// <inheritdoc />
    public void UpdateProfileImage(byte[] image)
    {
        var user = Utils.GetCurrentUser<User, string>();

        if (image == null || image.Length == 0)
        {
            throw new ServerException("Invalid image");
        }

        user.ProfileImageData = image;
        user.ProfileImageTitle = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        Update(user);
        Persist();

        this.notificationService.AddSystemNotificationByType(SystemNotificationType.ProfileImageChanged, user);
    }

    /// <inheritdoc />
    public async System.Threading.Tasks.Task UpdatePassword(string oldPassword, string newPassword)
    {
        var user = Utils.GetCurrentUser<User, string>();

        if (await this.userManager.CheckPasswordAsync(user, oldPassword))
        {
            if (newPassword == oldPassword)
            {
                throw new ServerException("Two passwords have to be different");
            }

            var result = await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (!result.Succeeded)
            {
                throw new ServerException("Error during the password change");
            }
        }
        else
        {
            throw new ServerException("Invalid password");
        }

        this.notificationService.AddSystemNotificationByType(SystemNotificationType.PasswordChanged, user);
    }

    /// <inheritdoc />
    public async System.Threading.Tasks.Task UpdateUsername(string newUsername)
    {
        var user = Utils.GetCurrentUser<User, string>();
        if (newUsername != user.UserName)
        {
            var result = await this.userManager.SetUserNameAsync(user, newUsername);
            if (!result.Succeeded)
            {
                throw new ServerException("Error during the username change");
            }
        }
        else
        {
            throw new ServerException("Two user names have to be different");
        }

        this.notificationService.AddSystemNotificationByType(SystemNotificationType.UsernameChanged, user,
            user.UserName, newUsername);
    }

    /// <inheritdoc />
    public void DisableUser()
    {
        var user = Utils.GetCurrentUser<User, string>();
        user.IsActive = false;
        Update(user);
        Persist();

        this.notificationService.AddSystemNotificationByType(SystemNotificationType.ProfileDisabled, user);
    }

    /// <inheritdoc />
    public User? GetByRefreshToken(string token, string clientId)
    {
        return GetList(x => x.RefreshTokens.Any(t => t.Token == token && t.ClientId == clientId)).FirstOrDefault();
    }

    /// <inheritdoc />
    public User? GetByName(string userName)
    {
        return userManager.Users.SingleOrDefault(user => user.UserName == userName);
    }

    /// <inheritdoc />
    public T GetMappedByName<T>(string userName)
    {
        return Mapper.Map<T>(GetByName(userName));
    }

    /// <inheritdoc />
    public User? GetByEmail(string email)
    {
        return userManager.Users.SingleOrDefault(user => user.Email == email);
    }

    /// <inheritdoc />
    public bool IsExist(string userName, string email)
    {
        return userManager.Users.Any(user => user.Email == email || user.UserName == userName);
    }
}
