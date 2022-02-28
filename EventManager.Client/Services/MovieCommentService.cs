using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;

namespace EventManager.Client.Services
{
    /// <inheritdoc cref="EventManager.Client.Services.Interfaces.IMovieCommentService" />
    public class MovieCommentService : HttpCall<int>, IMovieCommentService
    {
        /// <summary>
        /// Init Movie Comment Service
        /// </summary>
        /// <param name="http">HTTP Service</param>
        public MovieCommentService(IHttpService http) : base(http, $"{ApplicationSettings.BaseApiUrl}/movie-comment", "Movie Comment")
        {
        }

        /// <inheritdoc />
        public async Task<List<MovieCommentListDto>> GetList(int movieId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(movieId);

            var settings = new HttpSettings($"{this.Url}/movie").AddPathParams(pathParams);

            return await this.Http.Get<List<MovieCommentListDto>>(settings).ExecuteWithResult() ?? new List<MovieCommentListDto>();
        }
    }
}