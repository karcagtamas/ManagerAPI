using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models
{
    /// <summary>
    /// Login model
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// User Name
        /// </summary>
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}