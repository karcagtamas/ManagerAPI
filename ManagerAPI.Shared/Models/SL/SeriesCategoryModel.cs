using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Series category create or update model
    /// </summary>
    public class SeriesCategoryModel
    {
        /// <summary>
        /// Category Name
        /// </summary>
        [MaxLength(120)] public string Name { get; set; }
    }
}