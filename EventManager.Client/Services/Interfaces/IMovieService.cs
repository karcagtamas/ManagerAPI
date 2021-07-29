using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Movie Service
    /// </summary>
    public interface IMovieService : IHttpCall<MovieListDto, MovieDto, MovieModel>
    {
        /// <summary>
        /// Get My list
        /// </summary>
        /// <returns>List of movies</returns>
        Task<List<MyMovieListDto>> GetMyList();

        /// <summary>
        /// Get My Movie by Id
        /// </summary>
        /// <param name="id">Movie Id</param>
        Task<MyMovieDto> GetMy(int id);

        /// <summary>
        /// Update seen statues
        /// </summary>
        /// <param name="models">Models</param>
        Task<bool> UpdateSeenStatuses(List<MovieSeenUpdateModel> models);

        /// <summary>
        /// Update my list
        /// </summary>
        /// <param name="model">Model</param>
        Task<bool> UpdateMyMovies(MyMovieModel model);

        /// <summary>
        /// Add movie to my list
        /// </summary>
        /// <param name="id">Movie Id</param>
        Task<bool> AddMovieToMyMovies(int id);

        /// <summary>
        /// Remove movie from my list
        /// </summary>
        /// <param name="id">Movie Id</param>
        Task<bool> RemoveMovieFromMyMovies(int id);

        /// <summary>
        /// Get my selector list
        /// </summary>
        /// <param name="onlyMine">Only mine elements</param>
        /// <returns>Selector list</returns>
        Task<List<MyMovieSelectorListDto>> GetMySelectorList(bool onlyMine);

        /// <summary>
        /// Update image
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="model">Model</param>
        Task<bool> UpdateImage(int id, MovieImageModel model);

        /// <summary>
        /// Update categories
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="model">Model</param>
        Task<bool> UpdateCategories(int id, MovieCategoryUpdateModel model);

        /// <summary>
        /// Update rate
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="model">Model</param>
        Task<bool> UpdateRate(int id, MovieRateModel model);
    }
}