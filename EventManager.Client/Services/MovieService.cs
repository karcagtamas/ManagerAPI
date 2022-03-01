using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class MovieService : HttpCall<int>, IMovieService
    {

        /// <summary>
        /// Init Movie Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public MovieService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/movie", "Movies")
        {

        }

        /// <inheritdoc />
        public async Task<bool> AddMovieToMyMovies(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            var settings = new HttpSettings(Http.BuildUrl(Url, "map")).AddPathParams(pathParams).AddToaster("Adding movie to My Movies");

            var body = new HttpBody<object?>(null);

            return await this.Http.Post(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<List<MyMovieListDto>> GetMyList()
        {
            var settings = new HttpSettings(Http.BuildUrl(Url, "my"));

            return await this.Http.Get<List<MyMovieListDto>>(settings).ExecuteWithResult() ?? new();
        }

        /// <inheritdoc />
        public async Task<MyMovieDto?> GetMy(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(Url, "my")).AddPathParams(pathParams);

            return await this.Http.Get<MyMovieDto>(settings).ExecuteWithResult();
        }

        /// <inheritdoc />
        public async Task<bool> RemoveMovieFromMyMovies(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            var settings = new HttpSettings(Http.BuildUrl(Url, "map")).AddPathParams(pathParams).AddToaster("Removing movie from My Movies");

            return await this.Http.Delete(settings).Execute();
        }

        /// <inheritdoc />
        public async Task<List<MyMovieSelectorListDto>> GetMySelectorList(bool onlyMine)
        {
            var queryParams = new HttpQueryParameters();
            queryParams.Add("onlyMine", onlyMine);

            var settings = new HttpSettings(Http.BuildUrl(Url, "selector")).AddQueryParams(queryParams);

            return await this.Http.Get<List<MyMovieSelectorListDto>>(settings).ExecuteWithResult() ?? new();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateImage(int id, MovieImageModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(Url, "image")).AddPathParams(pathParams).AddToaster("Movie image updating");

            var body = new HttpBody<MovieImageModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateCategories(int id, MovieCategoryUpdateModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(Url, "categories")).AddPathParams(pathParams).AddToaster("Movie category updating");

            var body = new HttpBody<MovieCategoryUpdateModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateRate(int id, MovieRateModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(Url, "rate")).AddPathParams(pathParams).AddToaster("Movie rating");

            var body = new HttpBody<MovieRateModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateMyMovies(MyMovieModel model)
        {
            var settings = new HttpSettings(Http.BuildUrl(Url, "map")).AddToaster("My Movies updating");

            var body = new HttpBody<MyMovieModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateSeenStatuses(List<MovieSeenUpdateModel> models)
        {
            var settings = new HttpSettings(Http.BuildUrl(Url, "map", "status")).AddToaster("My Movie seen status updating");

            var body = new HttpBody<List<MovieSeenUpdateModel>>(models);

            return await this.Http.Put(settings, body).Execute();
        }
    }
}