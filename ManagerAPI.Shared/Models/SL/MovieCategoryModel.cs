using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Movie category create or update model
    /// </summary>
    public class MovieCategoryModel
    {
        /// <summary>
        /// Category name
        /// </summary>
        [MaxLength(120)] public string Name { get; set; }
    }
}