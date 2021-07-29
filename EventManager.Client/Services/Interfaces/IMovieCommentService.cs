using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Movie Comment Service
    /// </summary>
    public interface IMovieCommentService : IHttpCall<MovieCommentListDto, MovieCommentDto, MovieCommentModel>
    {
        /// <summary>
        /// Get list of comments by movie
        /// </summary>
        /// <param name="movieId">Movie Id</param>
        /// <returns></returns>
        Task<List<MovieCommentListDto>> GetList(int movieId);
    }
}