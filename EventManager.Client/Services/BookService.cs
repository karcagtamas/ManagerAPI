using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;

namespace EventManager.Client.Services
{
    /// <inheritdoc cref="EventManager.Client.Services.Interfaces.IBookService" />
    public class BookService : HttpCall<int>, IBookService
    {
        /// <summary>
        /// Init Book Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public BookService(IHttpService httpService) : base(httpService, $"{ApplicationSettings.BaseApiUrl}/book", "Book")
        {
        }

        /// <inheritdoc />
        public async Task<bool> AddBookToMyBooks(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            var settings = new HttpSettings(Http.BuildUrl(this.Url, "map")).AddPathParams(pathParams).AddToaster("Adding book to My Books");

            var body = new HttpBody<object?>(null);

            return await this.Http.Post(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<List<MyBookListDto>> GetMyList()
        {
            var settings = new HttpSettings($"{this.Url}/my");

            return await this.Http.Get<List<MyBookListDto>>(settings).ExecuteWithResult() ?? new List<MyBookListDto>();
        }

        /// <inheritdoc />
        public async Task<MyBookDto?> GetMy(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "my")).AddPathParams(pathParams);

            return await this.Http.Get<MyBookDto>(settings).ExecuteWithResult();
        }

        /// <inheritdoc />
        public async Task<bool> RemoveBookFromMyBooks(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            var settings = new HttpSettings(Http.BuildUrl(this.Url, "map")).AddPathParams(pathParams).AddToaster("Removing book from My Books");

            return await this.Http.Delete(settings).Execute();
        }

        /// <inheritdoc />
        public async Task<List<MyBookSelectorListDto>> GetMySelectorList(bool onlyMine)
        {
            var queryParams = new HttpQueryParameters();
            queryParams.Add("onlyMine", onlyMine);

            var settings = new HttpSettings(Http.BuildUrl(this.Url, "selector")).AddQueryParams(queryParams);

            return await this.Http.Get<List<MyBookSelectorListDto>>(settings).ExecuteWithResult() ?? new List<MyBookSelectorListDto>();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateMyBooks(MyBookModel model)
        {
            var settings = new HttpSettings(Http.BuildUrl(this.Url, "map")).AddToaster("My Books updating");

            var body = new HttpBody<MyBookModel>(model);

            return await this.Http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateReadStatuses(List<BookReadStatusModel> models)
        {
            var settings = new HttpSettings(Http.BuildUrl(this.Url, "map", "/status")).AddToaster("My Book read status updating");

            var body = new HttpBody<List<BookReadStatusModel>>(models);

            return await this.Http.Put(settings, body).Execute();
        }
    }
}