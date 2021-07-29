using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models
{
    /// <summary>
    /// Message create or update model
    /// </summary>
    public class MessageModel
    {
        /// <summary>
        /// Message
        /// </summary>
        [Required(ErrorMessage = "Field is required")]
        public string Message { get; set; }

        /// <summary>
        /// Partner
        /// </summary>
        [Required] public string PartnerId { get; set; }
    }
}