using KarcagS.Shared.Attributes;
using ManagerAPI.Shared.DTOs.SL;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL;

/// <summary>
/// Movie create or update model
/// </summary>
public class MovieModel
{
    /// <summary>
    /// Title
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
    /// Release Year
    /// </summary>
    [MinNumber(1900)] public int? ReleaseYear { get; set; }

    /// <summary>
    /// Length
    /// </summary>
    [MaxNumber(999)] [MinNumber(1)] public int? Length { get; set; }

    /// <summary>
    /// Director
    /// </summary>
    [MaxLength(60)] public string Director { get; set; }

    /// <summary>
    /// Trailer Url
    /// </summary>
    [MaxLength(200)] public string TrailerUrl { get; set; }

    /// <summary>
    /// Empty init
    /// </summary>
    public MovieModel()
    {
    }

    /// <summary>
    /// Model from movie data object
    /// </summary>
    /// <param name="movie">Movie data object</param>
    public MovieModel(MovieDto movie)
    {
        this.Title = movie.Title;
        this.Description = movie.Description;
        this.ReleaseYear = movie.ReleaseYear;
        this.Length = movie.Length;
        this.Director = movie.Director;
        this.TrailerUrl = movie.TrailerUrl;
    }
}
