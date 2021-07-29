using ManagerAPI.Shared.DTOs.SL;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Episode update model
    /// </summary>
    public class EpisodeShortModel
    {
        /// <summary>
        /// Title
        /// </summary>
        [Required(ErrorMessage = "Field is required")]
        [MaxLength(150, ErrorMessage = "Max length is 150")]
        public string Title { get; set; }

        /// <summary>
        /// Descriptio
        /// </summary>
        [MaxLength(300, ErrorMessage = "Max length is 300")]
        public string Description { get; set; }

        /// <summary>
        /// Empty init
        /// </summary>
        public EpisodeShortModel()
        {
        }

        /// <summary>
        /// Model from episode data object
        /// </summary>
        /// <param name="episode"></param>
        public EpisodeShortModel(EpisodeDto episode)
        {
            this.Description = episode.Description;
            this.Title = episode.Title;
        }
    }
}