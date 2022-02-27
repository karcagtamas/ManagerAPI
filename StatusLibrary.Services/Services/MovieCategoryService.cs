using AutoMapper;
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
public class MovieCategoryService : NotificationRepository<MovieCategory, int, StatusLibraryNotificationType>, IMovieCategoryService
{
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Injector constructor
    /// </summary>
    /// <param name="context">Database Context</param>
    /// <param name="logger">Logger Service</param>
    /// <param name="utils">Utils Service</param>
    /// <param name="notification">Notification Service</param>
    /// <param name="mapper">Mapper</param>
    public MovieCategoryService(DatabaseContext context, ILoggerService logger, IUtilsService utils,
        INotificationService notification, IMapper mapper) : base(context, logger, utils, mapper, notification,
        "Movie Category", new NotificationArguments
        {
            DeleteArguments = new List<string> { "Name" },
            UpdateArguments = new List<string> { "Name" },
            CreateArguments = new List<string> { "Name" }
        })
    {
        this._databaseContext = context;
    }

    /// <inheritdoc />
    public List<MovieCategorySelectorListDto> GetSelectorList(int movieId)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var list = this.GetAllMapped<MovieCategorySelectorListDto>().OrderBy(x => x.Name).ToList();
        var movie = this._databaseContext.Movies.FirstOrDefault(x => x.Id == movieId);

        var selected = movie != null
            ? movie.Categories.Select(x => x.Category).ToList()
            : new List<MovieCategory>();

        foreach (var t in list)
        {
            t.IsSelected = selected.Any(x => x.Id == t.Id);
        }

        return list;
    }
}
