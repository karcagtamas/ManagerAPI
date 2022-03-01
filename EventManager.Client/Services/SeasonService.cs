using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.Models.SL;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class SeasonService : HttpCall<int>, ISeasonService
    {
        /// <summary>
        /// Init Season Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public SeasonService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/season", "Season")
        {
        }

        /// <inheritdoc />
        public async Task<bool> UpdateSeenStatus(List<SeasonSeenStatusModel> models)
        {
            var settings = new HttpSettings(Http.BuildUrl(Url, "map", "status")).AddToaster("My Season seen status updating");

            var body = new HttpBody<List<SeasonSeenStatusModel>>(models);

            return await this.Http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> AddIncremented(int seriesId, int count)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(seriesId);

            var queryParams = new HttpQueryParameters();
            queryParams.Add("count", count);

            var settings = new HttpSettings(Url).AddQueryParams(queryParams).AddPathParams(pathParams).AddToaster("Season adding");

            var body = new HttpBody<object?>(null);

            return await this.Http.Post(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> DeleteDecremented(int seasonId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(seasonId);

            var settings = new HttpSettings(Http.BuildUrl(Url, "decremented")).AddPathParams(pathParams).AddToaster("Season deleting");

            return await this.Http.Delete(settings).Execute();
        }
    }
}