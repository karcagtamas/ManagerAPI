using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models
{
    /// <summary>
    /// Registration data model
    /// </summary>
    public class RegistrationModel
    {
        [Required(ErrorMessage = "User name is required")]
        [MaxLength(100, ErrorMessage = "User name's max length is 100")]
        [MinLength(6, ErrorMessage = "User name's min length is 6")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(100, ErrorMessage = "Password's max length is 100")]
        [MinLength(8, ErrorMessage = "Password's min length is 8")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirm is required")]
        [Compare("Password", ErrorMessage = "Password confirmation is not equal with the original password")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "Address must be a valid E-mail")]
        public string Email { get; set; }

        [MaxLength(120, ErrorMessage = "Full name's max length is 120")]
        public string FullName { get; set; }
    }
}