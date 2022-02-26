using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Shared.DTOs.SL;

namespace StatusLibrary.Services.Services.Interfaces;

/// <summary>
/// Movie Comment Service
/// </summary>
public interface IMovieCommentService : IRepository<MovieComment>
{
    /// <summary>
    /// Get list of comments for the given movie.
    /// </summary>
    /// <param name="movieId">Movie Id</param>
    /// <returns>List of comments</returns>
    List<MovieCommentListDto> GetList(int movieId);
}
