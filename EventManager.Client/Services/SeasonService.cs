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
    public class SeasonService : HttpCall<SeasonListDto, SeasonDto, SeasonModel>, ISeasonService
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
            var settings = new HttpSettings($"{this.Url}/map/status", null, null, "My Season seen status updating");

            var body = new HttpBody<List<SeasonSeenStatusModel>>(models);

            return await this.Http.Update(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> AddIncremented(int seriesId, int count)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(seriesId, -1);

            var queryParams = new HttpQueryParameters();
            queryParams.Add("count", count);

            var settings = new HttpSettings($"{this.Url}", queryParams, pathParams, "Season adding");

            var body = new HttpBody<object>(null);

            return await this.Http.Create<object>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteDecremented(int seasonId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(seasonId, -1);

            var settings = new HttpSettings($"{this.Url}/decremented", null, pathParams, "Season deleting");

            return await this.Http.Delete(settings);
        }
    }
}