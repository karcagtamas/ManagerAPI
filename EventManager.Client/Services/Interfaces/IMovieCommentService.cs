using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Movie Comment Service
    /// </summary>
    public interface IMovieCommentService : IHttpCall<int>
    {
        /// <summary>
        /// Get list of comments by movie
        /// </summary>
        /// <param name="movieId">Movie Id</param>
        /// <returns></returns>
        Task<List<MovieCommentListDto>> GetList(int movieId);
    }
}