using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System.Threading.Tasks;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// User Service
    /// </summary>
    public interface IUserService
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
        Task UpdatePassword(string oldPassword, string newPassword);

        /// <summary>
        /// Update profile username
        /// </summary>
        /// <param name="newUsername">New username</param>
        /// <returns>Void</returns>
        Task UpdateUsername(string newUsername);

        /// <summary>
        /// Disable my user
        /// </summary>
        void DisableUser();
    }
}