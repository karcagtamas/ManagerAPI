using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.WM
{
    /// <summary>
    /// Working field create or update model
    /// </summary>
    public class WorkingFieldModel
    {
        /// <summary>
        /// Title
        /// </summary>
        [Required(ErrorMessage = "Field is required")]
        [MaxLength(200, ErrorMessage = "Maximum length is 200")]
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Length
        /// </summary>

        [Required(ErrorMessage = "Field is required")]
        public decimal Length { get; set; }

        /// <summary>
        /// Working Day
        /// </summary>
        [Required] public int WorkingDayId { get; set; }
    }
}