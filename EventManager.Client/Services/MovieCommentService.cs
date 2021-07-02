using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class MovieCommentService : HttpCall<MovieCommentListDto, MovieCommentDto, MovieCommentModel>, IMovieCommentService
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
            pathParams.Add<int>(movieId, -1);

            var settings = new HttpSettings($"{this.Url}/movie", null, pathParams);

            return await this.Http.Get<List<MovieCommentListDto>>(settings);
        }
    }
}