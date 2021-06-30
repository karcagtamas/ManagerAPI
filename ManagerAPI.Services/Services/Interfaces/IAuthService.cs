using ManagerAPI.Shared.Models;
using System.Threading.Tasks;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// Auth Service
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registration by registration model
        /// </summary>
        /// <param name="model">Model for the registration with main data</param>
        /// <returns>Result of the registration</returns>
        Task Registration(RegistrationModel model);

        /// <summary>
        /// Login by the login model
        /// </summary>
        /// <param name="model">Model for the login with login credentials</param>
        /// <returns>Token</returns>
        Task<string> Login(LoginModel model);

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="userId">User Id</param>
        void Logout(string userId);
    }
}