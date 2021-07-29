using ManagerAPI.Shared.Models;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Auth Service
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Register user
        /// </summary>
        /// <params name="model">Model</params>
        /// <returns>True if it was successful</returns>
        Task<bool> Register(RegistrationModel model);

        /// <summary>
        /// Login user
        /// </summary>
        /// <params name="model">Model</params>
        /// <returns>True if it was successful</returns>
        Task<string> Login(LoginModel model);

        /// <summary>
        /// Logout
        /// </summary>
        Task Logout();

        /// <summary>
        /// User has a role from Input
        /// </summary>
        /// <params name="roles">Role list</params>
        /// <returns>True if it has</returns>
        Task<bool> HasRole(params string[] roles);

        /// <summary>
        /// User is logged in
        /// </summary>
        /// <returns>True if it is</returns>
        Task<bool> IsLoggedIn();
    }
}