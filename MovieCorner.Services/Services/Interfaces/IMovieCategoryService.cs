using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Shared.DTOs.SL;
using System.Collections.Generic;

namespace MovieCorner.Services.Services.Interfaces
{
    /// <summary>
    /// Movie Category Service
    /// </summary>
    public interface IMovieCategoryService : IRepository<MovieCategory>
    {
        /// <summary>
        /// Gets selector list for the given movie.
        /// </summary>
        /// <param name="movieId">Movie Id</param>
        /// <returns>Movie category selector list for the requested movie.</returns>
        List<MovieCategorySelectorListDto> GetSelectorList(int movieId);
    }
}