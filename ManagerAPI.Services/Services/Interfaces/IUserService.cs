using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System.Threading.Tasks;

namespace ManagerAPI.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUser();
        UserShortDto GetShortUser();
        void UpdateUser(UserModel model);
        void UpdateProfileImage(byte[] image);
        Task UpdatePassword(string oldPassword, string newPassword);
        Task UpdateUsername(string newUsername);
        void DisableUser();
    }
}