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
using ManagerAPI.Shared.Models.SL;
using StatusLibrary.Services.Services.Interfaces;

namespace StatusLibrary.Services.Services;

/// <inheritdoc />
public class MovieService : NotificationRepository<Movie, int, StatusLibraryNotificationType>, IMovieService
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
    public MovieService(DatabaseContext context, IMapper mapper, IUtilsService utilsService,
        ILoggerService loggerService, INotificationService notificationService) : base(context, loggerService,
        utilsService, mapper, notificationService, "Movie",
        new NotificationArguments
        {
            DeleteArguments = new List<string> { "Title" },
            UpdateArguments = new List<string> { "Title" },
            CreateArguments = new List<string> { "Title" }
        })
    {
        this._databaseContext = context;
    }

    /// <inheritdoc />
    public List<MyMovieListDto> GetMyList()
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var list = user.MyMovies.Where(x => x.IsAdded).ToList();

        return this.Mapper.Map<List<MyMovieListDto>>(list).OrderBy(x => x.Title).ToList();
    }

    /// <inheritdoc />
    public MyMovieDto GetMy(int id)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var movie = this.GetMapped<MyMovieDto>(id);
        var myMovie = user.MyMovies.FirstOrDefault(x => x.Movie.Id == movie.Id);
        movie.IsMine = myMovie?.IsAdded ?? false;

        movie.IsSeen = myMovie?.IsSeen ?? false;
        movie.AddedOn = myMovie?.AddedOn;
        movie.SeenOn = myMovie?.SeenOn;
        movie.Rate = myMovie?.Rate ?? 0;

        return movie;
    }

    /// <inheritdoc />
    public void UpdateSeenStatus(int id, bool seen)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var userMovie = this._databaseContext.UserMovieSwitch.Find(user.Id, id);
        if (userMovie == null)
        {
            throw new ServerException("Movie not found");
        }

        userMovie.IsSeen = seen;
        userMovie.SeenOn = seen ? DateTime.Now : null;
        this._databaseContext.UserMovieSwitch.Update(userMovie);
        this._databaseContext.SaveChanges();

        this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MovieSeenStatusUpdated,
            user,
            userMovie.Movie.Title, seen ? "Seen" : "Unseen");
    }

    /// <inheritdoc />
    public void UpdateMyMovies(List<int> ids)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var currentMappings = this._databaseContext.UserMovieSwitch.Where(x => x.UserId == user.Id).ToList();
        foreach (var i in currentMappings)
        {
            if (ids.FindIndex(x => x == i.MovieId) == -1)
            {
                i.IsAdded = false;
                i.AddedOn = null;
                this._databaseContext.UserMovieSwitch.Update(i);
            }
            else
            {
                i.IsAdded = true;
                i.AddedOn = DateTime.Now;
                this._databaseContext.UserMovieSwitch.Update(i);
            }
        }

        foreach (int i in ids)
        {
            if (currentMappings.FirstOrDefault(x => x.MovieId == i) == null)
            {
                var map = new UserMovie()
                { MovieId = i, UserId = user.Id, IsSeen = false, AddedOn = DateTime.Now, IsAdded = true };
                this._databaseContext.UserMovieSwitch.Add(map);
            }
        }

        this._databaseContext.SaveChanges();
        this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MyMovieListUpdated,
            user);
    }

    /// <inheritdoc />
    public void AddMovieToMyMovies(int id)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var mapping =
            this._databaseContext.UserMovieSwitch.FirstOrDefault(x => x.UserId == user.Id && x.MovieId == id);

        if (mapping == null)
        {
            mapping = new UserMovie
            { MovieId = id, UserId = user.Id, IsSeen = false, AddedOn = DateTime.Now, IsAdded = true };
            this._databaseContext.UserMovieSwitch.Add(mapping);
            this._databaseContext.SaveChanges();
            this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MyMovieListUpdated,
                user);
        }
        else
        {
            mapping.AddedOn = DateTime.Now;
            mapping.IsAdded = true;
            this._databaseContext.UserMovieSwitch.Update(mapping);
            this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MyMovieListUpdated,
                user);
        }
    }

    /// <inheritdoc />
    public void RemoveMovieFromMyMovies(int id)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var mapping =
            this._databaseContext.UserMovieSwitch.FirstOrDefault(x => x.UserId == user.Id && x.MovieId == id);

        if (mapping != null)
        {
            mapping.IsAdded = false;
            mapping.AddedOn = null;
            this._databaseContext.UserMovieSwitch.Update(mapping);
            this._databaseContext.SaveChanges();
            this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.MyMovieListUpdated,
                user);
        }
    }

    /// <inheritdoc />
    public List<MyMovieSelectorListDto> GetMySelectorList(bool onlyMine)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var list = this.GetAllMapped<MyMovieSelectorListDto>().OrderBy(x => x.Title).ToList();
        foreach (var t in list)
        {
            var myMovie = user.MyMovies.FirstOrDefault(x => x.Movie.Id == t.Id);
            t.IsMine = myMovie?.IsAdded ?? false;
            t.IsSeen = myMovie != null && myMovie.IsSeen;
        }

        if (onlyMine)
        {
            list = list.Where(x => x.IsMine).ToList();
        }

        return list;
    }

    /// <inheritdoc />
    public void UpdateImage(int id, MovieImageModel model)
    {
        var movie = this._databaseContext.Movies.Find(id);

        if (movie == null)
        {
            return;
        }

        this.Mapper.Map(model, movie);

        this.Update(movie);
    }

    /// <inheritdoc />
    public void UpdateCategories(int id, MovieCategoryUpdateModel model)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var movie = this._databaseContext.Movies.Find(id);

        if (movie == null)
        {
            return;
        }

        var currentMappings = movie.Categories;

        foreach (var mapping in currentMappings)
        {
            if (!model.Ids.Contains(mapping.Category.Id))
            {
                this._databaseContext.MovieMovieCategorySwitch.Remove(mapping);
            }
        }

        var addList = model.Ids.Where(x =>
            !currentMappings.Select(y => y.Category.Id).Contains(x)).ToList();

        foreach (int modelId in addList)
        {
            this._databaseContext.MovieMovieCategorySwitch.Add(new MovieMovieCategory
            { CategoryId = modelId, MovieId = movie.Id });
        }

        this._databaseContext.SaveChanges();
        this.NotificationService.AddStatusLibraryNotificationByType(StatusLibraryNotificationType.UpdateMovie, user);
    }

    /// <inheritdoc />
    public void UpdateRate(int id, MovieRateModel model)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var map = user.MyMovies.FirstOrDefault(x => x.Movie.Id == id);

        if (map != null)
        {
            map.Rate = model.Rate;
            this._databaseContext.UserMovieSwitch.Update(map);
            this._databaseContext.SaveChanges();
        }
        else
        {
            map = new UserMovie
            { UserId = user.Id, MovieId = id, IsAdded = false, IsSeen = false, Rate = model.Rate };
            this._databaseContext.UserMovieSwitch.Add(map);
            this._databaseContext.SaveChanges();
        }
    }
}
