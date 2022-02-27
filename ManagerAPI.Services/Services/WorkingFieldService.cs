using AutoMapper;
using KarcagS.Common.Tools.Services;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Entities.WM;
using ManagerAPI.Domain.Enums.WM;
using ManagerAPI.Services.Repositories;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs.WM;

namespace ManagerAPI.Services.Services;

/// <summary>
/// Working Field Service
/// </summary>
public class WorkingFieldService : NotificationRepository<WorkingField, int, WorkingManagerNotificationType>, IWorkingFieldService
{
    /// <summary>
    /// Injector Constructor
    /// </summary>
    /// <param name="context">Database Context</param>
    /// <param name="mapper">Mapper</param>
    /// <param name="utilsService">Utils Service</param>
    /// <param name="notificationService">Notification Service</param>
    /// <param name="loggerService">Logger Service</param>
    public WorkingFieldService(DatabaseContext context, IMapper mapper, IUtilsService utilsService,
        INotificationService notificationService, ILoggerService loggerService) : base(context, loggerService,
        utilsService, mapper, notificationService, "Working field", new NotificationArguments
        {
            CreateArguments = new List<string> { "Length" },
            DeleteArguments = new List<string> { "WorkingDay.Day" },
            UpdateArguments = new List<string> { "WorkingDay.Day" }
        })
    {
    }

    /// <inheritdoc />
    public WorkingWeekStatDto GetWeekStat(DateTime week)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var list = this.Mapper.Map<WorkingWeekStatDto>(this.GetList(x =>
            x.WorkingDay.Day >= week && x.WorkingDay.Day <= week.AddDays(7) && x.WorkingDay.User.Id == user.Id));

        return list;
    }

    /// <inheritdoc />
    public WorkingMonthStatDto GetMonthStat(int year, int month)
    {
        var user = this.Utils.GetCurrentUser<User, string>();

        var list = this.Mapper.Map<WorkingMonthStatDto>(this.GetList(x =>
            x.WorkingDay.Day.Year == year && x.WorkingDay.Day.Month == month && x.WorkingDay.User.Id == user.Id));

        return list;
    }
}
