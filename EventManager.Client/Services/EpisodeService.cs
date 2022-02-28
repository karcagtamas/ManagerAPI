using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;

namespace EventManager.Client.Services
{
    /// <inheritdoc cref="EventManager.Client.Services.Interfaces.IEpisodeService" />
    public class EpisodeService : HttpCall<int>, IEpisodeService
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
            var settings = new HttpSettings(Http.BuildUrl(this.Url, "map", "status")).AddToaster("My Episode seen status updating");

            var body = new HttpBody<List<EpisodeSeenStatusModel>>(models);

            return await this.Http.Post(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> AddIncremented(int seasonId, int count)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(seasonId, -1);
            
            var queryParams = new HttpQueryParameters();
            queryParams.Add("count", count);

            var settings = new HttpSettings($"{this.Url}").AddPathParams(pathParams).AddQueryParams(queryParams).AddToaster("Episode adding");

            var body = new HttpBody<object?>(null);

            return await this.Http.Post(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> DeleteDecremented(int episodeId)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(episodeId);

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "decremented")).AddPathParams(pathParams).AddToaster("Episode deleting");

            return await this.Http.Delete(settings).Execute();
        }

        /// <inheritdoc />
        public async Task<MyEpisodeDto?> GetMy(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "my")).AddPathParams(pathParams);

            return await this.Http.Get<MyEpisodeDto>(settings).ExecuteWithResult();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateShort(int id, EpisodeShortModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "short")).AddPathParams(pathParams).AddToaster("Episode updating");

            var body = new HttpBody<EpisodeShortModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateImage(int id, EpisodeImageModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "image")).AddPathParams(pathParams).AddToaster("Episode image updating");

            var body = new HttpBody<EpisodeImageModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }
    }
}