using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models
{
    /// <summary>
    /// User Name update model
    /// </summary>
    public class UsernameUpdateModel
    {
        /// <summary>
        /// User Name
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100")]
        [MinLength(6, ErrorMessage = "Minimum length is 6")]
        public string? UserName { get; set; }
    }
}