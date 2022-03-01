using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class SeriesCategoryService : HttpCall<int>, ISeriesCategoryService
    {
        /// <summary>
        /// Init Series Category Service
        /// </summary>
        /// <param name="http">HTTP Service</param>
        public SeriesCategoryService(IHttpService http) : base(http, $"{ApplicationSettings.BaseApiUrl}/series-category", "Series Category")
        {
        }

        /// <inheritdoc />
        public async Task<List<SeriesCategorySelectorListDto>> GetSelectorList(int movieId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(movieId);

            var settings = new HttpSettings(Http.BuildUrl(Url, "selector")).AddPathParams(pathParams);

            return await this.Http.Get<List<SeriesCategorySelectorListDto>>(settings).ExecuteWithResult() ?? new();
        }
    }
}