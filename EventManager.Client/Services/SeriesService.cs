using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;

namespace EventManager.Client.Services
{
    /// <inheritdoc cref="EventManager.Client.Services.Interfaces.ISeriesService" />
    public class SeriesService : HttpCall<int>, ISeriesService
    {
        /// <summary>
        /// Init Series Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        /// <returns></returns>
        public SeriesService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/series", "Series")
        {
        }

        /// <inheritdoc />
        public async Task<bool> AddSeriesToMySeries(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            var settings = new HttpSettings(this.Http.BuildUrl(this.Url, "map")).AddPathParams(pathParams).AddToaster("Adding series to My Series");

            var body = new HttpBody<object?>(null);

            return await this.Http.Post(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<MySeriesDto?> GetMy(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(Url, "my")).AddPathParams(pathParams);

            return await this.Http.Get<MySeriesDto>(settings).ExecuteWithResult();
        }

        /// <inheritdoc />
        public async Task<List<MySeriesListDto>> GetMyList()
        {
            var settings = new HttpSettings(Http.BuildUrl(Url, "my"));

            return await this.Http.Get<List<MySeriesListDto>>(settings).ExecuteWithResult() ?? new();
        }

        /// <inheritdoc />
        public async Task<List<MySeriesSelectorListDto>> GetMySelectorList(bool onlyMine)
        {
            var queryParams = new HttpQueryParameters();
            queryParams.Add("onlyMine", onlyMine);

            var settings = new HttpSettings(Http.BuildUrl(Url, "selector")).AddQueryParams(queryParams);

            return await this.Http.Get<List<MySeriesSelectorListDto>>(settings).ExecuteWithResult() ?? new();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateImage(int id, SeriesImageModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(Url, "image")).AddPathParams(pathParams).AddToaster("Series image updating");

            var body = new HttpBody<SeriesImageModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateCategories(int id, SeriesCategoryUpdateModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(Url, "categories")).AddPathParams(pathParams).AddToaster("Series category updating");

            var body = new HttpBody<SeriesCategoryUpdateModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateRate(int id, SeriesRateModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(Url, "rate")).AddPathParams(pathParams).AddToaster("Series rating");

            var body = new HttpBody<SeriesRateModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> RemoveSeriesFromMySeries(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            var settings = new HttpSettings(Http.BuildUrl(Url, "map")).AddPathParams(pathParams).AddToaster("Removing series from My Series");

            return await this.Http.Delete(settings).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateMySeries(MySeriesModel model)
        {
            var settings = new HttpSettings(Http.BuildUrl(Url, "map")).AddToaster("My Series updating");

            var body = new HttpBody<MySeriesModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateSeenStatus(SeriesSeenStatusModel model)
        {
            var settings = new HttpSettings(Http.BuildUrl(Url, "map", "status")).AddToaster("My Series seen status updating");

            var body = new HttpBody<SeriesSeenStatusModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }
    }
}