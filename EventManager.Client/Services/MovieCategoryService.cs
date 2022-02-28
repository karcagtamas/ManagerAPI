using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;

namespace EventManager.Client.Services
{
    /// <inheritdoc cref="EventManager.Client.Services.Interfaces.IMovieCategoryService" />
    public class MovieCategoryService : HttpCall<int>, IMovieCategoryService
    {
        /// <summary>
        /// Init Movie Category Service
        /// </summary>
        /// <param name="http">HTTP Service</param>
        public MovieCategoryService(IHttpService http) : base(http, $"{ApplicationSettings.BaseApiUrl}/movie-category", "Movie Category")
        {
        }

        /// <inheritdoc />
        public async Task<List<MovieCategorySelectorListDto>> GetSelectorList(int movieId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(movieId);

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "selector")).AddPathParams(pathParams);

            return await this.Http.Get<List<MovieCategorySelectorListDto>>(settings).ExecuteWithResult() ?? new List<MovieCategorySelectorListDto>();
        }
    }
}