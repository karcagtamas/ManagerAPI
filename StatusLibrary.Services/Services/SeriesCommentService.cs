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
public class SeriesCommentService : NotificationRepository<SeriesComment, int, StatusLibraryNotificationType>, ISeriesCommentService
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
    public SeriesCommentService(DatabaseContext context, ILoggerService logger, IUtilsService utils,
        INotificationService notification, IMapper mapper) : base(context, logger, utils, mapper, notification,
        "Series Comment", new NotificationArguments
        {
            DeleteArguments = new List<string>(),
            UpdateArguments = new List<string>(),
            CreateArguments = new List<string>()
        })
    {
        this._databaseContext = context;
    }

    /// <inheritdoc />
    public List<SeriesCommentListDto> GetList(int seriesId)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var series = this._databaseContext.Series.Find(seriesId);

        var list = series?.Comments != null
            ? this.Mapper.Map<List<SeriesCommentListDto>>(series.Comments).Select(x =>
            {
                x.OwnerIsCurrent = x.UserId == (user?.Id ?? "");
                return x;
            }).OrderBy(x => x.Creation).ToList()
            : new List<SeriesCommentListDto>();


        return list;
    }
}
