using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.WM
{
    /// <summary>
    /// Working day create or update model
    /// </summary>
    public class WorkingDayModel
    {
        /// <summary>
        /// Date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Type
        /// </summary>

        [Required(ErrorMessage = "Field is required")]
        public int Type { get; set; }
    }
}
