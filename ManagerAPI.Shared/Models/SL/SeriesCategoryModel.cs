using ManagerAPI.Shared.DTOs.SL;
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

        /// <summary>
        /// Init Category Model
        /// </summary>
        public SeriesCategoryModel()
        {
            Name = "";
        }

        /// <summary>
        /// Init Category Model from source
        /// </summary>
        /// <param name="category"></param>
        public SeriesCategoryModel(SeriesCategoryDto category)
        {
            Name = category.Name;
        }
    }
}