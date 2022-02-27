using KarcagS.Common.Tools.Repository;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace ManagerAPI.Services.Services.Interfaces;

/// <summary>
/// User Service
/// </summary>
public interface IUserService : IMapperRepository<User, string>
{
    /// <summary>
    /// Gets current user's data object
    /// </summary>
    /// <returns>User DTO</returns>
    Task<UserDto> GetUser();

    /// <summary>
    /// Get small data object from user object
    /// </summary>
    /// <returns>Minimized user data object</returns>
    UserShortDto GetShortUser();

    /// <summary>
    /// Update current user's data object by the given update object
    /// </summary>
    /// <param name="model">Update object</param>
    void UpdateUser(UserModel model);

    /// <summary>
    /// Update profile image
    /// </summary>
    /// <param name="image">New image</param>
    void UpdateProfileImage(byte[] image);

    /// <summary>
    /// Update profile login password
    /// </summary>
    /// <param name="oldPassword">Old password for authentication</param>
    /// <param name="newPassword">Newly cheesed password</param>
    /// <returns>Void</returns>
    System.Threading.Tasks.Task UpdatePassword(string oldPassword, string newPassword);

    /// <summary>
    /// Update profile username
    /// </summary>
    /// <param name="newUsername">New username</param>
    /// <returns>Void</returns>
    System.Threading.Tasks.Task UpdateUsername(string newUsername);

    /// <summary>
    /// Disable my user
    /// </summary>
    void DisableUser();

    /// <summary>
    /// Get by refresh token
    /// </summary>
    /// <param name="token">Token</param>
    /// <param name="clientId">Client Id</param>
    /// <returns>User</returns>
    User? GetByRefreshToken(string token, string clientId);

    /// <summary>
    /// Get By Name
    /// </summary>
    /// <param name="userName">User name</param>
    /// <returns>User</returns>
    User? GetByName(string userName);

    /// <summary>
    /// Get mapped user By Name
    /// </summary>
    /// <typeparam name="T">Target type</typeparam>
    /// <param name="userName">User name</param>
    /// <returns>User</returns>
    T GetMappedByName<T>(string userName);

    /// <summary>
    /// Get by email
    /// </summary>
    /// <param name="email">Email</param>
    /// <returns>Use</returns>
    User? GetByEmail(string email);

    /// <summary>
    /// Is Exists
    /// </summary>
    /// <param name="userName">User name</param>
    /// <param name="email">Emai</param>
    /// <returns>True if exists</returns>
    bool IsExist(string userName, string email);
}
