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
    public class MovieCategoryService : HttpCall<MovieCategoryDto, MovieCategoryDto, MovieCategoryModel>, IMovieCategoryService
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
            pathParams.Add<int>(movieId, -1);

            var settings = new HttpSettings($"{this.Url}/selector", null, pathParams);

            return await this.Http.Get<List<MovieCategorySelectorListDto>>(settings);
        }
    }
}