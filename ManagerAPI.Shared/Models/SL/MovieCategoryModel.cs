using ManagerAPI.Shared.DTOs.SL;
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

        /// <summary>
        /// Init Movie Category Model
        /// </summary>
        public MovieCategoryModel()
        {
            Name = "";
        }

        /// <summary>
        /// Init Movie Category Model from Source
        /// </summary>
        /// <param name="category"></param>
        public MovieCategoryModel(MovieCategoryDto category)
        {
            Name = category.Name;
        }
    }
}