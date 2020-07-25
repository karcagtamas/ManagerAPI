using System.Collections.Generic;
using System.Threading.Tasks;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs.MC;
using ManagerAPI.Shared.Models.MC;

namespace EventManager.Client.Services
{
    public class BookService : IBookService
    {
        private readonly string _url = ApplicationSettings.BaseApiUrl + "/book";
        private readonly IHelperService _helperService;
        private readonly IHttpService _httpService;

        public BookService(IHelperService helperService, IHttpService httpService)
        {
            this._helperService = helperService;
            this._httpService = httpService;
        }
        
        public async Task<bool> CreateBook(BookModel model)
        {
            var settings = new HttpSettings($"{this._url}", null, null, "Book adding");

            var body = new HttpBody<BookModel>(this._helperService, model);

            return await this._httpService.create<BookModel>(settings, body);
        }

        public async Task<bool> DeleteBook(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this._url}", null, pathParams, "Book deleting");

            return await this._httpService.delete(settings);
        }

        public async Task<BookDto> GetBook(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this._url}", null, pathParams);

            return await this._httpService.get<BookDto>(settings);
        }

        public async Task<List<BookListDto>> GetBooks()
        {
            var settings = new HttpSettings($"{this._url}");

            return await this._httpService.get<List<BookListDto>>(settings);
        }

        public async Task<List<MyBookDto>> GetMyBooks()
        {
            var settings = new HttpSettings($"{this._url}");

            return await this._httpService.get<List<MyBookDto>>(settings);
        }

        public async Task<bool> UpdateBook(int id, BookModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this._url}", null, pathParams, "Book updating");

            var body = new HttpBody<BookModel>(this._helperService, model);

            return await this._httpService.update<BookModel>(settings, body);
        }

        public async Task<bool> UpdateMyBooks(MyBookModel model)
        {
            var settings = new HttpSettings($"{this._url}", null, null, "My Books updating");

            var body = new HttpBody<MyBookModel>(this._helperService, model);

            return await this._httpService.update<MyBookModel>(settings, body);
        }

        public async Task<bool> UpdateReadStatus(int id, BookReadStatusModel model)
        {
            var settings = new HttpSettings($"{this._url}", null, null, "My Book read status updating");

            var body = new HttpBody<BookReadStatusModel>(this._helperService, model);

            return await this._httpService.update<BookReadStatusModel>(settings, body);
        }
    }
}