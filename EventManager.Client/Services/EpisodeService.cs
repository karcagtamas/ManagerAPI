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
    public class EpisodeService : HttpCall<EpisodeListDto, EpisodeDto, EpisodeModel>, IEpisodeService
    {

        /// <summary>
        /// Init Episode Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public EpisodeService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/episode", "Episode")
        {
        }

        /// <inheritdoc />
        public async Task<bool> UpdateSeenStatus(List<EpisodeSeenStatusModel> models)
        {
            var settings = new HttpSettings($"{this.Url}/map/status", null, null, "My Episode seen status updating");

            var body = new HttpBody<List<EpisodeSeenStatusModel>>(models);

            return await this.Http.Update<List<EpisodeSeenStatusModel>>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> AddIncremented(int seasonId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(seasonId, -1);

            var settings = new HttpSettings($"{this.Url}", null, pathParams, "Episode adding");

            var body = new HttpBody<object>(null);

            return await this.Http.Create<object>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteDecremented(int episodeId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(episodeId, -1);

            var settings = new HttpSettings($"{this.Url}/decremented", null, pathParams, "Episode deleting");

            return await this.Http.Delete(settings);
        }

        /// <inheritdoc />
        public async Task<MyEpisodeDto> GetMy(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this.Url}/my", null, pathParams);

            return await this.Http.Get<MyEpisodeDto>(settings);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateShort(int id, EpisodeShortModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this.Url}/short", null, pathParams, "Episode updating");

            var body = new HttpBody<EpisodeShortModel>(model);

            return await this.Http.Update<EpisodeShortModel>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateImage(int id, EpisodeImageModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this.Url}/image", null, pathParams, "Episode image updating");

            var body = new HttpBody<EpisodeImageModel>(model);

            return await this.Http.Update<EpisodeImageModel>(settings, body);
        }
    }
}