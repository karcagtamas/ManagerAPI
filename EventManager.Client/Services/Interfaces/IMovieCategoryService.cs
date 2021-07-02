using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Movie Category Service
    /// </summary>
    public interface IMovieCategoryService : IHttpCall<MovieCategoryDto, MovieCategoryDto, MovieCategoryModel>
    {
        /// <summary>
        /// Get selector list by Movie
        /// </summary>
        /// <param name="movieId">Movie Id</param>
        Task<List<MovieCategorySelectorListDto>> GetSelectorList(int movieId);
    }
}