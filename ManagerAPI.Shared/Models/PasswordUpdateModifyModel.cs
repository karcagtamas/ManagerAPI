using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models
{
    /// <summary>
    /// Password update modify model
    /// </summary>
    public class PasswordUpdateModifyModel : PasswordUpdateModel
    {
        /// <summary>
        /// Confirm New Password
        /// </summary>
        [Required(ErrorMessage = "Confirmation is required")]
        [Compare("NewPassword", ErrorMessage = "New password confirmation is not equal with the new password")]
        public string ConfirmNewPassword { get; set; }
    }
}