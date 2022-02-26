﻿using AutoMapper;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Domain.Enums.SL;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs.SL;
using StatusLibrary.Services.Services.Interfaces;

namespace StatusLibrary.Services.Services;

/// <inheritdoc />
public class BookService : Repository<Book, StatusLibraryNotificationType>, IBookService
{
    // Things
    private const string UserBookThing = "user-book";

    // Messages
    private const string UserBookConnectionDoesNotExistMessage = "User Book connection does not exist";

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
        utilsService, notificationService, mapper, "Book",
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
        var user = this.Utils.GetCurrentUser();

        var mapping =
            this._databaseContext.UserBookSwitch.FirstOrDefault(x => x.UserId == user.Id && x.BookId == id);

        if (mapping == null)
        {
            mapping = new UserBook { BookId = id, UserId = user.Id, Read = false };
            this._databaseContext.UserBookSwitch.Add(mapping);
            this._databaseContext.SaveChanges();
            this.Logger.LogInformation(user, this.GetService(), this.GetEvent("add my"), id);
            this.Notification.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MyBookListUpdated,
                user);
        }
    }

    /// <inheritdoc />
    public List<MyBookListDto> GetMyList()
    {
        var user = this.Utils.GetCurrentUser();

        var list = user.MyBooks.ToList();

        this.Logger.LogInformation(user, this.GetService(), this.GetEvent("get my"),
            list.Select(x => x.Book.Id).ToList());

        return this.Mapper.Map<List<MyBookListDto>>(list).OrderBy(x => x.Name).ToList();
    }

    /// <inheritdoc />
    public MyBookDto GetMy(int id)
    {
        var user = this.Utils.GetCurrentUser();

        var book = this.Get<MyBookDto>(id);
        var myBook = user.MyBooks.FirstOrDefault(x => x.Book.Id == book.Id);
        book.IsMine = myBook != null;
        book.IsRead = myBook != null && myBook.Read;

        this.Logger.LogInformation(user, this.GetService(), this.GetEvent("get my"), book.Id);

        return book;
    }

    /// <inheritdoc />
    public void RemoveBookFromMyBooks(int id)
    {
        var user = this.Utils.GetCurrentUser();

        var mapping =
            this._databaseContext.UserBookSwitch.FirstOrDefault(x => x.UserId == user.Id && x.BookId == id);

        if (mapping != null)
        {
            this._databaseContext.UserBookSwitch.Remove(mapping);
            this._databaseContext.SaveChanges();
            this.Logger.LogInformation(user, this.GetService(), this.GetEvent("delete my"), id);
            this.Notification.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MyBookListUpdated,
                user);
        }
    }

    /// <inheritdoc />
    public List<MyBookSelectorListDto> GetMySelectorList(bool onlyMine)
    {
        var user = this.Utils.GetCurrentUser();

        var list = this.GetAll<MyBookSelectorListDto>().OrderBy(x => x.Name).ToList();
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

        this.Logger.LogInformation(user, this.GetService(), this.GetEvent("get my selector"),
            list.Select(x => x.Id).ToList());

        return list;
    }

    /// <inheritdoc />
    public void UpdateMyBooks(List<int> ids)
    {
        var user = this.Utils.GetCurrentUser();

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
        this.Logger.LogInformation(user, this.GetService(), this.GetEvent("update my"), ids);
        this.Notification.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MyBookListUpdated, user);
    }

    /// <inheritdoc />
    public void UpdateReadStatus(int id, bool status)
    {
        var user = this.Utils.GetCurrentUser();

        var userBook = this._databaseContext.UserBookSwitch.Find(user.Id, id);
        if (userBook == null)
        {
            throw this.Logger.LogInvalidThings(user, this.GetService(), UserBookThing,
                UserBookConnectionDoesNotExistMessage);
        }

        userBook.Read = status;
        userBook.ReadOn = status ? DateTime.Now : null;
        this._databaseContext.UserBookSwitch.Update(userBook);
        this._databaseContext.SaveChanges();

        this.Logger.LogInformation(user, this.GetService(), this.GetEvent("set read status for"), userBook.Book.Id);
        this.Notification.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.BookReadStatusUpdated,
            user, userBook.Book.Name, status ? "Read" : "Unread");
    }
}
