using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Shared.DTOs.SL;

namespace StatusLibrary.Services.Services.Interfaces;

/// <summary>
/// Book Service
/// </summary>
public interface IBookService : IRepository<Book>
{
    /// <summary>
    /// Gets my list
    /// </summary>
    /// <returns>My book list</returns>
    List<MyBookListDto> GetMyList();

    /// <summary>
    /// Gets my object
    /// </summary>
    /// <param name="id">Book Id</param>
    /// <returns>Get my book object by Id</returns>
    MyBookDto GetMy(int id);

    /// <summary>
    /// Update read status for mapped book
    /// </summary>
    /// <param name="id">Book id</param>
    /// <param name="status">Read status</param>
    void UpdateReadStatus(int id, bool status);

    /// <summary>
    /// Update my list
    /// </summary>
    /// <param name="ids">Current my book list</param>
    void UpdateMyBooks(List<int> ids);

    /// <summary>
    /// Add book to my list
    /// </summary>
    /// <param name="id">Book Id</param>
    void AddBookToMyBooks(int id);

    /// <summary>
    /// Remove book from my list
    /// </summary>
    /// <param name="id">Book Id</param>
    void RemoveBookFromMyBooks(int id);

    /// <summary>
    /// Get my selector list
    /// </summary>
    /// <param name="onlyMine">Return only mine elements</param>
    /// <returns>Get my book selector list</returns>
    List<MyBookSelectorListDto> GetMySelectorList(bool onlyMine);
}
