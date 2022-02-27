using AutoMapper;
using KarcagS.Common.Tools.HttpInterceptor;
using KarcagS.Common.Tools.Services;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Domain.Enums.SL;
using ManagerAPI.Services.Repositories;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using StatusLibrary.Services.Services.Interfaces;

namespace StatusLibrary.Services.Services;

/// <inheritdoc />
public class BookService : NotificationRepository<Book, int, StatusLibraryNotificationType>, IBookService
{

    // Injects
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Injector Constructor
    /// </summary>
    /// <param name="context">Database Context</param>
    /// <param name="mapper">Mapper</param>
    /// <param name="utilsService">Utils Service</param>
    /// <param name="loggerService">Logger Service</param>
    /// <param name="notificationService"></param>
    public BookService(DatabaseContext context, IMapper mapper, IUtilsService utilsService,
        ILoggerService loggerService, INotificationService notificationService) : base(context, loggerService,
        utilsService, mapper, notificationService, "Book",
        new NotificationArguments
        {
            DeleteArguments = new List<string> { "Name" },
            CreateArguments = new List<string> { "Name" },
            UpdateArguments = new List<string> { "Name" }
        })
    {
        this._databaseContext = context;
    }

    /// <inheritdoc />
    public void AddBookToMyBooks(int id)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var mapping =
            this._databaseContext.UserBookSwitch.FirstOrDefault(x => x.UserId == user.Id && x.BookId == id);

        if (mapping == null)
        {
            mapping = new UserBook { BookId = id, UserId = user.Id, Read = false };
            this._databaseContext.UserBookSwitch.Add(mapping);
            this._databaseContext.SaveChanges();
            this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MyBookListUpdated,
                user);
        }
    }

    /// <inheritdoc />
    public List<MyBookListDto> GetMyList()
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var list = user.MyBooks.ToList();

        return this.Mapper.Map<List<MyBookListDto>>(list).OrderBy(x => x.Name).ToList();
    }

    /// <inheritdoc />
    public MyBookDto GetMy(int id)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var book = this.GetMapped<MyBookDto>(id);
        var myBook = user.MyBooks.FirstOrDefault(x => x.Book.Id == book.Id);
        book.IsMine = myBook != null;
        book.IsRead = myBook != null && myBook.Read;

        return book;
    }

    /// <inheritdoc />
    public void RemoveBookFromMyBooks(int id)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var mapping =
            this._databaseContext.UserBookSwitch.FirstOrDefault(x => x.UserId == user.Id && x.BookId == id);

        if (mapping != null)
        {
            this._databaseContext.UserBookSwitch.Remove(mapping);
            this._databaseContext.SaveChanges();
            this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MyBookListUpdated,
                user);
        }
    }

    /// <inheritdoc />
    public List<MyBookSelectorListDto> GetMySelectorList(bool onlyMine)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var list = this.GetAllMapped<MyBookSelectorListDto>().OrderBy(x => x.Name).ToList();
        foreach (var t in list)
        {
            var myBook = user.MyBooks.FirstOrDefault(x => x.Book.Id == t.Id);
            t.IsMine = myBook != null;
            t.IsRead = myBook != null && myBook.Read;
        }

        if (onlyMine)
        {
            list = list.Where(x => x.IsMine).ToList();
        }

        return list;
    }

    /// <inheritdoc />
    public void UpdateMyBooks(List<int> ids)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var currentMappings = this._databaseContext.UserBookSwitch.Where(x => x.UserId == user.Id).ToList();
        foreach (var i in currentMappings)
        {
            if (ids.FindIndex(x => x == i.BookId) == -1)
            {
                this._databaseContext.UserBookSwitch.Remove(i);
            }
        }

        foreach (int i in ids)
        {
            if (currentMappings.FirstOrDefault(x => x.BookId == i) == null)
            {
                var map = new UserBook() { BookId = i, UserId = user.Id, Read = false };
                this._databaseContext.UserBookSwitch.Add(map);
            }
        }

        this._databaseContext.SaveChanges();
        this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MyBookListUpdated, user);
    }

    /// <inheritdoc />
    public void UpdateReadStatus(int id, bool status)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var userBook = this._databaseContext.UserBookSwitch.Find(user.Id, id);
        if (userBook == null)
        {
            throw new ServerException("Book not found");
        }

        userBook.Read = status;
        userBook.ReadOn = status ? DateTime.Now : null;
        this._databaseContext.UserBookSwitch.Update(userBook);
        this._databaseContext.SaveChanges();

        this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.BookReadStatusUpdated,
            user, userBook.Book.Name, status ? "Read" : "Unread");
    }
}
