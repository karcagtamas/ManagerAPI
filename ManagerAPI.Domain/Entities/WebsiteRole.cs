using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// Website role
    /// </summary>
    public class WebsiteRole : IdentityRole
    {
        /// <summary>
        /// Level
        /// </summary>
        [Required]
        public int AccessLevel { get; set; }
    }
}