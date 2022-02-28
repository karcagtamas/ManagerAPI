using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Book Service
    /// </summary>
    public interface IBookService : IHttpCall<int>
    {
        /// <summary>
        /// Get my list
        /// </summary>
        /// <returns>List of books</returns>
        Task<List<MyBookListDto>> GetMyList();

        /// <summary>
        /// Get my by Id
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>Book</returns>
        Task<MyBookDto?> GetMy(int id);

        /// <summary>
        /// Update read statuses
        /// </summary>
        /// <param name="models">Models</param>
        Task<bool> UpdateReadStatuses(List<BookReadStatusModel> models);

        /// <summary>
        /// Update my book list
        /// </summary>
        /// <param name="model">Model</param>
        Task<bool> UpdateMyBooks(MyBookModel model);

        /// <summary>
        /// Add book to my list
        /// </summary>
        /// <param name="id">Book Id</param>
        Task<bool> AddBookToMyBooks(int id);

        /// <summary>
        /// Remove book from my list
        /// </summary>
        /// <param name="id">Book id</param>
        Task<bool> RemoveBookFromMyBooks(int id);

        /// <summary>
        /// Get selector list
        /// </summary>
        /// <param name="onlyMine">Only mine elements</param>
        /// <returns>Selector list</returns>
        Task<List<MyBookSelectorListDto>> GetMySelectorList(bool onlyMine);
    }
}