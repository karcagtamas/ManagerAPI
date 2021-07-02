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
    public class BookService : HttpCall<BookListDto, BookDto, BookModel>, IBookService
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
            pathParams.Add<int>(id, -1);
            var settings = new HttpSettings($"{this.Url}/map", null, pathParams, "Adding book to My Books");

            var body = new HttpBody<object>(null);

            return await this.Http.Create<object>(settings, body);
        }

        /// <inheritdoc />
        public async Task<List<MyBookListDto>> GetMyList()
        {
            var settings = new HttpSettings($"{this.Url}/my");

            return await this.Http.Get<List<MyBookListDto>>(settings);
        }

        /// <inheritdoc />
        public async Task<MyBookDto> GetMy(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this.Url}/my", null, pathParams);

            return await this.Http.Get<MyBookDto>(settings);
        }

        /// <inheritdoc />
        public async Task<bool> RemoveBookFromMyBooks(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);
            var settings = new HttpSettings($"{this.Url}/map", null, pathParams, "Removing book from My Books");

            return await this.Http.Delete(settings);
        }

        /// <inheritdoc />
        public async Task<List<MyBookSelectorListDto>> GetMySelectorList(bool onlyMine)
        {
            var queryParams = new HttpQueryParameters();
            queryParams.Add("onlyMine", onlyMine);

            var settings = new HttpSettings($"{this.Url}/selector", queryParams, null);

            return await this.Http.Get<List<MyBookSelectorListDto>>(settings);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateMyBooks(MyBookModel model)
        {
            var settings = new HttpSettings($"{this.Url}/map", null, null, "My Books updating");

            var body = new HttpBody<MyBookModel>(model);

            return await this.Http.Update<MyBookModel>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateReadStatuses(List<BookReadStatusModel> models)
        {
            var settings = new HttpSettings($"{this.Url}/map/status", null, null, "My Book read status updating");

            var body = new HttpBody<List<BookReadStatusModel>>(models);

            return await this.Http.Update<List<BookReadStatusModel>>(settings, body);
        }
    }
}