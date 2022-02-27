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
public class SeriesCategoryService : NotificationRepository<SeriesCategory, int, StatusLibraryNotificationType>,
    ISeriesCategoryService
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
    public SeriesCategoryService(DatabaseContext context, ILoggerService logger, IUtilsService utils,
        INotificationService notification, IMapper mapper) : base(context, logger, utils, mapper, notification,
        "Series Category", new NotificationArguments
        {
            DeleteArguments = new List<string> { "Name" },
            UpdateArguments = new List<string> { "Name" },
            CreateArguments = new List<string> { "Name" }
        })
    {
        this._databaseContext = context;
    }

    /// <inheritdoc />
    public List<SeriesCategorySelectorListDto> GetSelectorList(int seriesId)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var list = this.GetAllMapped<SeriesCategorySelectorListDto>().OrderBy(x => x.Name).ToList();
        var series = this._databaseContext.Series.FirstOrDefault(x => x.Id == seriesId);

        var selected = series != null
            ? series.Categories.Select(x => x.Category).ToList()
            : new List<SeriesCategory>();

        foreach (var t in list)
        {
            t.IsSelected = selected.Any(x => x.Id == t.Id);
        }

        return list;
    }
}
