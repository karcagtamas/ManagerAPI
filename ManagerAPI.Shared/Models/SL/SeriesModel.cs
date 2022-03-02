using KarcagS.Shared.Attributes;
using ManagerAPI.Shared.DTOs.SL;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Series create or update model
    /// </summary>
    public class SeriesModel
    {
        /// <summary>
        /// Titl
        /// </summary>
        [Required(ErrorMessage = "Field is required")]
        [MaxLength(150, ErrorMessage = "Max length is 150")]
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>

        [MaxLength(999, ErrorMessage = "Max length is 999")]
        public string Description { get; set; }

        /// <summary>
        /// Start Year
        /// </summary>
        [MinNumber(1900)] public int? StartYear { get; set; }

        /// <summary>
        /// End Year
        /// </summary>
        [MinNumber(1900)] public int? EndYear { get; set; }

        /// <summary>
        /// Trailer Url
        /// </summary>

        [MaxLength(200, ErrorMessage = "Max length is 200")]
        public string TrailerUrl { get; set; }

        /// <summary>
        /// Empty init
        /// </summary>
        public SeriesModel()
        {
        }

        /// <summary>
        /// Model from series data object
        /// </summary>
        /// <param name="series">Series data object</param>
        public SeriesModel(SeriesDto series)
        {
            this.Title = series.Title;
            this.Description = series.Description;
            this.StartYear = series.StartYear;
            this.EndYear = series.EndYear;
            this.TrailerUrl = series.TrailerUrl;
        }
    }
}