using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// User Service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get current user
        /// </summary>
        /// <returns>User</returns>
        Task<UserDto> GetUser();

        /// <summary>
        /// Get short object of current user
        /// </summary>
        /// <returns>User</returns>
        Task<UserShortDto> GetShortUser();

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="userUpdate">Model</param>
        Task<bool> UpdateUser(UserModel userUpdate);

        /// <summary>
        /// Update password
        /// </summary>
        /// <param name="model">Model</param>
        Task<bool> UpdatePassword(PasswordUpdateModel model);

        /// <summary>
        /// Update profile image
        /// </summary>
        /// <param name="image">Image</param>
        Task<bool> UpdateProfileImage(byte[] image);

        /// <summary>
        /// Update username
        /// </summary>
        /// <param name="model">Model</param>
        Task<bool> UpdateUsername(UsernameUpdateModel model);

        /// <summary>
        /// Disable user
        /// </summary>
        Task<bool> DisableUser();
    }
}