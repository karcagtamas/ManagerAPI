using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using System.Collections.Generic;

namespace MovieCorner.Services.Services.Interfaces
{
    /// <summary>
    /// Movie Service
    /// </summary>
    public interface IMovieService : IRepository<Movie>
    {
        /// <summary>
        /// Gets my list
        /// </summary>
        /// <returns>My movie list</returns>
        List<MyMovieListDto> GetMyList();

        /// <summary>
        /// Gets my object
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <returns>Get my movie object by Id</returns>
        MyMovieDto GetMy(int id);
        
        /// <summary>
        /// Update seen status for mapped movie
        /// </summary>
        /// <param name="id">Movie id</param>
        /// <param name="seen">Seen status</param>
        void UpdateSeenStatus(int id, bool seen);

        /// <summary>
        /// Update my list
        /// </summary>
        /// <param name="ids">Current my movie list</param>
        void UpdateMyMovies(List<int> ids);

        /// <summary>
        /// Add movie to my list
        /// </summary>
        /// <param name="id">Movie Id</param>
        void AddMovieToMyMovies(int id);

        /// <summary>
        /// Remove movie from my list
        /// </summary>
        /// <param name="id">Movie Id</param>
        void RemoveMovieFromMyMovies(int id);

        /// <summary>
        /// Get my selector list
        /// </summary>
        /// <param name="onlyMine">Return only mine elements</param>
        /// <returns>Get my movie selector list</returns>
        List<MyMovieSelectorListDto> GetMySelectorList(bool onlyMine);

        /// <summary>
        /// Updates movie's image.
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="model">New image model</param>
        void UpdateImage(int id, MovieImageModel model);

        /// <summary>
        /// Updates movie's categories
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="model">Categories model</param>
        void UpdateCategories(int id, MovieCategoryUpdateModel model);
        
        /// <summary>
        /// Updates movie's rate status for current user.
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="model">Rate model</param>
        void UpdateRate(int id, MovieRateModel model);
    }
}