using AutoMapper;
using KarcagS.Common.Tools.HttpInterceptor;
using KarcagS.Common.Tools.Services;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Entities.WM;
using ManagerAPI.Domain.Enums.WM;
using ManagerAPI.Services.Repositories;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs.WM;

namespace ManagerAPI.Services.Services;

/// <inheritdoc />
public class WorkingDayService : NotificationRepository<WorkingDay, int, WorkingManagerNotificationType>, IWorkingDayService
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
    /// <param name="notificationService">Notification Service</param>
    public WorkingDayService(DatabaseContext context, IMapper mapper, IUtilsService utilsService,
        ILoggerService loggerService, INotificationService notificationService) : base(context, loggerService,
        utilsService, mapper, notificationService, "Working day",
        new NotificationArguments
        {
            CreateArguments = new List<string> { "Day" },
            DeleteArguments = new List<string> { "Day" },
            UpdateArguments = new List<string> { "Day" }
        })
    {
        this._databaseContext = context;
    }

    /// <inheritdoc />
    public WorkingDayListDto Get(DateTime day)
    {
        var user = this.Utils.GetCurrentUser<User, string>();
        var workingDay = user.WorkingDays.FirstOrDefault(x => x.Day == day);

        if (workingDay == null)
        {
            throw new ServerException("Day not exists");
        }

        var dto = this.Mapper.Map<WorkingDayListDto>(workingDay);
        return dto;
    }

    /// <inheritdoc />
    public WorkingDayStatDto Stat(int id)
    {
        var workingDay = this._databaseContext.WorkingDays.Find(id);

        if (workingDay == null)
        {
            throw new ServerException("Day not exists");
        }

        return this.Mapper.Map<WorkingDayStatDto>(workingDay);
    }
}
