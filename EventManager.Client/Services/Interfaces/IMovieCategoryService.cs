using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Movie Category Service
    /// </summary>
    public interface IMovieCategoryService : IHttpCall<int>
    {
        /// <summary>
        /// Get selector list by Movie
        /// </summary>
        /// <param name="movieId">Movie Id</param>
        Task<List<MovieCategorySelectorListDto>> GetSelectorList(int movieId);
    }
}